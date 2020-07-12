using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECBoxAPI.Models
{
    public class UpdatePackage
    {
        public int id_old { get; set; }
        public int id_new { get; set; }
        public string desc { get; set; }
        public byte estado { get; set; }
        public DateTime delivery { get; set; }
    }
}
