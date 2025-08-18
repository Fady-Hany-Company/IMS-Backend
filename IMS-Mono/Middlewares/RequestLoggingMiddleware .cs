using IMS.Application.DTOs.Logging.UpdateLog;
using IMS.Application.Features.Logging.InsertLog;
using IMS.Application.Features.Logging.UpdateLog;
using MediatR;
using IMS_Mono.Common;

namespace IMS_Mono.Middlewares
{
    public class RequestLoggingMiddleware : IMiddleware
    {
        private readonly IMediator _mediator;


        public RequestLoggingMiddleware(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Skip logging for scalar or irrelevant paths
            if (Helper.IsScalarOrExcludedRequest(context))
            {
                await next(context);
                return;
            }
            var logId = 0;
            Exception? exception = null;

            try
            {
                var request = context.Request;
                logId = await _mediator.Send(new InsertLogCommand(
                    LoginName: context.User?.Identity?.Name ?? "Anonymous",
                    LogSource: "Backend",
                    HttpMethod: request.Method,
                    EndpointUrl: request.Path + request.QueryString,
                    LogLevel: "Info",
                    Message: "Request Started",
                    Exception: null,
                    Response: null
                ));
            }
            catch
            {
                // Don't block the request if logging fails
            }
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                // Capture the error so we can update the log,
                // then rethrow so normal error handling still applies.
                exception = ex;
                throw;
            }
            finally
            {
                // 3) Update the log after the response is produced (even on error)
                if (logId != 0)
                {


                    context.Response.OnCompleted(async () =>
                    {
                        if (logId == 0) return;
                        try
                        {
                            var statusCode = context.Response?.StatusCode;
                            var level = statusCode >= 500 ? "Error" :
                                statusCode >= 400 ? "Warning" : "Info";
                            await _mediator.Send(new UpdateLogCommand(new UpdateLogRequestDto
                            {
                                LogId = logId,
                                LogLevel = level,
                                Message = exception?.Message ?? "Request Completed",
                                Exception = exception?.InnerException?.ToString(),
                                Response = $"StatusCode: {statusCode}"
                            }));
                        }
                        catch { }
                    });
                }
                ;
            }
        }
        
    }
}
