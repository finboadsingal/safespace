using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeSpace.core.Data;
using SafeSpace.core.Views;
using SafeSpace.domain.Services;

namespace SafeSpace.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserRatingController : ControllerBase
    {
        private readonly SafeSpaceContext _context;
        private readonly AppUserRatingService _aurs;

        public AppUserRatingController(SafeSpaceContext context)
        {
            _context = context;

            _aurs = new AppUserRatingService(context);
        }

        // GET: api/AppUserRating/{id}/{category}
        [HttpGet("{id}/{category}")]
        public async Task<ActionResult<RatingView>> GetAppUserReport(long id, string category)
        {
            return _aurs.GetRating(id, category);
        }

        // GET: api/AppUserRating/ContactRating/{id}/{category}
        [HttpGet("contactrating/{id}/{category}")]
        public async Task<ActionResult<RatingView>> GetContactRating(long id, string category)
        {
            return _aurs.GetContactRating(id, category);
        }
    }
}