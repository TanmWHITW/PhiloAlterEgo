using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhiloAlterEgo.DAL.Models
{
    public class Stats
    {
        [Key]
        public int Id { get; set; }
        public int Power { get; set; }
        public int Kills { get; set; }
        public int T5Kills { get; set; }
        public int T4Kills { get; set; }
        public int Dead { get; set; }
        public int ResourcesGathered { get; set; }
        public int ResourcesShared { get; set; }
        public DateTime? ScannedDate { get; set; }

        public ulong GovernorId { get; set; }
        public Governor Governor { get; set; } = null!;
    }
}
