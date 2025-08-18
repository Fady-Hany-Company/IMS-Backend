using IMS.Domain.Entities;
using IMS_Mono.Common;
using System.Text.Json;

namespace IMS_Mono.Middlewares
{
    public class ResponseWrapperMiddleware
    {
        private readonly RequestDelegate _next;
        public ResponseWrapperMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Capture original response stream
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            try
            {
                await _next(context);

                // Reset response body stream to read it
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var bodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                if (Helper.IsScalarOrExcludedRequest(context))
                {
                    await responseBody.CopyToAsync(originalBodyStream);
                    return;
                }
                // If already in BaseResponse format, skip wrapping
                if (!string.IsNullOrWhiteSpace(bodyText) && bodyText.Trim().StartsWith("{\"success\""))
                {
                    await responseBody.CopyToAsync(originalBodyStream);
                    return;
                }

                object? bodyObject = null;
                if (!string.IsNullOrWhiteSpace(bodyText))
                {
                    bodyObject = System.Text.Json.JsonSerializer.Deserialize<object>(bodyText);
                }

                var wrappedResponse = BaseResponse<object>.SuccessResponse("Request successful", bodyObject);

                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(originalBodyStream, wrappedResponse);
                await originalBodyStream.FlushAsync(); ;
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var errorResponse = BaseResponse<string>.FailureResponse(ex.Message);
                await JsonSerializer.SerializeAsync(originalBodyStream, errorResponse);
                await originalBodyStream.FlushAsync();
            }
            finally
            {
                context.Response.Body = originalBodyStream;
            }
        }
    }
}
