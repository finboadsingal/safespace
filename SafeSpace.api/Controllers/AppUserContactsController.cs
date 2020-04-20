using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeSpace.core.Data;
using SafeSpace.core.Models;
using SafeSpace.core.Views;

namespace SafeSpace.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserContactsController : ControllerBase
    {
        private readonly SafeSpaceContext _context;

        public AppUserContactsController(SafeSpaceContext context)
        {
            _context = context;
        }

        // GET: api/AppUserContacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUserContact>>> GetAppUserContacts()
        {
            return await _context.AppUserContacts.ToListAsync();
        }

        // GET: api/AppUserContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUserContact>> GetAppUserContact(long id)
        {
            var appUserContact = await _context.AppUserContacts.FindAsync(id);

            if (appUserContact == null)
            {
                return NotFound();
            }

            return appUserContact;
        }

        // PUT: api/AppUserContacts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUserContact(long id, AppUserContact appUserContact)
        {
            if (id != appUserContact.Id)
            {
                return BadRequest();
            }

            _context.Entry(appUserContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserContactExists(id))
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

        // POST: api/AppUserContacts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AppUserContact>> PostAppUserContact(AppUserContactView appUserContactView)
        {
            var appUserContact = new AppUserContact {
                AppUserId = appUserContactView.AppUserId,
                TrackingCategory = appUserContactView.TrackingCategory,
                ContactAppUserId = _context.AppUsers.FirstOrDefault(u => u.Email == appUserContactView.ContactEmail || u.Phone == appUserContactView.ContactPhone).Id,
                CreatedOn = appUserContactView.ContactOn
            };

            _context.AppUserContacts.Add(appUserContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAppUserContact), new { id = appUserContact.Id }, appUserContact);
        }

        // DELETE: api/AppUserContacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppUserContact>> DeleteAppUserContact(long id)
        {
            var appUserContact = await _context.AppUserContacts.FindAsync(id);
            if (appUserContact == null)
            {
                return NotFound();
            }

            _context.AppUserContacts.Remove(appUserContact);
            await _context.SaveChangesAsync();

            return appUserContact;
        }

        private bool AppUserContactExists(long id)
        {
            return _context.AppUserContacts.Any(e => e.Id == id);
        }
    }
}
