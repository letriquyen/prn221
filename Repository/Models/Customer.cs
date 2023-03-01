using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Customer
    {
        public Customer()
        {
            RentContracts = new HashSet<RentContract>();
        }

        public string Id { get; set; }
        public string Address { get; set; }
        public string CitizenId { get; set; }
        public DateTime? DateJoin { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }

        public virtual ICollection<RentContract> RentContracts { get; set; }
    }
}
