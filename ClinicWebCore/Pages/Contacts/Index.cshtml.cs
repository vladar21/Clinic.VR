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
    public class IndexModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;

        public IndexModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Contact> Contact { get;set; }

        public async Task OnGetAsync()
        {
            Contact = await _context.Contacts
                .Include(a => a.Address)                
                .AsNoTracking()
                .ToListAsync();
        }

        // Добавляем инициалы к фамилии
        public string GetInitials(string FirstName, string MiddleName)
        {
            return FirstName.Substring(0, 1) + '.' + MiddleName.Substring(0, 1) + '.';
        }

        // Адрес в строку
        public string GetAddressToString(int id)
        {
            var cont = Contact.FirstOrDefault(c => c.Address.AddressID == id);
            string addr = cont.Address.Country + ", " + cont.Address.Locality + ", " + cont.Address.Street + ", " + cont.Address.House + "/ " + cont.Address.Apartment;
            return addr;
        }
    }
}
