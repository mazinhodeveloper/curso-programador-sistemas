using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class PERFILRequestModel
    {
        public int idPerfil { get; set; }  // 🔥 IMPORTANTE PARA CRUD 
        
        [Required(ErrorMessage = "O campo 'Tipo' é obrigatório.")]
        [StringLength(20, ErrorMessage = "O 'Tipo' deve ter no máximo 20 caracteres.")]
        public string tipo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo 'Descrição' é obrigatório.")]
        [StringLength(100, ErrorMessage = "A 'Descrição' deve ter no máximo 100 caracteres.")]
        public string descricao { get; set; } = string.Empty;
    }
}
