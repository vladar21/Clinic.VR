using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicWebCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebCore.Pages
{
    public class RazorProbaModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;
        public string Message { get; private set; } = "PageModel in C#";
        
        public IList<Contact> Contacts { get; set; }
        public IList<Address> Addresses { get; set; }

        public RazorProbaModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        //public void OnGet()
        //{
        //    Message += $" Server time is { DateTime.Now }";

        //}
        public async Task OnGetAsync()
        {
            Message += $" Server time is { DateTime.Now }";

            Addresses = await _context.Addresses.ToListAsync();

            //Contacts = await _context.Contacts.ToListAsync();

            Contacts = await _context.Contacts.Include(contact => contact.Address).ToListAsync();

            //ContactWIthAddress = from c in Contacts
            //                     join a in Addresses on c.AddressID equals a.AddressID
            //                     select (c, a);

        }
        public string GetInitials(string FirstName, string MiddleName)
        {
            return FirstName.Substring(0, 1) + '.' + MiddleName.Substring(0, 1) + '.';
        }
    }
}
