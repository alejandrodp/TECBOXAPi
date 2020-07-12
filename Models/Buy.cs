using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECBoxAPI.Models
{
    public class Buy
    {
        public int cedula { get; set; }
        public int[] barcodes { get; set; }
        public int price { get; set; }
        public double descuento { get; set; }
        public double impuesto { get; set; }
    }
}
