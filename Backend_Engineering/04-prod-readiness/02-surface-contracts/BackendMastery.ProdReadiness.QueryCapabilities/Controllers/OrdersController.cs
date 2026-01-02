using BackendMastery.ProdReadiness.QueryCapabilities.Contracts.Requests;
using BackendMastery.ProdReadiness.QueryCapabilities.Contracts.Responses;
using BackendMastery.ProdReadiness.QueryCapabilities.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.QueryCapabilities.Controllers;

/// <summary>
/// INTUITION:
/// Controllers compose queries, not execute business logic.
///
/// USE CASE:
/// Demonstrates how query contracts shape access to large datasets.
///
/// FAILURE MODE:
/// Returning raw data or allowing arbitrary querying.
/// </summary>
[ApiController]
[Route("api/v1/orders")]
public sealed class OrdersController : ControllerBase
{
    // Bad Practice: Fecthing tons of data with single get endpoint
    [HttpGet]
    public IActionResult GetAllOrders()
    {
        var query = InMemoryOrderStore.Query();
        return Ok(query);
    }

    [HttpPost("filter")]
    public IActionResult Filter([FromBody] OrderFilterRequest request)
    {
        // 1. Initialize an IQueryable. This does not execute yet; it builds an expression tree.
        var query = InMemoryOrderStore.Query();

        // 2. Conditional refinement: Append WHERE clauses only if filters are provided.
        if (!string.IsNullOrWhiteSpace(request.Status))
            query = query.Where(o => o.Status == request.Status);

        if (request.MinAmount.HasValue)
            query = query.Where(o => o.Amount >= request.MinAmount.Value);

        if (request.MaxAmount.HasValue)
            query = query.Where(o => o.Amount <= request.MaxAmount.Value);

        // 3. Execution & Projection: 
        // .Take(50) prevents "Deep Paging" or "Massive Fetch" performance kills.
        // .Select() ensures we only pull needed columns (DTO) from the data source.
        // .ToList() finally triggers the materialization of the query.
        var result = query
            .Take(50)
            .Select(o => new OrderSummaryResponse
            {
                OrderId = o.OrderId,
                Status = o.Status,
                Amount = o.Amount
            })
            .ToList();

        return Ok(result);
    }

    [HttpPost("sort")]
    public IActionResult Sort([FromBody] OrderSortRequest request)
    {
        var query = InMemoryOrderStore.Query();

        // 1. Use a switch expression to map "String Sort Keys" to typed C# expressions.
        // This prevents SQL Injection and allows for a default (stable) fallback sort.
        query = request.SortBy switch
        {
            "   " => request.Descending
                ? query.OrderByDescending(o => o.Amount).ThenBy(o => o.OrderId)
                : query.OrderBy(o => o.Amount).ThenBy(o => o.OrderId),

            _ => request.Descending
                ? query.OrderByDescending(o => o.CreatedAtUtc).ThenBy(o => o.OrderId)
                : query.OrderBy(o => o.CreatedAtUtc).ThenBy(o => o.OrderId)
        };

        var result = query
            .Take(50)
            .Select(o => new OrderSummaryResponse { OrderId = o.OrderId, Amount = o.Amount, Status = o.Status })
            .ToList();

        return Ok(result);
    }

    [HttpPost("page")]
    public IActionResult Page([FromBody] PaginationRequest request)
    {
        // 1. Pagination MUST have an OrderBy to be consistent across different calls.
        var query = InMemoryOrderStore.Query()
            .OrderBy(o => o.CreatedAtUtc)
            .ThenBy(o => o.OrderId);

        // 2. Calculate offset: (Page 1 starts at 0, Page 2 starts at PageSize, etc.)
        var skip = (request.PageNumber - 1) * request.PageSize;

        // 3. Apply the "Skip/Take" pattern (standard Offset Pagination).
        var items = query
            .Skip(skip)
            .Take(request.PageSize)
            .Select(o => new OrderSummaryResponse { OrderId = o.OrderId, Amount = o.Amount, Status = o.Status })
            .ToList();

        // 4. Wrap in a PagedResponse to provide metadata to the client.
        var response = new PagedResponse<OrderSummaryResponse>
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            Items = items
        };

        return Ok(response);
    }
}