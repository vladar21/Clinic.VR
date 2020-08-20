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
    public class DetailsModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;

        public DetailsModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patients
                .Include(p => p.Contact).FirstOrDefaultAsync(m => m.PatientID == id);

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
