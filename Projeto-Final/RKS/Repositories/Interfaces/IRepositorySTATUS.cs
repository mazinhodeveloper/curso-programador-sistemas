using API.Models;

namespace API.Repositories
{
    public interface IRepositorySTATUS
    {
        Task<IEnumerable<STATUSRequestModel>> GetAllAsync();
        Task<STATUSRequestModel?> GetById(int idStatus);
        Task<int> Create(STATUSRequestModel model);
        Task<int> Update(int idStatus, STATUSRequestModel model);
        Task<int> Delete(int idStatus);
    }
}