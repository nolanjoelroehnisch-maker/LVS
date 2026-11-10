
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
            
        }
    }
}
  