using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TECBoxAPI.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RequestResponseLoggingDemo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : Controller
    {
        public LogDatabase context;

        public LoggingController(LogDatabase db)
        {
            context = db;
        }

        // GET: api/<LoggingController>
        public async Task<ViewResult> Logging()
        {
            return View(await context.LogRegs.ToListAsync());
        }
    }
}
