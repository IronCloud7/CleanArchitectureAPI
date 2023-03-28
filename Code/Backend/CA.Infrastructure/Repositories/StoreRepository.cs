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

        public async Task<Store> GetStoreAsync(int id)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(x => x.StoreId == id);
            return store;
        }

        public async Task<IEnumerable<Store>> GetStoresAsync()
        {
            var stores = await _context.Stores.ToListAsync();
            return stores;
        }
    }
}
