using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TECBoxAPI.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TECBoxAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RepartoController : ControllerBase
    {

        private LogDatabase context;

        public RepartoController(LogDatabase db)
        {
            context = db;
        }

        // GET: api/<RepartoController>
        [HttpGet]
        public async Task<IActionResult> Get()
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

            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "GET",
                ReqPath = "/Reparto",
                Request = "",
                Response = JsonConvert.SerializeObject(new { result = "All packages", paq = p })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();


            return Ok(new { result = "All packages", paq = p });
        }
    }
}
