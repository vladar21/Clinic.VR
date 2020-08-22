using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClinicWebCore.Data;
using ClinicWebCore.Models;

namespace ClinicWebCore.Pages.Docs
{
    public class CreateModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;

        public IList<Department> DepartmentList { get; set; }
        public IList<Contact> ContactList { get; set; }

        public CreateModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ContactID"] = new SelectList(_context.Contacts, "ContactID", "FirstName");

            DepartmentList = _context.Departments.OrderBy(d => d.ParentID).ThenBy(d => d.Name).ToList();

            ContactList = _context.Contacts.OrderBy(c => c.LastName).ToList();

            return Page();
        }

        [BindProperty]
        public Doc Doc { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Docs.Add(Doc);
            await _context.SaveChangesAsync();

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
