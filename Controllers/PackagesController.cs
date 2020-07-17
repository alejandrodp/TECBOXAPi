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
    public class PackagesController : ControllerBase
    {
        private LogDatabase context;

        public PackagesController(LogDatabase db)
        {
            context = db;
        }

        // GET: api/<PackagesController>
        [HttpGet]
        public async Task<IActionResult> Get()
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

            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "GET",
                ReqPath = "/Packages",
                Request = "",
                Response = JsonConvert.SerializeObject(new { result = "All packages", items = p })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "All packages", items = p });
        }

        // POST api/<PackagesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Package package)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "POST",
                ReqPath = "/Packages",
                Request = JsonConvert.SerializeObject(package, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Package with tracking id " + package.id + " added." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();


            return Ok(new { result = "Package with tracking id " + package.id + " added." });
        }

        // PUT api/<PackagesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePackage package)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "PUT",
                ReqPath = "/Packages",
                Request = JsonConvert.SerializeObject(package, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Package with tracking id " + package.id_old.ToString() + " was updated with the package with tracking id " + package.id_new.ToString() })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();


            return Ok(new { result = "Package with tracking id " + package.id_old.ToString() + " was updated with the package with tracking id " + package.id_new.ToString() });
        }

        // DELETE api/<PackagesController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "DELETE",
                ReqPath = "/Packages",
                Request = JsonConvert.SerializeObject(id, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Package with tracking id " + id + " deleted." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Package with tracking id " + id + " deleted." });
        }
    }
}
