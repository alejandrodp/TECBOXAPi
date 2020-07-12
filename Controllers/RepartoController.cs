using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TECBoxAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RepartoController : ControllerBase
    {
        // GET: api/<RepartoController>
        [HttpGet]
        public IActionResult Get()
        {
            object[] p =
            {
                new
                {
                    id = 5347895,
                    desc = "Paquets extraños",
                    estado = 1,
                    compra = "2020-03-02",
                    entrega = "2020-07-02",
                    multas = 1,
                    ced = 562783
                },
                new
                {
                    id = 627549789,
                    desc = "Comida",
                    estado = 2,
                    compra = "2020-03-02",
                    entrega = "2020-07-02",
                    multas = 1,
                    ced = 562783
                }
            };


            return Ok(new { result = "All packages", paq = p });
        }
    }
}
