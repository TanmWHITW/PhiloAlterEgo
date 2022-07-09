using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PhiloAlterEgo.DAL.Models
{
    public class Governor
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public ulong Id { get; set; }
        [MaxLength(16)]
        public string Name { get; set; } = string.Empty;

        public int KingdomId { get; set; }
        public Kingdom Kingdom { get; set; } = null!;

        public List<Stats> Stats { get; set; } = new List<Stats>();
    }
}
