using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClinicWebCore.Data;
using ClinicWebCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicWebCore.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;

        public IndexModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; }        

        public async Task OnGetAsync()
        {
            Department = await _context.Departments.OrderBy(d => d.ParentID).ThenBy(d => d.Name).ToListAsync();          

        }

        public string GetParentName(int? id)
        {
            if (id == null) { return null; }
            var parentName = Department.FirstOrDefault(d => d.DepartmentID == id);
            string pN = parentName.Name;
            return pN;
        }
    }
}
