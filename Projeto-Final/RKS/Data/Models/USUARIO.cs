using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Models
{
    [Table("USUARIO")]
    public class USUARIO
    {
        [Key]
        public int idUsuario { get; set; }

        [Required]
        public int idAcl { get; set; }

        [Required]
        public int idStatus { get; set; }

        public int? idPerfil { get; set; }

        [Required]
        public string nome { get; set; } = string.Empty;

        [Required]
        public string CPF { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string senha { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string numeroTelefone { get; set; } = string.Empty;

        [Required]
        public DateTime dataNascimento { get; set; }

        public string? verificacao { get; set; }
    }
}
