using System;

namespace Clinic.VR
{
    public class MedicalHistory
    {
        public int MedicalHistoryID { get; set; } //  id int
        public string HistoryRegistoreNumber { get; set; } //  history_registore_number varchar(255)
        public DateTime CreatedAt { get; set; } //  created_at timestamp
        public DateTime UpdatedAt { get; set; } //  updated_at timestamp

    }
}
