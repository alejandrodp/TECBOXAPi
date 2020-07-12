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
    public class RoutesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
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

            return Ok(new { result = "All routes.", items = p });
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Route value)
        {
            return Ok(new { result = "Route with id " + value.id + " added." });
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateRoute value)
        {
            return Ok(new { result = "Route with id " + value.id_old + " was updated with the route with id " + value.id_new });
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(new { result = "Route with id " + id + " deleted." });
        }
    }
}
