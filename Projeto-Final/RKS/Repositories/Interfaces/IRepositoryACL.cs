using API.Models;

namespace API.Repositories
{
    public interface IRepositoryACL
    {
        Task<IEnumerable<ACLRequestModel>> GetAllAsync();
        Task<ACLRequestModel?> GetById(int idACL);
        Task<int> Create(ACLRequestModel model);
        Task<int> Update(int idACL, ACLRequestModel model);
        Task<int> Delete(int idACL);
    }
}