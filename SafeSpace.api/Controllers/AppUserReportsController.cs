using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeSpace.core.Data;
using SafeSpace.core.Models;

namespace SafeSpace.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserReportsController : ControllerBase
    {
        private readonly SafeSpaceContext _context;

        public AppUserReportsController(SafeSpaceContext context)
        {
            _context = context;
        }

        // GET: api/AppUserReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUserReport>>> GetAppUserReports()
        {
            return await _context.AppUserReports.ToListAsync();
        }

        // GET: api/AppUserReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUserReport>> GetAppUserReport(long id)
        {
            var appUserReport = await _context.AppUserReports.FindAsync(id);

            if (appUserReport == null)
            {
                return NotFound();
            }

            return appUserReport;
        }

        // PUT: api/AppUserReports/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUserReport(long id, AppUserReport appUserReport)
        {
            if (id != appUserReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(appUserReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserReportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AppUserReports
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AppUserReport>> PostAppUserReport(AppUserReport appUserReport)
        {
            if (appUserReport.Id== 0)
                appUserReport.CreatedOn = DateTime.UtcNow;
            _context.AppUserReports.Add(appUserReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAppUserReport), new { id = appUserReport.Id }, appUserReport);
        }

        // DELETE: api/AppUserReports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppUserReport>> DeleteAppUserReport(long id)
        {
            var appUserReport = await _context.AppUserReports.FindAsync(id);
            if (appUserReport == null)
            {
                return NotFound();
            }

            _context.AppUserReports.Remove(appUserReport);
            await _context.SaveChangesAsync();

            return appUserReport;
        }

        private bool AppUserReportExists(long id)
        {
            return _context.AppUserReports.Any(e => e.Id == id);
        }
    }
}
