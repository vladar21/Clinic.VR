using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClinicWebCore.Data;
using ClinicWebCore.Models;

namespace ClinicWebCore.Pages.Departments
{
    public class DeleteModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;

        public IList<Department> DepartmentList { get; set; }

        public DeleteModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentID == id);

            if (Department == null)
            {
                return NotFound();
            }

            DepartmentList = await _context.Departments.OrderBy(d => d.ParentID).ThenBy(d => d.Name).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Departments.FindAsync(id);

            if (Department != null)
            {
                _context.Departments.Remove(Department);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        public string GetParentName(int? id)
        {
            if (id == null) { return null; }
            var parentName = DepartmentList.FirstOrDefault(d => d.DepartmentID == id);
            string pN = parentName.Name;
            return pN;
        }
    }
}
