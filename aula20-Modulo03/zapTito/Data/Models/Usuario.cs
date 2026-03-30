/* --- Data/Models/Usuario.cs */
using System;

namespace zapTito.Data.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public int idACL { get; set; }
        public int idStatus { get; set; }
        public int idPerfil { get; set; }
        public string nome { get; set; } = string.Empty;
        public DateTime dataNascimento { get; set; }
        public string numeroTelefone { get; set; } = string.Empty;
        public string senha { get; set; } = string.Empty;
        public string verificacao { get; set; } = string.Empty;
    }
}
