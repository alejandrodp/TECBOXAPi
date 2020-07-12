using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TECBoxAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TECBoxAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
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

            return Ok(new { result = r });
        }

        // POST api/<RolesController>
        [HttpPost]
        public IActionResult Post([FromBody] Role role)
        {
            return Ok(role);
        }

        // PUT api/<RolesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateRole role)
        {
            return Ok(new { result = "Roles updated." });
        }

        // DELETE api/<RolesController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] Role role)
        {
            string response = "Roles deleted.";

            return Ok(new { result = response });
        }
    }
}
