using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClinicWebCore.Data;
using ClinicWebCore.Models;

namespace ClinicWebCore.Pages.PatSchedules
{
    public class DeleteModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;

        public DeleteModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DocSchedule DocSchedule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DocSchedule = await _context.DocSchedules
                .Include(d => d.Doc)
                .Include(d => d.Patient).FirstOrDefaultAsync(m => m.DocScheduleID == id);

            if (DocSchedule == null)
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

            DocSchedule = await _context.DocSchedules.FindAsync(id);

            if (DocSchedule != null)
            {
                _context.DocSchedules.Remove(DocSchedule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
