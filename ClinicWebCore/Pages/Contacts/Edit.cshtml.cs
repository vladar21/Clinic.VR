using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicWebCore.Data;
using ClinicWebCore.Models;

namespace ClinicWebCore.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;

        public EditModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contact Contact { get; set; }
        public IList<Address> AddressList { get; set; }

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

            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID");
           
            AddressList = await _context.Addresses.ToListAsync();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(Contact.ContactID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.ContactID == id);
        }

        // Адрес в строку
        public string GetAddressToString(int id)
        {
            var adr = AddressList.FirstOrDefault(m => m.AddressID == id);
            string addr = adr.Country + ", " + adr.Locality + ", " + adr.Street + ", " + adr.House + "/ " + adr.Apartment;
            return addr;
        }
    }
}
