using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.VR
{
    public class Doc
    {
        [Column("id")]
        public int DocID { get; set; } //  id int
        [Column("contact_id")]
        public int ContactID { get; set; } //  contact_id int
        [Column("department_id")]
        public int DepartmentID { get; set; } //  departament_id int
        [Column("office", TypeName = "varchar(255)")]
        public string Office { get; set; } //  office varchar(255)
        [Column("hired_at", TypeName = "timestamp")]
        public DateTime HiredAt { get; set; } //  hired_at timestamp
        public ICollection<DepartmentDoc> DepartmentDocs { get; set; }
        public ICollection<DocSchedule> DocSchedules { get; set; }  

    }
}