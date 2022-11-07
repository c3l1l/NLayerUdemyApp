using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            //Eager Loading => Product datasi gelirken ayni anda, Category bilgisininde gelmesini istedik...
            //Lazy Loading => Product datasina bagli Category bilgisi daha sonra gelirse Lazy loading olur.

            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
