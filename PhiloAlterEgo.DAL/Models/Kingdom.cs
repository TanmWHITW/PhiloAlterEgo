using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PhiloAlterEgo.DAL.Models
{
    public class Kingdom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public int Power { get; set; } = 0;

        [JsonIgnore]
        public List<Governor> Governors { get; set; } = new List<Governor>();
        public List<Guild> Guilds { get; set; } = new List<Guild>();
    }
}
