
using LVS.Data;
using LVS.Models;
using Microsoft.EntityFrameworkCore;

namespace LVS.Services
{
    public class ArticleService
    {
        private readonly WarehouseDbContext _context;

        public ArticleService(WarehouseDbContext context)
        {
            _context = context;
        }
    }
}
