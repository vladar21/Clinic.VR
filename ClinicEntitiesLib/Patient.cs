using System;


namespace Clinic.VR
{
    public class Patient
    {
        public int PatientID { get; set; } //  id int

        public int ContactID { get; set; } //  contact_id int

        public string MedicalHistoryRegistoreNumber { get; set; } //  medical_history_registore_number varchar(255)
        public DateTime CreatedAt { get; set; } //  created_at timestamp
        public DateTime UpdatedAt { get; set; } //  updated_at timestamp
    }
}