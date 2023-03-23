using CA.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository) => _articleRepository = articleRepository;

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var _articles = await _articleRepository.GetArticlesAsync();
            return Ok(_articles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var _article = await _articleRepository.GetArticleAsync(id);
            return Ok(_article);
        }
    }
}
