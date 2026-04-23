using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Models
{
    [Table("ACL")]
    public class ACL
    {
        [Key]
        public int idACL { get; set; }

        [Required]
        [MaxLength(20)]
        public string tipo { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string descricao { get; set; } = string.Empty;
    }
}
