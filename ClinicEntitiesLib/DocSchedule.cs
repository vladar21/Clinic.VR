using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.VR
{
    public class DocSchedule
    {
        [Column("id")]
        public int DocScheduleID { get; set; } //  id int
        [Column("patient_id")]
        public int? PatientID { get; set; } // patient_id int
        public Patient Patient { get; set; }
        [Column("is_visit_patient", TypeName = "tinyint")]
        public bool IsVisitPatient { get; set; } // is_visit_patient tinyint
        [Column("doc_id")]
        public int? DocID { get; set; } //  doc_id int
        public Doc Doc { get; set; }
        [Column("department_id")]
        public int? DepartmentID { get; set; } //  department_id int
        public Department Department { get; set; }
        [Column("doc_schedule_year")]
        public int? DocScheduleYear { get; set; } //  doc_schedule_year int
        [Column("week_number")]
        public int? WeekNumber { get; set; } //  week_number int
        [Column("week_day")]
        public int? WeekDay { get; set; } //  week_day int
        [Column("start_appointment_at", TypeName = "timestamp")]
        public DateTime StartAppointmentAt { get; set; } //  start_appointment_at timestamp
        [Column("finish_appointment_at", TypeName = "timestamp")]
        public DateTime FinishAppointmentAt { get; set; } //  finish_appointment_at timestamp
        [Column("created_at", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; } //  created_at timestamp
        [Column("updated_at", TypeName = "timestamp")]
        public DateTime UpdatedAt { get; set; } //  updated_at timestamp

    }
}
