using BackendMastery.ECommerce.API.Contracts.Products;
using BackendMastery.ECommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ECommerce.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateProductRequest request)
    {
        var productId = await _productService.CreateProductAsync(
            request.Name,
            request.Price);

        var response = new ProductResponse(
            productId,
            request.Name,
            request.Price);

        return CreatedAtAction(
            nameof(Create),
            new { id = productId },
            response);
    }
}