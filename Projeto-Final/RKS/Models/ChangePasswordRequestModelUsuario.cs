using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ChangePasswordRequestModelUsuario
    {
        [Required]
        public string numeroTelefone { get; set; } = string.Empty;

        [Required]
        public string senha { get; set; } = string.Empty;        // senha atual

        [Required]
        [MinLength(6, ErrorMessage = "A nova senha deve ter no mínimo 6 caracteres!")]
        public string novaSenha { get; set; } = string.Empty;
    }
}