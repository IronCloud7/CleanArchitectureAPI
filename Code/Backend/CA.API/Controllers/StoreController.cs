using CA.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository) => _storeRepository = storeRepository;


        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            var _stores = await _storeRepository.GetStoresAsync();
            return Ok(_stores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStore(int id)
        {
            var _store = await _storeRepository.GetStoreAsync(id);
            return Ok(_store);
        }
    }
}
