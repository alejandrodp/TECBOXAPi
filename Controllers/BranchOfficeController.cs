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
    public class BranchOfficeController : ControllerBase
    {
        private static readonly string[] name = new[]
        {
            "Alejandro", "José", "Michelle", "Hércules", "Milton"
        };
        private static readonly string[] province = new[]
        {
            "Alejandro", "José", "Michelle", "Hércules", "Milton"
        };
        private static readonly string[] state = new[]
        {
            "Alejandro", "José", "Michelle", "Hércules", "Milton"
        };
        private static readonly string[] district = new[]
        {
            "Alejandro", "José", "Michelle", "Hércules", "Milton"
        };
        private static readonly int[] phones = new[]
        {
            23023951, 23023952, 23023953, 23023954, 23023955
        };
        // GET: api/<BranchOfficeController>
        [HttpGet]
        public IActionResult Get()
        {
            var array =  Enumerable.Range(0, name.Length - 1).Select(index => new BranchOffice
            {
                nombre = name[index],
                provincia = province[index],
                canton = state[index],
                distrito = district[index],
                telefono = phones[index]
            })
            .ToArray();

            return Ok(new { result = "Äll workers.", items = array });
        }

        // POST api/<BranchOfficeController>
        [HttpPost]
        public IActionResult Post([FromBody] BranchOffice value)
        {
            return Ok(new { result = "BranchOffice with name " + value.nombre + " added." });
        }

        // PUT api/<BranchOfficeController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateBranchOffice value)
        {
            return Ok(new { result = "Branch office with name " + value.nombre_old + " was updated with the branch office with name " + value.nombre_new });
        }

        // DELETE api/<BranchOfficeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] string name)
        {
            return Ok(new { result = "Branch office with name " + name + " deleted." });
        }
    }
}
