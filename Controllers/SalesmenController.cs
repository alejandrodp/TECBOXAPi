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
    public class SalesmenController : ControllerBase
    {

        private LogDatabase context;

        public SalesmenController(LogDatabase db)
        {
            context = db;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get([FromBody] Salesman salesman)
        {
            Salesman[] s =
            {
                new Salesman
                {
                    nombre = "Carl",
                    cedula = 234564
                },
                new Salesman
                {
                    nombre = "John",
                    cedula = 653464
                }
            };

            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "GET",
                ReqPath = "/Salesmen",
                Request = "",
                Response = JsonConvert.SerializeObject(new { result = "All salesman", items = s })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "All salesman", items = s });
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Salesman salesman)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "POST",
                ReqPath = "/Salesmen",
                Request = JsonConvert.SerializeObject(salesman, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Salesman witah cedula " + salesman.cedula + " added." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Salesman witah cedula " + salesman.cedula + " added." });
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateSalesman salesman)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "PUT",
                ReqPath = "/Salesmen",
                Request = JsonConvert.SerializeObject(salesman, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Salesman with cedula " + salesman.cedula_old + " updated." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Salesman with cedula " + salesman.cedula_old + " updated." });
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "DELETE",
                ReqPath = "/Salesmen",
                Request = JsonConvert.SerializeObject(id, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "salesman with cedula " + id + " deleted." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "salesman with cedula " + id + " deleted." });
        }
    }
}
