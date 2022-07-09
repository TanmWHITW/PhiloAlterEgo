using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhiloAlterEgo.DAL.Models
{
    public class Guild
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public ulong Id { get; set; }
        public string GuildName { get; set; } = string.Empty;

        public List<Kingdom> Kingdoms { get; set; } = new List<Kingdom>();
    }
}
