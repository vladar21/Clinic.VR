using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClinicWebCore.Data;
using ClinicWebCore.Models;
using SQLitePCL;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebCore.Pages.DocSchedules
{
    public class CreateModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;
        public IList<Doc> Doc { get; set; }
        public IList<Contact> Contact { get; set; }

        public CreateModel(ClinicWebCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DocID"] = new SelectList(_context.Docs, "DocID", "Office");
            ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "MedicalHistoryRegistoreNumber");

            Doc = _context.Docs
                .Include(d => d.Contact)
                .OrderBy(d => d.Contact.LastName)
                .ToList();                     

            Contact = _context.Contacts
                .Include(d => d.Address)
                .OrderBy(d => d.LastName)
                .ToList();

            return Page();
        }

        [BindProperty]
        public DocSchedule DocSchedule { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            if (DocSchedule.StartAppointmentAt != null)
            {
                DocSchedule.CreatedAt = DateTime.Now;
                DocSchedule.UpdatedAt = DateTime.Now;
                DocSchedule.DocScheduleYear = (int?)DocSchedule.StartAppointmentAt.Value.Year;
                DocSchedule.WeekNumber = GetNumberOfWeek(DocSchedule.StartAppointmentAt.Value);
                DocSchedule.DayOfWeek = (byte?)DocSchedule.StartAppointmentAt.Value.DayOfWeek;
                DocSchedule.PatientID = null;
            }           

            _context.DocSchedules.Add(DocSchedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public byte GetNumberOfWeek(DateTime inputDate)
        {            
            var d = inputDate;
            CultureInfo cul = CultureInfo.CurrentCulture;

            var firstDayWeek = cul.Calendar.GetWeekOfYear(
                d,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday);

            byte weekNum = (byte)cul.Calendar.GetWeekOfYear(d, CalendarWeekRule.FirstDay, firstDayOfWeek: DayOfWeek.Monday);

            return weekNum;
        }

        // Получаем инициалы
        public string GetInitials(string FirstName, string MiddleName)
        {
            return FirstName.Substring(0, 1) + '.' + MiddleName.Substring(0, 1) + '.';
        }

        public string GetDocFIO(int? id)
        {
            if (id != null)
            {
                var likar = Doc.FirstOrDefault(d => d.DocID == id);
                return likar.Contact.LastName + ' ' + GetInitials(likar.Contact.FirstName, likar.Contact.MiddleName);
            }

            return null;
        }


    }
}
