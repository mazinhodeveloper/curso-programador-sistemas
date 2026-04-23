using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class LoginRequestModelUsuario
    {
        [Required(ErrorMessage = "O número de telefone é obrigatório!")]
        public string numeroTelefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória!")]
        public string senha { get; set; } = string.Empty;
    }
}
