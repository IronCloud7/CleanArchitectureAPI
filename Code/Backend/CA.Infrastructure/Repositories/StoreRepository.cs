using CA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Repositories
{
    public class StoreRepository
    {
        public IEnumerable<Store> GetStores() 
        {
            var _stores = Enumerable.Range(1, 50).Select(x => new Store
            {
                store_id = x,
                name = $"Store {x}",
                account_id = 1,
                address = $"Address for store {x}",
                creationdate = DateTime.UtcNow,
                updatedate = DateTime.UtcNow,

            });

            return _stores;
        }
    }
}
