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
    public class ComprasController : ControllerBase
    {
        private LogDatabase context;

        public ComprasController(LogDatabase db)
        {
            context = db;
        }

        // POST api/<ComprasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Buy value)
        {

            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "POST",
                ReqPath = "/Compras",
                Request = JsonConvert.SerializeObject(value, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Compra realizada." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Compra realizada." });
        }
    }
}
