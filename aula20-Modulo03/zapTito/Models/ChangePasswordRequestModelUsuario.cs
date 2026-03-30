/*--- ChangePasswordRequestModelUsuario.cs */
using System.ComponentModel.DataAnnotations; 

namespace zapTito.Models 
{
    public class ChangePasswordRequestModelUsuario 
    {
        [Required (ErrorMessage = "O número de telefone é obrigatório!")]
        public string numeroTelefone { get; set; } = string.Empty; 

        [Required (ErrorMessage = "O senha atual é obrigatório!")]
        public string senha { get; set; } = string.Empty; 
        
        [Required]
        [MinLength(8, ErrorMessage = "A nova senha deve conter no mínimo 8 caracteres!")]
        public string novaSenha { get; set; } = string.Empty; 
    }
}
