using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.VR
{
    public class DepartmentDoc
    {
        [Column("department_id")]
        public int DepartmentID { get; set; } // department_id int
        public Department Department { get; set; }
        [Column("doc_id")]
        public int DocID { get; set; } // doc_id int
        public Doc Doc { get; set; }

    }
}