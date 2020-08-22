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
    public class DetailsModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;
        public IList<Department> DepartmentList { get; set; }
        public IList<Contact> ContactList { get; set; }

        public DetailsModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
