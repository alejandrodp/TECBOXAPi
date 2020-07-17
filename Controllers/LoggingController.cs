using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RequestResponseLoggingDemo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : Controller
    {
        // GET: api/<LoggingController>
        public IActionResult Logging()
        {
            MemoryStream ms = new MemoryStream();
            using (FileStream file = new FileStream("file.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
                ms.Write(bytes, 0, (int)file.Length);


            }


            string result = "Hello world! Time is: " + DateTime.Now;
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
            return File(ms.ToArray(), "text/plain");
        }
    }
}
