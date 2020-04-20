using Microsoft.EntityFrameworkCore;
using SafeSpace.core.Data;
using SafeSpace.core.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeSpace.domain.Services
{
    public class OrganizationAssociatedPersonRatingService
    {
        private readonly SafeSpaceContext _context;
        private readonly AppUserRatingService _aurs;

        public OrganizationAssociatedPersonRatingService(SafeSpaceContext context)
        {
            _context = context;
            _aurs = new AppUserRatingService(context);
        }

        public async Task<List<AssociatedPersonView>> GetAssociatedPersonRatings(long id, string category)
        {
            var organization = await _context.Organizations.Include(o => o.AssociatedPersons).FirstOrDefaultAsync(o => o.Id == id);
            var personlist = new List<AssociatedPersonView>();
            foreach (var person in organization.AssociatedPersons)
            {
                var appuser = await _context.AppUsers.FirstOrDefaultAsync(a => a.Email == person.Email || a.Phone == person.Phone);
                var ap = new AssociatedPersonView()
                {
                    AssociatedPerson = person,
                    Rating = appuser != null ?_aurs.GetRating(appuser.Id, category) : null,
                    ContactRating = appuser != null ? _aurs.GetContactRating(appuser.Id, category) : null
                };
                personlist.Add(ap);
            }
            return personlist;
        }
    }
}
