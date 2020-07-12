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
    public class SalesmenController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get([FromBody] Salesman salesman)
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

            return Ok(new { result = "All salesman", items = s });
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Salesman salesman)
        {
            return Ok(new { result = "Salesman witah cedula " + salesman.cedula + " added." });
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateSalesman salesman)
        {
            return Ok(new { result = "Salesman with cedula " + salesman.cedula_old + " updated." });
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(new { result = "salesman with cedula " + id + " deleted." });
        }
    }
}
