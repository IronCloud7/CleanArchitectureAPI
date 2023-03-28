using AutoMapper;
using CA.Core.DTO;
using CA.Core.Entities;
using CA.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleController(IMapper mapper, IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var _articles = await _articleRepository.GetArticlesAsync();
            var _articlesDTO = _mapper.Map<IEnumerable<ArticleDTO>>(_articles);
            return Ok(_articlesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var _article = await _articleRepository.GetArticleAsync(id);
            var _articleDTO = _mapper.Map<ArticleDTO>(_article);
            return Ok(_articleDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ArticleDTO obj)
        {
            var article = _mapper.Map<Article>(obj);
            article.Creationdate = DateTime.Now;
            await _articleRepository.AddArticle(article);
            return Ok(obj);
        }
    }
}
