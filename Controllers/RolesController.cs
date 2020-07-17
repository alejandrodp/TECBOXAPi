using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TECBoxAPI.Database;
using TECBoxAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TECBoxAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        public LogDatabase context;

        public RolesController(LogDatabase db)
        {
            context = db;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public IActionResult Get()
        {
            string[] roles = new[]
            {
                "Administrador", "Repartidor", "Bodeguero"
            };

            string[] desc = new[]
            {
                "Rol de admin", "Rol de repartidor", "Rol de bodeguero"
            };

            string[] union1 =
            {
                roles[0],
                desc[0]
            };

            string[] union2 =
            {
                roles[1],
                desc[1]
            };

            string[] union3 =
            {
                roles[2],
                desc[2]
            };

            object[] r1 =
            {
                union1,
                union2,
                union3
            };

            string r = JsonConvert.SerializeObject(r1);

            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "GET",
                ReqPath = "/Roles",
                Request = "",
                Response = JsonConvert.SerializeObject(new { result = r })
            };
            context.Add(LogReg);
            context.SaveChanges();

            return Ok(new { result = r });
        }

        // POST api/<RolesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Role role)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "POST",
                ReqPath = "/Roles",
                Request = JsonConvert.SerializeObject(role, Formatting.Indented),
                Response = JsonConvert.SerializeObject(role, Formatting.Indented)
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(role);
        }

        // PUT api/<RolesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateRole role)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "PUT",
                ReqPath = "/Roles",
                Request = JsonConvert.SerializeObject(role, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Roles updated." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Roles updated." });
        }

        // DELETE api/<RolesController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Role role)
        {

            string response = "Roles deleted.";

            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "DELETE",
                ReqPath = "/Roles",
                Request = JsonConvert.SerializeObject(role, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = response })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = response });
        }
    }
}
