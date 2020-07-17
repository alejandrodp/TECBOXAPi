using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TECBoxAPI.Database;
using TECBoxAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TECBoxAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private LogDatabase context;

        public WorkersController(LogDatabase db)
        {
            context = db;
        }

        private static readonly int[] id = new[]
        {
            1, 2, 3, 4, 5
        };
        private static readonly int[] monthSalary = new[]
        {
            160000, 240000, 32000, 40000, 48000
        };
        private static readonly int[] hourSalary = new[]
        {
            160000 / (40 * 4), 240000 / (40 * 4), 32000 / (40 * 4), 40000 / (40 * 4), 48000 / (40 * 4)
        };
        private static readonly string[] firstName = new[]
        {
            "Alejandro", "José", "Michelle", "Hércules", "Milton"
        };
        private static readonly string[] lastName = new[]
        {
            "Fernández", "José", "Scott", "Poirot", "Villegas"
        };
        private static readonly string[] birthdate = new[]
        {
            "12 de junio del 1999", "14 de febrero del 1999", "5 de enero del 1999", "5 de noviembre del 1999", "13 de abril del 1999"
        };
        private static readonly string[] password = new[]
        {
            "alefer102", "josejoserocker", "pudding", "bestdetectivever", "ceconnection"
        };
        private static readonly string[] firstdate = new[]
        {
            "12 de junio del 20012", "14 de febrero del 2024", "5 de enero del 2020", "5 de noviembre del 2019", "13 de abril  del 2010"
        };
        // GET: api/<WorkersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Worker[] response = new Worker[5];

            for (int i = 0; i < response.Length; i++)
            {
                response[i] = new Worker
                {
                    Cedula = id[i],
                    nacimiento = birthdate[i],
                    ingreso = firstdate[i],
                    nombre = firstName[i],
                    salario_h = hourSalary[i],
                    apellidos = lastName[i],
                    salario_m = monthSalary[i],
                    pass = password[i]
                };
            }


            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "GET",
                ReqPath = "/Workers",
                Request = "",
                Response = JsonConvert.SerializeObject(new { result = 200, items = response })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();


            return Ok(new { result = 200, items = response });
        }

        // POST api/<WorkersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Worker values)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "POST",
                ReqPath = "/Workers",
                Request = JsonConvert.SerializeObject(values, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Worker " + values.Cedula + " added." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Worker " + values.Cedula + " added." });
        }

        // PUT api/<WorkersController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateWorker worker)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "PUT",
                ReqPath = "/Workers",
                Request = JsonConvert.SerializeObject(worker, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Worker with id " + worker.cedula_old + " was updated with the worker with id " + worker.cedula_new })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();


            return Ok(new { result = "Worker with id " + worker.cedula_old + " was updated with the worker with id " + worker.cedula_new });
        }

        // DELETE api/<WorkersController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var LogReg = new LogReg
            {
                id = Guid.NewGuid(),
                HttpMethod = "DELETE",
                ReqPath = "/Workers",
                Request = JsonConvert.SerializeObject(id, Formatting.Indented),
                Response = JsonConvert.SerializeObject(new { result = "Worker with id " + id + " deleted." })
            };
            context.Add(LogReg);
            await context.SaveChangesAsync();

            return Ok(new { result = "Worker with id " + id + " deleted." });
        }
    }
}
