using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECBoxAPI.Models
{
    public class BranchOffice
    {
        public string nombre { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; } 
        public string distrito { get; set; }
        public string otras { get; set; }
        public int telefono { get; set; }
    }
}
