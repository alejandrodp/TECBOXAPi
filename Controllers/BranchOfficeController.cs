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
    public class BranchOfficeController : ControllerBase
    {
        public LogDatabase context;
        public BranchOfficeController(LogDatabase db)
        {
            context = db;
        }

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
        public async Task<IActionResult> Get()
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


            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "GET",
                ReqPath = "/BranchOffice",
                Request = "",
                Response = JsonConvert.SerializeObject(new { result = "All workers.", items = array })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "All workers.", items = array });
        }

        // POST api/<BranchOfficeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BranchOffice value)
        {

            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "POST",
                ReqPath = "/BranchOffice",
                Request = JsonConvert.SerializeObject(value, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "BranchOffice with name " + value.nombre + " added." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "BranchOffice with name " + value.nombre + " added." });
        }

        // PUT api/<BranchOfficeController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateBranchOffice value)
        {

            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "PUT",
                ReqPath = "/BranchOffice",
                Request = JsonConvert.SerializeObject(value, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Branch office with name " + value.nombre_old + " was updated with the branch office with name " + value.nombre_new })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Branch office with name " + value.nombre_old + " was updated with the branch office with name " + value.nombre_new });
        }

        // DELETE api/<BranchOfficeController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] string name)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "DELETE",
                ReqPath = "/BranchOffice",
                Request = JsonConvert.SerializeObject(name, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Branch office with name " + name + " deleted." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();


            return Ok(new { result = "Branch office with name " + name + " deleted." });
        }
    }
}
