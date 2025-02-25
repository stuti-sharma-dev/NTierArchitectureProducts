using BuisnessLogiclayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogiclayer.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task<ProductDTO> CreateProduct(ProductDTO productDto);
        Task<bool> UpdateProduct(ProductDTO productDto);
        Task<bool> DeleteProduct(int id);
    }
}
