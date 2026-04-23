using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class RegisterRequestModelUsuario
    {
        [Required(ErrorMessage = "O nome é obrigatório!")]
        [StringLength(60)]
        public string nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório!")]
        [StringLength(14)]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime dataNascimento { get; set; }

        [Required(ErrorMessage = "O número de telefone é obrigatório!")]
        [StringLength(14)]
        public string numeroTelefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória!")]
        [MinLength(6)]
        public string senha { get; set; } = string.Empty;
    }
}
