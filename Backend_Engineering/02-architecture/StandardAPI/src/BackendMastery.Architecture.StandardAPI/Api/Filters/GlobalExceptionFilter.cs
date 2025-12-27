using BackendMastery.Architecture.StandardAPI.Api.DTOs;
using BackendMastery.Architecture.StandardAPI.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BackendMastery.Architecture.StandardAPI.Api.Filters;

/// <summary>
/// Translates exceptions into HTTP responses.
/// </summary>
/// <remarks>
/// Intuition:
/// - Centralized error handling
/// - Keeps controllers clean
/// - Maps domain/application errors to HTTP
/// </remarks>
public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        ErrorResponse response;
        int statusCode;

        switch (exception)
        {
            case InvalidOrderException:
                statusCode = (int)HttpStatusCode.BadRequest;
                response = new ErrorResponse
                {
                    Code = "INVALID_ORDER",
                    Message = exception.Message
                };
                break;

            case ArgumentException:
                statusCode = (int)HttpStatusCode.BadRequest;
                response = new ErrorResponse
                {
                    Code = "INVALID_INPUT",
                    Message = exception.Message
                };
                break;

            default:
                statusCode = (int)HttpStatusCode.InternalServerError;
                response = new ErrorResponse
                {
                    Code = "INTERNAL_ERROR",
                    Message = "An unexpected error occurred."
                };
                break;
        }

        context.Result = new ObjectResult(response)
        {
            StatusCode = statusCode
        };

        context.ExceptionHandled = true;
    }
}