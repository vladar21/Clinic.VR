using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebCore.Models
{
    public class Address
    {
        [Column("id"), Display(Name = "ID")]
        public int AddressID { get; set; } //  id int
        [Column("zipcode", TypeName = "varchar(255)")]
        public string ZipCode { get; set; } //  zipcode varchar(255)
        [Column("country", TypeName = "varchar(255)")]
        public string Country { get; set; } //  country varchar(255)
        [Column("region", TypeName = "varchar(255)")]
        public string Region { get; set; } //  region varchar(255)
        [Column("locality", TypeName = "varchar(255)")]
        public string Locality { get; set; } //  locality varchar(255)
        [Column("street", TypeName = "varchar(255)")]
        public string Street { get; set; } //  street varchar(255)
        [Column("house", TypeName = "varchar(255)")]
        public string House { get; set; } //  house varchar(255)
        [Column("apartment", TypeName = "varchar(255)")]
        public string Apartment { get; set; } //  apartment varchar(255)
        public ICollection<Contact> Contacts { get; set; }
        
    }
}
