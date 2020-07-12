using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECBoxAPI.Models
{
    public class UpdateClient
    {
        public int cedula_old { get; set; }
        public int cedula_new { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public int casillero { get; set; }
        public int habitacion { get; set; }
        public int celular { get; set; }
        public string usuario { get; set; }
        public string pass { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string otras { get; set; }
    }
}
