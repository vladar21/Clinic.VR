using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClinicWebCore.Data;
using ClinicWebCore.Models;

namespace ClinicWebCore.Pages.DocSchedules
{
    public class DeleteModel : PageModel
    {
        private readonly ClinicWebCore.Data.ApplicationDbContext _context;

        public IList<Doc> Doc { get; set; }
        public IList<Patient> Patient { get; set; }

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

            Doc = await _context.Docs
               .Include(d => d.Contact)
               .OrderBy(d => d.Contact.LastName)
               .ToListAsync();

            Patient = await _context.Patients
                .Include(d => d.Contact)
                .OrderBy(d => d.Contact.LastName)
                .ToListAsync();

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

        public string GetDayOfWeek(DateTime? Day)
        {
            if (Day != null)
            {
                return Day.Value.DayOfWeek.ToString();
            }

            return null;
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

        public string GetPatientFIO(int? id)
        {
            if (id != null)
            {
                var pat = Patient.FirstOrDefault(dsch => dsch.PatientID == id);
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
