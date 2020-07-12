using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECBoxAPI.Models
{
    public class UpdateProduct
    {
        public int barcode_old { get; set; }
        public int barcode_new { get; set; }
        public string nombre { get; set; }
        public string desc { get; set; }
        public int cant { get; set; }
        public int precio { get; set; }
        public double impuesto { get; set; }
        public double descuento { get; set; }
    }
}
