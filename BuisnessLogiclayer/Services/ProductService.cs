using BuisnessLogiclayer.DTOs;
using BuisnessLogiclayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogiclayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDTO> CreateProduct(ProductDTO productDto)
        {
            var product = new Product { Name = productDto.Name, Price = productDto.Price };
            var createdProduct = await _productRepository.CreateProduct(product);
            return new ProductDTO { Id = createdProduct.Id, Name = createdProduct.Name, Price = createdProduct.Price };
        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(ProductDTO productDto)
        {
            throw new NotImplementedException();
        }
    }
}
