using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Models
{
    [Table("PERFIL")]
    public class PERFIL
    {
        [Key]
        public int idPerfil { get; set; }

        [Required]
        [MaxLength(20)]
        public string tipo { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string descricao { get; set; } = string.Empty;
    }
}
