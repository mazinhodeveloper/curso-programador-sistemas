using API.Data.Models;
//using API.Models;

namespace API.Repositories
{
    public interface IRepositoryUSUARIO
    {
        Task CreateUsuarioAsync(USUARIO usuario);
        Task<USUARIO?> GetUsuarioByTelefoneAsync(string numeroTelefone);
        Task<bool> UpdateSenhaAsync(string numeroTelefone, string novaSenhaHash);
    }
}