using Microsoft.EntityFrameworkCore;
using SafeSpace.core.Data;
using SafeSpace.core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeSpace.domain.Services
{
    public class AppUserRatingService
    {
        private readonly SafeSpaceContext _context;
        public AppUserRatingService(SafeSpaceContext context)
        {
            _context = context;
        }

        public RatingView GetRating(long id, string category)
        {
            var riskdefinitions = _context.RiskDefinitions.Where(i => i.Category == category).ToList();

            decimal rating = CalculateRating(id, category);
            string risklevel = riskdefinitions.FirstOrDefault(rd => rd.RatingStart <= rating && rd.RatingEnd > rating).Description;
            return new RatingView { AppUserId = id, Rating = rating, Risk = risklevel };
        }
        public RatingView GetContactRating(long id, string category)
        {
            var riskdefinitions = _context.RiskDefinitions.Where(i => i.Category == category).ToList();

            decimal rating = 0;
            var contactlist = _context.AppUserContacts.Where(c => c.AppUserId == id).ToList();
            foreach (var contact in contactlist)
            {
                rating += CalculateRating(contact.ContactAppUserId, category);
            }
            string risklevel = riskdefinitions.FirstOrDefault(rd => rd.RatingStart <= rating && rd.RatingEnd > rating).Description;
            return new RatingView { AppUserId = id, Rating = rating, Risk = risklevel };
        }

        private decimal CalculateRating(long id, string category)
        {
            var definitionDict = _context.ReportItemDefinitions.Where(i => i.Category == category).ToDictionary(i => i.Id);
            var appUserReport = _context.AppUserReports.Include(r => r.AppUserReportItemDetails).FirstOrDefault(r => r.AppUserId == id && r.Category == category);
            decimal rating = 0;
            foreach (var item in appUserReport.AppUserReportItemDetails)
            {
                var definition = definitionDict[item.ItemDefinitionId];
                switch (definition.DefinitionType)
                {
                    case "bool":
                        rating += item.BoolValue == null ? definition.NotReportedRating : (item.BoolValue.Value ? definition.Rating : 0);
                        break;
                    case "number":
                        decimal overreport = item.IntValue == null ? 0 : item.IntValue.Value % definition.Scale;
                        rating = rating + (item.IntValue == null ? definition.NotReportedRating : (((decimal)1 - ((decimal)(item.IntValue.Value - overreport) / (decimal)definition.Scale)) * (decimal)definition.Rating));
                        break;
                }
            }
            return rating;
        }

    }
}
