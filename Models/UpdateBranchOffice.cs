using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECBoxAPI.Models
{
    public class UpdateBranchOffice
    {
        public string nombre_old { get; set; }
        public string nombre_new { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; } 
        public string distrito { get; set; }
        public int telefono { get; set; }
    }
}
