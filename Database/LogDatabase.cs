using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECBoxAPI.Database
{
    public class LogDatabase : DbContext
    {
        public LogDatabase(DbContextOptions<LogDatabase> options)
            : base(options) { }

        public DbSet<LogReg> LogRegs { get; set; }
    }
}
