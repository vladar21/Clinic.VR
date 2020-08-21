using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClinicWebCore.Data;
using ClinicWebCore.Models;

namespace ClinicWebCore.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;

        public IndexModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; }
        public IList<Address> AddressList { get; set; }

        public async Task OnGetAsync()
        {
            Patient = await _context.Patients
                .Include(p => p.Contact).ToListAsync();

            AddressList = await _context.Addresses.ToListAsync();
        }
        // Получаем инициалы
        public string GetInitials(string FirstName, string MiddleName)
        {
            return FirstName.Substring(0, 1) + '.' + MiddleName.Substring(0, 1) + '.';
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
