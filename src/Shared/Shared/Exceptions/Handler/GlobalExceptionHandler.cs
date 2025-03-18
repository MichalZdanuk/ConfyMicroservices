using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Shared.Exceptions.Handler;
public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
	: IExceptionHandler
{
	public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
	{
		logger.LogError("Exception: {exceptionMessage}, occured at: {time}", exception.Message, DateTime.UtcNow);

		context.Response.ContentType = "application/json";

		(HttpStatusCode statusCode, string message) = exception switch
		{
			BadRequestException badRequestException => (HttpStatusCode.BadRequest, badRequestException.Message),
			NotFoundException notFoundException => (HttpStatusCode.NotFound, notFoundException.Message),
			ForbiddenException forbiddenException => (HttpStatusCode.Forbidden, forbiddenException.Message),
			_ => (HttpStatusCode.InternalServerError, "An unexpected error occurred.")
		};

		var response = new
		{
			StatusCode = (int)statusCode,
			Message = message,
		};

		context.Response.StatusCode = (int)statusCode;

		await context.Response.WriteAsync(JsonSerializer.Serialize(response));

		return true;
	}
}
