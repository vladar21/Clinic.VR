using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicWebCore.Data;
using ClinicWebCore.Models;
using System.Globalization;

namespace ClinicWebCore.Pages.DocSchedules
{
    public class EditModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;

        public IList<Doc> Doc { get; set; }
        public IList<Contact> Contact { get; set; }
        public IList<Patient> Patient { get; set; }

        public EditModel(ClinicWebCore.Data.ApplicationDbContext context)
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
           //ViewData["DocID"] = new SelectList(_context.Docs, "DocID", "Office");
           //ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "MedicalHistoryRegistoreNumber");

            Doc = await _context.Docs
               .Include(d => d.Contact)
               .OrderBy(d => d.Contact.LastName)
               .ToListAsync();

            Contact = await _context.Contacts
                .Include(c => c.Address)
                .OrderBy(c => c.LastName)
                .ToListAsync();

            Patient = await _context.Patients
                .Include(p => p.Contact)
                .OrderBy(p => p.Contact.LastName)
                .ToListAsync();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
                       
                DocSchedule.UpdatedAt = DateTime.Now;
                DocSchedule.DocScheduleYear = (int?)DocSchedule.StartAppointmentAt.Value.Year;
                DocSchedule.WeekNumber = GetNumberOfWeek(DocSchedule.StartAppointmentAt.Value);
                DocSchedule.DayOfWeek = (byte?)DocSchedule.StartAppointmentAt.Value.DayOfWeek;            

            _context.Attach(DocSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocScheduleExists(DocSchedule.DocScheduleID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DocScheduleExists(int id)
        {
            return _context.DocSchedules.Any(e => e.DocScheduleID == id);
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
                if (likar == null) 
                { 
                    return null; 
                }
                return likar.Contact.LastName + ' ' + GetInitials(likar.Contact.FirstName, likar.Contact.MiddleName);
            }

            return null;
        }

        public string GetPatientFIO(int? id)
        {
            if (id != null)
            {
                var pat = Patient.FirstOrDefault(p => p.PatientID == id);
                if (pat == null)
                {
                    return null;
                }
                return pat.Contact.LastName + ' ' + GetInitials(pat.Contact.FirstName, pat.Contact.MiddleName);
            }

            return null;
        }

        public string GetMedicalHistory(int? id)
        {
            if (id != null)
            {
                var mH = Patient.FirstOrDefault(p => p.PatientID == id);
                if (mH == null)
                {
                    return null;
                }
                return mH.MedicalHistoryRegistoreNumber.ToString();
            }

            return null;
        }
    }
}
