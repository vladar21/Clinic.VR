using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClinicWebCore.Data;
using ClinicWebCore.Models;

namespace ClinicWebCore.Pages.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;

        public DeleteModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact = await _context.Contacts
                .Include(c => c.Address).FirstOrDefaultAsync(m => m.ContactID == id);

            if (Contact == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact = await _context.Contacts.FindAsync(id);

            if (Contact != null)
            {
                _context.Contacts.Remove(Contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
