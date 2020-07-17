using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TECBoxAPI.Database;
using TECBoxAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TECBoxAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private LogDatabase context;

        public ProductsController(LogDatabase db)
        {
            context = db;
        }

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
        public async Task<IActionResult> Get()
        {
            var array = Enumerable.Range(0, names.Length - 1).Select(index => new Products
            {
                Nombre = names[index],
                Desc = description[index],
                barcode = barcodes[index],
                Descuento = discounts[index],
                Precio = prices[index],
                Cant = quantities[index],
                Impuesto = taxes[index]
            })
            .ToArray();

            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "GET",
                ReqPath = "/Products",
                Request = "",
                Response = JsonConvert.SerializeObject(new { result = "All products.", items = array })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "All products.", items = array });
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Products product)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "POST",
                ReqPath = "/Products",
                Request = JsonConvert.SerializeObject(product, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Prodcut with barcode " + product.barcode + " added." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Prodcut with barcode " + product.barcode + " added." });
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProduct value)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "PUT",
                ReqPath = "/Products",
                Request = JsonConvert.SerializeObject(value, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Product with barcode " + value.barcode_old + " was updated with the product with barcode " + value.barcode_new })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Product with barcode " + value.barcode_old + " was updated with the product with barcode " + value.barcode_new });
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "DELETE",
                ReqPath = "/Products",
                Request = JsonConvert.SerializeObject(id, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Product with barcode " + id + " deleted." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Product with barcode " + id + " deleted." });
        }
    }
}
