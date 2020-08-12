using System;
using System.Collections.Generic;

namespace Clinic.VR
{
    public class Department
    {
        public int DepartmentID { get; set; } //  id int
        public int? ParentID { get; set; } //  parent_id int
        public string Name { get; set; } //  name varchar(255)
        public DateTime CreatedAt { get; set; } //  created_at timestamp
        public DateTime UpdatedAt { get; set; } //  updated_at timestamp
        public List<Doc> Docs { get; set; }

        public Department()
        {
            Docs = new List<Doc>();
        }

    }
}