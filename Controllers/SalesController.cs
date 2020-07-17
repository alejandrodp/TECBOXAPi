using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TECBoxAPI.Database;
using TECBoxAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TECBoxAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {

        private LogDatabase context;

        public SalesController(LogDatabase db)
        {
            context = db;
        }

        // GET: api/<SalesController>
        [HttpGet]
        public async Task<IActionResult> Get()
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

            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "GET",
                ReqPath = "/Sales",
                Request = "",
                Response = JsonConvert.SerializeObject(new { result = "All sales.", items = s })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "All sales.", items = s });
        }
    }
}
