using API.Models;

namespace API.Repositories
{
    public interface IRepositoryPERFIL
    {
        Task<IEnumerable<PERFILRequestModel>> GetAllAsync();
        Task<PERFILRequestModel?> GetById(int idPERFIL);
        Task<int> Create(PERFILRequestModel model);
        Task<int> Update(int idPerfil, PERFILRequestModel model);
        Task<int> Delete(int idPerfil);
    }
}