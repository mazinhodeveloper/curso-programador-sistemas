using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Models
{
    [Table("STATUS")]
    public class STATUS
    {
        [Key]
        public int idStatus { get; set; }

        [Required]
        [MaxLength(20)]
        public string tipo { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string descricao { get; set; } = string.Empty;
    }
}
