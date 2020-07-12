using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECBoxAPI.Models
{
    public class UpdateWorker
    {
        public int cedula_old { get; set; }
        public int cedula_new { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string nacimiento { get; set; }
        public string ingreso { get; set; }
        public int salario_m { get; set; }
        public int salario_h { get; set; }
        public string pass { get; set; }
    }
}
