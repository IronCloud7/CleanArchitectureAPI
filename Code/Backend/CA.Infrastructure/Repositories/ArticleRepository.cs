using CA.Core.Entities;
using CA.Core.Interfaces;
using CA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly PatosaDbContext _context;

        public ArticleRepository(PatosaDbContext patosaDbContext) => _context = patosaDbContext;

        public async Task<MtArticle> GetArticleAsync(int id)
        {
            var article = await _context.MtArticles.FirstOrDefaultAsync(x => x.SkuId == id);
            return article;
        }

        public async Task<IEnumerable<MtArticle>> GetArticlesAsync()
        {
            var articles = await _context.MtArticles.ToListAsync();
            return articles;
        }
    }
}
