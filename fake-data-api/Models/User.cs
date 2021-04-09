using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fake_data_api.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
    }
}
