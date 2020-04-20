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
    public class RiskDefinitionsController : ControllerBase
    {
        private readonly SafeSpaceContext _context;

        public RiskDefinitionsController(SafeSpaceContext context)
        {
            _context = context;
        }

        // GET: api/RiskDefinitions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RiskDefinition>>> GetRiskDefinitions()
        {
            return await _context.RiskDefinitions.ToListAsync();
        }

        // GET: api/RiskDefinitions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RiskDefinition>> GetRiskDefinition(long id)
        {
            var riskDefinition = await _context.RiskDefinitions.FindAsync(id);

            if (riskDefinition == null)
            {
                return NotFound();
            }

            return riskDefinition;
        }

        // PUT: api/RiskDefinitions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRiskDefinition(long id, RiskDefinition riskDefinition)
        {
            if (id != riskDefinition.Id)
            {
                return BadRequest();
            }

            _context.Entry(riskDefinition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiskDefinitionExists(id))
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

        // POST: api/RiskDefinitions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RiskDefinition>> PostRiskDefinition(RiskDefinition riskDefinition)
        {
            _context.RiskDefinitions.Add(riskDefinition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRiskDefinition", new { id = riskDefinition.Id }, riskDefinition);
        }
        
        // POST: api/RiskDefinitions/uploaddefinitionlist
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("uploaddefinitionlist")]
        public async Task<ActionResult<List<RiskDefinition>>> UploadDefinitionList(List<RiskDefinition> riskDefinitions)
        {
            foreach (var def in riskDefinitions)
            {
                _context.RiskDefinitions.Add(def);
            }
            await _context.SaveChangesAsync();

            return riskDefinitions;
        }

        // DELETE: api/RiskDefinitions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RiskDefinition>> DeleteRiskDefinition(long id)
        {
            var riskDefinition = await _context.RiskDefinitions.FindAsync(id);
            if (riskDefinition == null)
            {
                return NotFound();
            }

            _context.RiskDefinitions.Remove(riskDefinition);
            await _context.SaveChangesAsync();

            return riskDefinition;
        }

        private bool RiskDefinitionExists(long id)
        {
            return _context.RiskDefinitions.Any(e => e.Id == id);
        }
    }
}
