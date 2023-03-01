using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Service
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
    }
}
