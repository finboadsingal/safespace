using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeSpace.core.Data;
using SafeSpace.core.Models;
using SafeSpace.core.Views;
using SafeSpace.domain.Services;

namespace SafeSpace.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationAssociatedPersonRatingsController : ControllerBase
    {
        private readonly SafeSpaceContext _context;
        private readonly AppUserRatingService _aurs;
        private readonly OrganizationAssociatedPersonRatingService _oaprs;

        public OrganizationAssociatedPersonRatingsController(SafeSpaceContext context)
        {
            _context = context;

            _aurs = new AppUserRatingService(context);
            _oaprs = new OrganizationAssociatedPersonRatingService(context);
        }

        // GET: api/OrganizationAssociatedPersonRatings/{id}/{category}
        [HttpGet("{id}/{category}")]
        public async Task<ActionResult<List<AssociatedPersonView>>> GetAppUserReport(long id, string category)
        {
            return await _oaprs.GetAssociatedPersonRatings(id, category);
        }
    }
}