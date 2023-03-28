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

        public async Task AddArticle(Article article)
        {
            _context.Add(article);
            await _context.SaveChangesAsync();
        }

        public async Task<Article> GetArticleAsync(int id)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(x => x.SkuId == id);
            return article;
        }

        public async Task<IEnumerable<Article>> GetArticlesAsync()
        {
            var articles = await _context.Articles.ToListAsync();
            return articles;
        }
    }
}
