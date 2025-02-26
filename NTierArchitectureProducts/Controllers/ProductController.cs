using BuisnessLogiclayer.DTOs;
using BuisnessLogiclayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NTierArchitectureProducts.Controllers
{
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productService.GetAllProducts();
        return Json(products); // Returns JSON response
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _productService.GetProductById(id);
        return product == null ? NotFound() : Json(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var createdProduct = await _productService.CreateProduct(productDto);
        return Json(createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        productDto.Id = id;
        var result = await _productService.UpdateProduct(productDto);
        return result ? Json(new { success = true }) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _productService.DeleteProduct(id);
        return result ? Json(new { success = true }) : NotFound();
    }
    }
}
