using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECBoxAPI.Models
{
    public class Package
    {
        public int id { get; set; }
        public string desc { get; set; }
        public byte estado { get; set; }
        public DateTime entrega { get; set; }
    }
}
