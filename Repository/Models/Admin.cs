using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Admin
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
    }
}
