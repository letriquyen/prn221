using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Invoice
    {
        public string rent { get; set; } = "";
        public string water { get; set; } = "";
        public string electicity { get; set; } = "";
        public string management { get; set; } = "";
        public string parking { get; set; } = "";
        public string email { get; set; } = "";

    }
}
