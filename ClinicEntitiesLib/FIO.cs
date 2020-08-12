using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.VR
{
    public class FIO
    {
        [Column("id")]
        public int FIOID { get; set; } //  id int
        [Column("first_name", TypeName = "timestamp")]
        public string FirstName { get; set; } //  first_name varchar(255)
        [Column("middle_name", TypeName = "timestamp")]
        public string MiddleName { get; set; } //  middle_name varchar(255)
        [Column("sername", TypeName = "timestamp")]
        public string SurName { get; set; } //  surname varchar(255)

    }
}
