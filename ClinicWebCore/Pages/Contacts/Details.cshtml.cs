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
    public class DetailsModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;

        public DetailsModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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

            AddressList = await _context.Addresses.ToListAsync();

            return Page();
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
