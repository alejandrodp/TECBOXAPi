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
    public class PackagesController : ControllerBase
    {
        // GET: api/<PackagesController>
        [HttpGet]
        public IActionResult Get()
        {
            object[] p ={ new
            {
                delivery = DateTime.Parse("2020-06-20"),
                compra = DateTime.Parse("2020-06-10"),
                description = "Paquete que alguien compró",
                multa = 3,
                state = 1,
                trackingID = 238947629
            } };

            return Ok(new { result = "All products", items = p });
        }

        // POST api/<PackagesController>
        [HttpPost]
        public IActionResult Post([FromBody] Package package)
        {
            return Ok(new { result = "Package with tracking id " + package.id + " added." });
        }

        // PUT api/<PackagesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdatePackage package)
        {
            return Ok(new { result = "Package with tracking id " + package.id_old.ToString() + " was updated with the package with tracking id " + package.id_new.ToString() });
        }

        // DELETE api/<PackagesController>/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(new { result = "Package with tracking id " + id + " deleted." });
        }
    }
}
