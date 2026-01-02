using BackendMastery.ProdReadiness.Validation.Contracts.Responses;

namespace BackendMastery.ProdReadiness.Validation.Infrastructure;

/// <summary>
/// INTUITION:
/// Centralizes how validation errors are expressed.
///
/// USE CASE:
/// Ensures every validation failure looks the same to consumers.
///
/// FAILURE MODE:
/// Letting controllers format errors causes fragmentation.
/// </summary>
public static class ValidationErrorFactory
{
    public static ErrorResponse Create(IDictionary<string, string[]> errors)
    {
        return new ErrorResponse
        {
            Code = "VALIDATION_FAILED",
            Message = "One or more validation errors occurred.",
            Details = errors
        };
    }
}