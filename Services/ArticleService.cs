
using LVS.Data;
using LVS.Models;
using Microsoft.EntityFrameworkCore;

namespace LVS.Services
{
    public class ArticleService
    {
        private readonly WarehouseDbContext _context;

        public List<Article> Articles { get; private set; }

        public ArticleService(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<Article>> GetAllAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article?> GetByIdAsync(int id)
        {
            Article? article = await _context.Articles.FindAsync(id);  
            
            return article;
        }

        public async Task<List<Article>> SearchAsync(string searchTerm)
        {
            return await _context.Articles.Where(a => a.ArticleNumber.Contains(searchTerm) || a.ArticleName.Contains(searchTerm)).ToListAsync();

        }
        public async Task<Article> CreateAsync(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }

        public async Task<bool> DeleteAsyc(int id)
        {

            Article? article = await GetByIdAsync(id);

            if (article == null)
            {
                return false;
            }
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return true;
        }
         
        public async Task<bool> UpdateAsync(Article article)
        {
            Article? existingArticle = await GetByIdAsync(article.Id);
            if (existingArticle == null)
            {
                return false;
            }
            existingArticle.ArticleNumber = article.ArticleNumber;
            existingArticle.ArticleName = article.ArticleName;
            existingArticle.Unit = article.Unit;
            existingArticle.TotalStock = article.TotalStock;
            existingArticle.MinimumStock = article.MinimumStock;
            existingArticle.MaximumStock = article.MaximumStock;

            //_context.Articles.Update(existingArticle); Maybe not needed as the entity is already being tracked by the context
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
  