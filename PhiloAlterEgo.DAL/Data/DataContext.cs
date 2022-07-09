using Microsoft.EntityFrameworkCore;
using PhiloAlterEgo.DAL.Models;
using PhiloAlterEgo.DAL.ValueConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhiloAlterEgo.DAL.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Kingdom>? Kingdoms { get; set; }
        public DbSet<Governor>? Governors { get; set; }
        public DbSet<Stats>? Stats { get; set; }
        public DbSet<Guild>? Guilds { get; set; }
    }
}
