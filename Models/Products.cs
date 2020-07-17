using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECBoxAPI.Models
{
    public class Products
    {
        public int barcode { get; set; }
        public string Nombre { get; set; }
        public string Desc { get; set; }
        public int Cant { get; set; }
        public int Precio { get; set; }
        public double Impuesto { get; set; }
        public double Descuento { get; set; }
    }
}
