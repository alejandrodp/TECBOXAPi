using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECBoxAPI.Models
{
    public class UpdateRoute
    {
        public int id_old { get; set; }
        public int id_new { get; set; }
        public string[] distritos { get; set; }
    }
}
