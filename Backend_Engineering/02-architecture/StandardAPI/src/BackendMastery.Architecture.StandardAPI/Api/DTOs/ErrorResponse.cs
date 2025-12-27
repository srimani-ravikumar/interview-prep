namespace BackendMastery.StandardAPI.Api.DTOs;

/// <summary>
/// Standard API error response.
/// </summary>
public class ErrorResponse
{
    public string Code { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}