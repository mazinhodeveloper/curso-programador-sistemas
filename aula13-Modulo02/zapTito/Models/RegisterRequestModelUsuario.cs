/* --- Models/RegisterRequestModelUsuario.cs */
using System.ComponentModel.DataAnnotations;

namespace zapTito.Models
{
    public class RegisterRequestModelUsuario
    {
        [Required (ErrorMessage = "O nome é obrigatório!")]
        public string nome { get; set; } = string.Empty;
        [Required (ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime dataNascimento { get; set; }
        [Required(ErrorMessage = "O número de telefone é obrigatório!")]
        public string numeroTelefone { get; set; } = string.Empty;
        [Required (ErrorMessage = "A senha é obrigatória!")]
        public string senha { get; set; } = string.Empty;
    }
}
