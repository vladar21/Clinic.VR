using System;
using System.Collections.Generic;

namespace Clinic.VR
{
    public class Doc
    {
        public int DocID { get; set; } //  id int
        public int ContactID { get; set; } //  contact_id int
        public int DepartmentID { get; set; } //  departament_id int
        public string Office { get; set; } //  office varchar(255)
        public DateTime HiredAt { get; set; } //  hired_at timestamp
        public ICollection<DocSchedule> DocSchedule { get; set; }
        public List<DepartmentDoc> DepartmentDocs { get; set; }

        public Doc()
        {
            DepartmentDocs = new List<DepartmentDoc>();
        }
    }
}