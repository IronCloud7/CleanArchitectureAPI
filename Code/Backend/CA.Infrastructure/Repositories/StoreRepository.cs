using CA.Core.Entities;
using CA.Core.Interfaces;
using CA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly PatosaDbContext _context;

        public StoreRepository(PatosaDbContext patosaDbContext) => _context = patosaDbContext;

        public async Task<MtStore> GetStoreAsync(int id)
        {
            var store = await _context.MtStore.FirstOrDefaultAsync(x => x.StoreId == id);
            return store;
        }

        public async Task<IEnumerable<MtStore>> GetStoresAsync()
        {
            var stores = await _context.MtStore.ToListAsync();

            return stores;
        }
    }
}
