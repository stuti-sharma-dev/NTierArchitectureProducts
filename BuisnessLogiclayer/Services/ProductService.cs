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

        public async Task<bool> DeleteProduct(int id)
        {
           return await _productRepository.DeleteProduct(id);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return products.Select(p => new ProductDTO { Id = p.Id, Name = p.Name, Price = p.Price }).ToList();
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            return product == null ? null : new ProductDTO { Id = product.Id, Name = product.Name, Price = product.Price };
        }

        public async Task<bool> UpdateProduct(ProductDTO productDto)
        {
            var product = new Product { Id = productDto.Id, Name = productDto.Name, Price = productDto.Price };
            return await _productRepository.UpdateProduct(product);
        }
    }
}
