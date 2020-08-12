using System;

namespace Clinic.VR
{
    public class DocSchedule
    {
        public int DocScheduleID { get; set; } //  id int
        public int? PatientID { get; set; } // patient_id int
        public Patient Patient { get; set; }
        public bool IsVisitPatient { get; set; } // is_visit_patient tinyint
        public int? DocID { get; set; } //  doc_id int
        public Doc Doc { get; set; }
        public int? DepartmentID { get; set; } //  department_id int
        public Department Department { get; set; }
        public int? DocScheduleYear { get; set; } //  doc_schedule_year int
        public int? WeekNumber { get; set; } //  week_number int
        public int? WeekDay { get; set; } //  week_day int
        public DateTime StartAppointmentAt { get; set; } //  start_appointment_at timestamp
        public DateTime FinishAppointmentAt { get; set; } //  finish_appointment_at timestamp
        public DateTime CreatedAt { get; set; } //  created_at timestamp
        public DateTime UpdatedAt { get; set; } //  updated_at timestamp

    }
}
