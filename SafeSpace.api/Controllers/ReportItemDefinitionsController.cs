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
    public class ReportItemDefinitionsController : ControllerBase
    {
        private readonly SafeSpaceContext _context;

        public ReportItemDefinitionsController(SafeSpaceContext context)
        {
            _context = context;
        }

        // GET: api/ReportItemDefinitions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportItemDefinition>>> GetReportItemDefinitions()
        {
            return await _context.ReportItemDefinitions.ToListAsync();
        }

        // GET: api/ReportItemDefinitions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportItemDefinition>> GetReportItemDefinition(long id)
        {
            var reportItemDefinition = await _context.ReportItemDefinitions.FindAsync(id);

            if (reportItemDefinition == null)
            {
                return NotFound();
            }

            return reportItemDefinition;
        }

        // PUT: api/ReportItemDefinitions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportItemDefinition(long id, ReportItemDefinition reportItemDefinition)
        {
            if (id != reportItemDefinition.Id)
            {
                return BadRequest();
            }

            _context.Entry(reportItemDefinition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportItemDefinitionExists(id))
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

        // POST: api/ReportItemDefinitions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ReportItemDefinition>> PostReportItemDefinition(ReportItemDefinition reportItemDefinition)
        {
            _context.ReportItemDefinitions.Add(reportItemDefinition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReportItemDefinition", new { id = reportItemDefinition.Id }, reportItemDefinition);
        }

        // POST: api/ReportItemDefinitions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("uploaddefinitionlist")]
        public async Task<ActionResult<List<ReportItemDefinition>>> UploadDefinitionList(List<ReportItemDefinition> reportItemDefinitions)
        {
            foreach (var def in reportItemDefinitions)
            {
                _context.ReportItemDefinitions.Add(def);
            }
            await _context.SaveChangesAsync();

            return reportItemDefinitions;
        }

        // DELETE: api/ReportItemDefinitions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReportItemDefinition>> DeleteReportItemDefinition(long id)
        {
            var reportItemDefinition = await _context.ReportItemDefinitions.FindAsync(id);
            if (reportItemDefinition == null)
            {
                return NotFound();
            }

            _context.ReportItemDefinitions.Remove(reportItemDefinition);
            await _context.SaveChangesAsync();

            return reportItemDefinition;
        }

        private bool ReportItemDefinitionExists(long id)
        {
            return _context.ReportItemDefinitions.Any(e => e.Id == id);
        }
    }
}
