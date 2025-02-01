using Bookify.Application.Abstractions.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private RequestDelegate Next { get; }
    private ILogger<ExceptionHandlingMiddleware> Logger { get; }

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {

        Next = next;
        Logger = logger;

    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await Next(context);
        }
        catch (Exception e)
        {
            Logger.LogError(e, "Exception {Message}", e.Message);
            var exceptionDetails = GetExceptionDetails(e);

            var problemDetails = new ProblemDetails()
            {
                Status = exceptionDetails.Status,
                Type = exceptionDetails.Type,
                Title = exceptionDetails.Title,
                Detail = exceptionDetails.Detail
            };

            if (exceptionDetails.Errors is not null)
            {
                problemDetails.Extensions["Errors"] = exceptionDetails.Errors;
            }

            context.Response.StatusCode = exceptionDetails.Status;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

    private static ExceptionDetails GetExceptionDetails(Exception exception)
    {
        return exception switch
        {
            ValidationException validationException => new ExceptionDetails(
                StatusCodes.Status400BadRequest,
                "Validation",
                "Validation error",
                "one or more validation errors is throw",
                validationException.Errors
                ),
            _ => new ExceptionDetails(
                StatusCodes.Status500InternalServerError,
                "Server Error",
                "Server error",
                exception.Message,
                null
            )

        };
    }
    internal record ExceptionDetails(
        int Status,
        string Type,
        string Title,
        string Detail,
        IEnumerable<object>? Errors);
}