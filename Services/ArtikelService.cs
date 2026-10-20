
using LVS.Data;
using LVS.Models;
using Microsoft.EntityFrameworkCore;

namespace LVS.Services
{
    public class ArtikelService
    {
        private readonly LvsDbContext _context;

        public ArtikelService(LvsDbContext context)
        {
            _context = context;
        }

        
        }
    }
}
