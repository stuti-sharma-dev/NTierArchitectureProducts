using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null) return false;

            _dbContext.Products.Remove(product);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
           return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
          return  await _dbContext.Products.FindAsync(id);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
         _dbContext.Products.Update(product);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
