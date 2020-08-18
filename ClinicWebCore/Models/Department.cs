using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebCore.Models
{
    public class Department
    {
        [Column("id")]
        public int DepartmentID { get; set; } //  id int
        [Column("parent_id")]
        public int? ParentID { get; set; } //  parent_id int
        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; } //  name varchar(255)
        [Column("created_at", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; } //  created_at timestamp
        [Column("updated_at", TypeName = "timestamp")]
        public DateTime UpdatedAt { get; set; } //  updated_at timestamp
        public ICollection<DepartmentDoc> DepartmentDocs { get; set; }
        public ICollection<DocSchedule> DocSchedules { get; set; }

    }
}