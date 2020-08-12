namespace Clinic.VR
{
    public class Address
    {
        public int AddressID { get; set; } //  id int
        public int ZipCode { get; set; } //  zipcode varchar(255)
        public string Country { get; set; } //  country varchar(255)
        public string Region { get; set; } //  region varchar(255)
        public string Locality { get; set; } //  locality varchar(255)
        public string Street { get; set; } //  street varchar(255)
        public string House { get; set; } //  house varchar(255)
        public string Apartment { get; set; } //  apartment varchar(255)

    }
}
