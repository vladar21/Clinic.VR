using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClinicWebCore.Data;
using ClinicWebCore.Models;

namespace ClinicWebCore.Pages.Docs
{
    public class DeleteModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;
        public IList<Department> DepartmentList { get; set; }
        public IList<Contact> ContactList { get; set; }

        public DeleteModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doc Doc { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doc = await _context.Docs
                .Include(d => d.Contact).FirstOrDefaultAsync(m => m.DocID == id);

            if (Doc == null)
            {
                return NotFound();
            }

            DepartmentList = await _context.Departments.OrderBy(d => d.ParentID).ThenBy(d => d.Name).ToListAsync();

            ContactList = await _context.Contacts.OrderBy(c => c.LastName).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doc = await _context.Docs.FindAsync(id);

            if (Doc != null)
            {
                _context.Docs.Remove(Doc);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        // Получаем инициалы
        public string GetInitials(string FirstName, string MiddleName)
        {
            return FirstName.Substring(0, 1) + '.' + MiddleName.Substring(0, 1) + '.';
        }

        // Получаем название департамента
        public string GetDepartamentName(int? id)
        {
            if (id == null) { return null; }
            var departamentName = DepartmentList.FirstOrDefault(d => d.DepartmentID == id);
            string dN = departamentName.Name;
            return dN;
        }
    }
}
