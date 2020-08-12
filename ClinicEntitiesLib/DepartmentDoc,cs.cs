namespace Clinic.VR
{
    public class DepartmentDoc
    {
        public int DepartmentID { get; set; } // department_id int
        public Department Department { get; set; }

        public int DocID { get; set; } // doc_id int
        public Doc Doc { get; set; }

    }
}