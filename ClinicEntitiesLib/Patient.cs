using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.VR
{
    public class Patient
    {
        [Column("id")]
        public int PatientID { get; set; } //  id int

        [Column("contact_id")]
        public int ContactID { get; set; } //  contact_id int
        [Column("medical_history_registore_number", TypeName = "timestamp")]

        public string MedicalHistoryRegistoreNumber { get; set; } //  medical_history_registore_number varchar(255)
        [Column("created_at", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; } //  created_at timestamp
        [Column("updated_at", TypeName = "timestamp")]
        public DateTime UpdatedAt { get; set; } //  updated_at timestamp
    }
}