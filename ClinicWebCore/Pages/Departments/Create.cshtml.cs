using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClinicWebCore.Data;
using ClinicWebCore.Models;

namespace ClinicWebCore.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;
        public IList<Department> DepartmentList { get; set; }

        public CreateModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            DepartmentList = _context.Departments.OrderBy(d => d.ParentID).ThenBy(d => d.Name).ToList();

            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();

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
