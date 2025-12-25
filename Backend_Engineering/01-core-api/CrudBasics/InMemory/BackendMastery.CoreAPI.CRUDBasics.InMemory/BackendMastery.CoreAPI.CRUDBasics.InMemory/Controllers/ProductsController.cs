using BackendMastery.CoreAPI.CRUDBasics.InMemory.Models;
using BackendMastery.CoreAPI.CRUDBasics.InMemory.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.CoreAPI.CRUDBasics.InMemory.Controllers;

/// <summary>
/// REST API controller responsible for managing <see cref="Product"/> resources.
/// </summary>
/// <remarks>
/// <para>
/// This controller represents the <b>API layer</b> of the application.
/// It handles HTTP concerns such as routing, status codes, and request/response mapping.
/// </para>
/// <para>
/// Business logic is intentionally delegated to the <see cref="IProductService"/>
/// to keep controllers thin and focused on transport-level responsibilities.
/// </para>
/// </remarks>
[ApiController]
[Route("api/v1/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    // Design Pattern: Constructor Dependency Injection (In-Built Support by .NET)
    // Ensures the controller depends on abstractions, not concrete implementations
    public ProductsController(IProductService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>
    /// HTTP 200 (OK) with the list of products. or Empty List
    /// </returns>
    // Endpoint Structure: GET /api/products
    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    /// <summary>
    /// Retrieves a specific product by its unique identifier.
    /// Endpoint Structure: GET /api/products/{id}
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the product.
    /// </param>
    /// <returns>
    /// HTTP 200 (OK) if found; otherwise HTTP 404 (Not Found).
    /// </returns>
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        // Use explicit type mentioning when RHS doesn't talks about the type to the reader
        Product? product = _service.GetById(id);

        // Exit early: Utilizing the "Pattern Matching" mechanism for null check
        if (product is null) return NotFound();

        return Ok(product);
    }

    /// <summary>
    /// Creates a new product using the provided request payload.
    /// Endpoint Structure: POST /api/products
    /// </summary>
    /// <param name="request">
    /// The request body containing the product details required for creation.
    /// </param>
    /// <returns>
    /// HTTP 201 (Created) with the newly created product and the location header
    /// pointing to the GET endpoint of the created resource.
    /// </returns>
    /// <remarks>
    /// The request data is supplied via the HTTP request body and mapped to a DTO
    /// to decouple API contracts from domain entities.
    /// </remarks>
    [HttpPost]
    public IActionResult Create([FromBody] ProductCreateUpdateRequest request)
    {
        // Use explicit type mentioning when RHS doesn't talks about the type to the reader
        Product? product = _service.Create(request.Name, request.Price);

        // REST best practice:
        // - Return 201 Created
        // - Include the URI of the newly created resource
        return CreatedAtAction(nameof(GetById),
            new { id = product.Id },
            product);
    }

    /// <summary>
    /// Updates an existing product using the provided request payload.
    /// Endpoint Structure: PUT /api/products/{id}
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the product to update.
    /// </param>
    /// <param name="request">
    /// The request body containing the updated product details.
    /// </param>
    /// <returns>
    /// HTTP 204 (No Content) if the update is successful;
    /// otherwise HTTP 404 (Not Found) if the product does not exist.
    /// </returns>
    /// <remarks>
    /// The identifier is supplied via the route, while the updated data
    /// is supplied via the request body to clearly separate resource identity
    /// from mutable state.
    /// </remarks>
    [HttpPut("{id:guid}")]
    public IActionResult Update([FromRoute] Guid id, [FromBody] ProductCreateUpdateRequest request)
    {
        // Use explicit type mentioning when RHS doesn't talks about the type to the reader
        bool isUpdated = _service.Update(id, request.Name, request.Price);

        if (!isUpdated) return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Deletes a product by its unique identifier.
    /// Endpoint Structure: DELETE /api/products/{id}
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the product to delete.
    /// </param>
    /// <returns>
    /// HTTP 204 (No Content) if deleted successfully;
    /// otherwise HTTP 404 (Not Found).
    /// </returns>
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        // Use explicit type mentioning when RHS doesn't talks about the type to the reader
        bool deleted = _service.Delete(id);

        if (!deleted) return NotFound();

        return NoContent();
    }
}