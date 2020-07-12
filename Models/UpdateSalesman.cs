using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECBoxAPI.Models
{
    public class UpdateSalesman
    {
        public int cedula_old { get; set; }
        public int cedula_new { get; set; }
        public string nombre { get; set; }
    }
}
