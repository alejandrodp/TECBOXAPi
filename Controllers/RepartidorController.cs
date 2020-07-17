using System;
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
    public class RepartidorController : ControllerBase
    {
        private LogDatabase context;

        public RepartidorController(LogDatabase db)
        {
            context = db;
        }

        // POST api/<RepartidorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reparto value)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "POST",
                ReqPath = "/Repartidor",
                Request = JsonConvert.SerializeObject(value, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Paquete cambiado" })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Paquete cambiado" });
        }
    }
}
