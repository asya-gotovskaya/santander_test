namespace HackerNews.Middlewares
{
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public ExceptionHandlerMiddleware(RequestDelegate next, 
			ILogger<ExceptionHandlerMiddleware> logger)
		{
			_logger = logger;
			_next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong: {ex}");
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			context.Response.ContentType = "application/text";
			context.Response.StatusCode = StatusCodes.Status500InternalServerError;

			await context.Response.WriteAsync(exception.Message);
		}
	}
}
