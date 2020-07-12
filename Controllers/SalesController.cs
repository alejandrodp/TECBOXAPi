using Microsoft.AspNetCore.Mvc;
using TECBoxAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TECBoxAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        // GET: api/<SalesController>
        [HttpGet]
        public IActionResult Get()
        {
            Sale[] s =
            {
                new Sale
                {
                    barcode = 52435234,
                    cant = 54,
                    desc = "Productos electrónicos",
                    descuento = 0,
                    impuesto = 0.13,
                    nombre = "Televisores",
                    precio = 2958376,
                    vendidos = 20
                },
                new Sale
                {
                    barcode = 673356756,
                    cant = 54,
                    desc = "Joyería",
                    descuento = 0,
                    impuesto = 0.13,
                    nombre = "Collares",
                    precio = 2958376,
                    vendidos = 20
                }
            };

            return Ok(new { result = "All sales.", items = s });
        }
    }
}
