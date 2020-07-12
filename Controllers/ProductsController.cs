using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TECBoxAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TECBoxAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly int[] barcodes = new[]
        {
            23023951, 23023952, 23023953, 23023954, 23023955
        };
        private static readonly int[] quantities = new[]
        {
            2, 2, 4, 3, 6
        };
        private static readonly int[] prices = new[]
        {
            5000, 4000, 6000, 8000, 10000
        };
        private static readonly double[] taxes = new[]
        {
            0.4, 0.45, 0.4, 0.45, 0.45
        };
        private static readonly double[] discounts = new[]
        {
            0.4, 0.45, 0.4, 0.45, 0.45
        };
        private static readonly string[] names = new[]
        {
            "cereal", "arroz", "leche", "agua", "frutas"
        };
        private static readonly string[] description = new[]
        {
            "cereal", "arroz", "leche", "agua", "frutas"
        };
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            var array = Enumerable.Range(0, names.Length - 1).Select(index => new Products
            {
                nombre = names[index],
                desc = description[index],
                barcode = barcodes[index],
                descuento = discounts[index],
                precio = prices[index],
                cant = quantities[index],
                impuesto = taxes[index]
            })
            .ToArray();

            return Ok(new { result = "All products.", items = array });
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Products product)
        {
            return Ok(new { result = "Prodcut with barcode " + product.barcode + " added." });
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateProduct value)
        {
            return Ok(new { result = "Product with barcode " + value.barcode_old + " was updated with the product with barcode " + value.barcode_new });
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(new { result = "Product with barcode " + id + " deleted." });
        }
    }
}
