using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TECBoxAPI.Database
{
    public class LogReg
    {
        [Key]
        public Guid id { get; set; }
        public string HttpMethod { get; set; }
        public string ReqPath { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }

    }
}
