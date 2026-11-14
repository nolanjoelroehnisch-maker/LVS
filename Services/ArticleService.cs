
using LVS.Data;
using LVS.Models;
using Microsoft.EntityFrameworkCore;
using CsvHelper;
using System.IO;

namespace LVS.Services
{
    public class ArticleService
    {
        private readonly WarehouseDbContext _context;

        

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

        public async Task<bool> DeleteAsync(int id)
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
         
        public async Task<bool> UpdateAsync(Article article) /*Inventory levels should not simply be modified via `UpdateAsync()` 
                                                               Instead dedicated methods such as `ReceiveGoodsAsync()` or `IssueGoodsAsync()` should be used for this purpose.*/
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
            existingArticle.Brand = article.Brand;
            existingArticle.EAN = article.EAN;

            //_context.Articles.Update(existingArticle); Maybe not needed as the entity is already being tracked by the context
            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<List<Article>> ImportFromCsvAsync(Stream stream)
        {
            using var reader = new StreamReader(stream);
            var options = new CsvReaderOptions
            {
                Separator = ';'
            };
            using var csv = CsvReader.Create(reader, options);

            var existingNumbers = await _context.Articles
            .Select(a => a.ArticleNumber)
            .ToHashSetAsync();

            var articles = new List<Article>();

            await foreach (var article in csv.GetRecordsAsync<Article>())
            {
                article.ArticleNumber = article.ArticleNumber.Trim();

                if (existingNumbers.Add(article.ArticleNumber))
                {
                    articles.Add(article);
                }
            }

            if (articles.Count == 0)
            {
                return articles;
            }

            _context.Articles.AddRange(articles);
            await _context.SaveChangesAsync();
            return articles;
        }
           
        
    }
}
  