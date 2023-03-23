using CA.Core.Entities;

namespace CA.Core.Interfaces
{
    public interface IStoreRepository
    {
        Task<IEnumerable<MtStore>> GetStoresAsync();
        Task<MtStore> GetStoreAsync(int id);
    }
}
