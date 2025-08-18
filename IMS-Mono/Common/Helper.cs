namespace IMS_Mono.Common
{
    public static class Helper
    {
        public static bool IsScalarOrExcludedRequest(HttpContext context)
        {
            // Define paths that should be excluded from logging
            var excludedPaths = new[]
            {
                "/",
                "/health",
                "/metrics",
                "/favicon.ico",
                "/swagger",
                "/scalar",
                "/openapi/v1.json",
                "/swagger-ui"
            };
            
            return excludedPaths.Any(path => context.Request.Path.StartsWithSegments(path, StringComparison.OrdinalIgnoreCase));

        }
    }
}