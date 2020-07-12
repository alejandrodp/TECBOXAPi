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
    public class RepartidorController : ControllerBase
    {
        // POST api/<RepartidorController>
        [HttpPost]
        public IActionResult Post([FromBody] Reparto value)
        {
            return Ok(new { result = "Paquete cambiado" });
        }
    }
}
