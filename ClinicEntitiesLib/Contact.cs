using System;
using System.Collections.Generic;

namespace Clinic.VR
{
    public class Contact
    {
        public int ContactID { get; set; } //  id int
        public int FIOID { get; set; } //  fio_id int
        public string Phone { get; set; } //  phone varchar(255)
        public string Email { get; set; } //  email varchar(255)
        public int AddressID { get; set; } //  address_id int
        public DateTime CreatedAt { get; set; } //  created_at timestamp
        public DateTime UpdatedAt { get; set; } //  updated_at timestamp
        public ICollection<Doc> Docs { get; set; }

    }
}