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
    public class RoutesController : ControllerBase
    {

        private LogDatabase context;

        public RoutesController(LogDatabase db)
        {
            context = db;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            object[] p =
            {
                new
                {
                    id = 235345,
                    distritos = new[] {"SJ", "CARTAGO"}
                },
                new
                {
                    id = 58234790,
                    distritos = new[] {"Alajuela", "Guana"}
                }
            };

            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "GET",
                ReqPath = "/Routes",
                Request = "",
                Response = JsonConvert.SerializeObject(new { result = "All routes.", items = p })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "All routes.", items = p });
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Route value)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "POST",
                ReqPath = "/Routes",
                Request = JsonConvert.SerializeObject(value, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Route with id " + value.id + " added." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Route with id " + value.id + " added." });
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateRoute value)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "PUT",
                ReqPath = "/Routes",
                Request = JsonConvert.SerializeObject(value, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Route with id " + value.id_old + " was updated with the route with id " + value.id_new })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Route with id " + value.id_old + " was updated with the route with id " + value.id_new });
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "DELETE",
                ReqPath = "/Routes",
                Request = JsonConvert.SerializeObject(id, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Route with id " + id + " deleted." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Route with id " + id + " deleted." });
        }
    }
}
