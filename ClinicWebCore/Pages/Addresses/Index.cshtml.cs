using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClinicWebCore.Data;
using ClinicWebCore.Models;

namespace ClinicWebCore.Pages.Addresses
{
    public class IndexModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;

        public IndexModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Address> Address { get;set; }

        public async Task OnGetAsync()
        {
            Address = await _context.Addresses.ToListAsync();
        }
    }
}
