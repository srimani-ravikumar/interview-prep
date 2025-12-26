using BackendMastery.CoreAPI.RESTPrinciples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace BackendMastery.CoreAPI.RESTPrinciples.Controllers;

[ApiController]
[Route("api/v1/http-semantics")]
public class HttpVerbsController : ControllerBase
{
    // Simulated in-memory storage to demonstrate HTTP behavior
    private static readonly Dictionary<Guid, Resource> _store = new();

    // ---------------------------------------
    // SAFE & IDEMPOTENT
    // ---------------------------------------

    /// <summary>
    /// GET retrieves a resource.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Read-only operation that never changes server state.
    /// <br/>
    /// <b>Use case:</b> Fetching details to display in UI or dashboards.
    /// </remarks>
    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        if (!_store.TryGetValue(id, out var resource))
            return NotFound();

        return Ok(resource);
    }

    /// <summary>
    /// HEAD checks for resource existence without returning the body.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Same as GET but optimized for metadata checks.
    /// <br/>
    /// <b>Use case:</b> Cache validation, health checks, existence probing.
    /// </remarks>
    [HttpHead("{id:guid}")]
    public IActionResult Head(Guid id)
    {
        if (!_store.ContainsKey(id))
            return NotFound();

        return Ok();
    }

    // ---------------------------------------
    // UNSAFE & NON-IDEMPOTENT
    // ---------------------------------------

    /// <summary>
    /// POST creates a new resource.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Each request results in a new server-side entity.
    /// <br/>
    /// <b>Use case:</b> Creating orders, users, tickets, or transactions.
    /// </remarks>
    [HttpPost]
    // [FromBody] → “Read data from HTTP request body, not route or query.”
    // JsonElement → “Represents raw JSON when no strongly-typed DTO is used.”
    public IActionResult Post([FromBody] JsonElement body)
    {
        // ! operator → “Tell the compiler: I know this won’t be null here.”
        string name = body.GetProperty("name").GetString()!;

        var resource = new Resource
        {
            Id = Guid.NewGuid(),
            Name = name,
            Version = 1
        };

        _store[resource.Id] = resource;

        return CreatedAtAction(nameof(Get),
            new { id = resource.Id },
            resource);
    }

    // ---------------------------------------
    // IDEMPOTENT BUT UNSAFE
    // ---------------------------------------

    /// <summary>
    /// PUT fully replaces an existing resource.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Same request always results in the same final state.
    /// <br/>
    /// <b>Use case:</b> Replacing profiles, settings, or configuration objects.
    /// </remarks>
    [HttpPut("{id:guid}")]
    // [FromBody] → “Read data from HTTP request body, not route or query.”
    // JsonElement → “Represents raw JSON when no strongly-typed DTO is used.”
    public IActionResult Put(Guid id, [FromBody] JsonElement body)
    {
        // ! operator → “Tell the compiler: I know this won’t be null here.”
        string name = body.GetProperty("name").GetString()!;

        if (!_store.ContainsKey(id))
            return NotFound();

        _store[id] = new Resource
        {
            Id = id,
            Name = name,
            Version = _store[id].Version + 1
        };

        return NoContent();
    }

    // ---------------------------------------
    // UNSAFE & NON-IDEMPOTENT
    // ---------------------------------------

    /// <summary>
    /// PATCH partially updates a resource.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Applies incremental changes based on current state.
    /// <br/>
    /// <b>Use case:</b> Updating a single field like name, status, or flag.
    /// </remarks>
    [HttpPatch("{id:guid}")]
    // [FromBody] → “Read data from HTTP request body, not route or query.”
    // JsonElement → “Represents raw JSON when no strongly-typed DTO is used.”
    public IActionResult Patch(Guid id, [FromBody] JsonElement body)
    {
        if (!_store.TryGetValue(id, out var resource))
            return NotFound();

        if (body.TryGetProperty("name", out var nameProp))
        {
            // ! operator → “Tell the compiler: I know this won’t be null here.”
            resource.Name = nameProp.GetString()!;
        }

        // Incrementing version demonstrates non-idempotent behavior
        resource.Version++;

        return Ok(resource);
    }

    // ---------------------------------------
    // UNSAFE BUT IDEMPOTENT
    // ---------------------------------------

    /// <summary>
    /// DELETE removes a resource.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Once deleted, repeating the request has no further effect.
    /// <br/>
    /// <b>Use case:</b> Removing users, records, or decommissioning entities.
    /// </remarks>
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        _store.Remove(id); // Removing again has no effect
        return NoContent();
    }

    // ---------------------------------------
    // SAFE & IDEMPOTENT
    // ---------------------------------------

    /// <summary>
    /// Demonstrates content negotiation.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Server returns representation based on client preferences.
    /// <br/>
    /// <b>Use case:</b> Supporting JSON, XML, or versioned response formats.
    /// </remarks>
    [HttpGet("negotiate")]
    public IActionResult Negotiate()
    {
        var resource = new Resource
        {
            Id = Guid.NewGuid(),
            Name = "Negotiated",
            Version = 1
        };

        return Ok(resource);
    }

    // ---------------------------------------
    // SAFE & IDEMPOTENT (CONDITIONAL REQUEST)
    // ---------------------------------------

    /// <summary>
    /// Conditional GET using ETag.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Avoids sending data if client already has the latest version.
    /// <br/>
    /// <b>Use case:</b> Browser caching, CDN optimization, bandwidth reduction.
    /// </remarks>
    [HttpGet("etag/{id:guid}")]
    public IActionResult GetWithEtag(Guid id)
    {
        if (!_store.TryGetValue(id, out var resource))
            return NotFound();

        string etag = $"\"v{resource.Version}\"";

        if (Request.Headers.IfNoneMatch == etag)
            return StatusCode((int)HttpStatusCode.NotModified);

        Response.Headers.ETag = etag;
        return Ok(resource);
    }

    // ---------------------------------------
    // METADATA (SAFE & IDEMPOTENT)
    // ---------------------------------------

    /// <summary>
    /// OPTIONS describes supported HTTP methods.
    /// </summary>
    /// <remarks>
    /// <b>Intuition:</b> Allows clients to discover server capabilities.
    /// <br/>
    /// <b>Use case:</b> CORS preflight requests, API tooling, client introspection.
    /// </remarks>
    [HttpOptions]
    public IActionResult Options()
    {
        Response.Headers.Allow = "GET,POST,PUT,PATCH,DELETE,HEAD,OPTIONS";
        return Ok();
    }
}