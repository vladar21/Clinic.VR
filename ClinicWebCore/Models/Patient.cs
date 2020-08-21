using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebCore.Models
{
    public class Patient
    {
        [Column("id"), Display(Name = "ID")]
        public int PatientID { get; set; } //  id int       
        [Column("contact_id")]
        public int ContactID { get; set; } //  contact_id int        
        public Contact Contact { get; set; }
        [Column("medical_history_registore_number"), Display(Name = "MedicalHistory")]
        public string MedicalHistoryRegistoreNumber { get; set; } 
        //  medical_history_registore_number varchar(255)
        [Column("created_at", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; } //  created_at timestamp
        [Column("updated_at", TypeName = "timestamp")]
        public DateTime UpdatedAt { get; set; } //  updated_at timestamp
        public ICollection<DocSchedule> DocSchedules { get; set; }
    }
}