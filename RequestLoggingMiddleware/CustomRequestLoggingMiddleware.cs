using Microsoft.AspNetCore.Authentication;
using MinimalChatApplication.DTO.ResponseDTO;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MinimalChatApplication.Repository.Interface;
using MinimalChatApplication.Repository.Implementation;

namespace MinimalChatApplication.RequestLoggingMiddleware
{
    public class CustomRequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomRequestLoggingMiddleware> _logger;
        List<LogResponse> lstLogResponses;
        private readonly List<string> _logMessages;

        public CustomRequestLoggingMiddleware(RequestDelegate next, ILogger<CustomRequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _logMessages = new List<string>();
            lstLogResponses = new List<LogResponse>();            
        }

        public async Task InvokeAsync(HttpContext context,IRequestLoggingMiddleware _iRequestLoggingMiddleware)
        {
            // Enable buffering to capture the request body
            context.Request.EnableBuffering();


            LogResponse logResponse = new LogResponse();
            
            var ipAddress = context.Connection.RemoteIpAddress?.ToString(); 
            logResponse.iPOfCaller = ipAddress;
            logResponse.userName = ""; 

            DateTime dateTime = DateTime.Now;
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
            logResponse.timeOfCall = dateTimeOffset.ToUnixTimeSeconds();           


            // Log the request information
            var logMessage = $"Request: {context.Request.Method} {context.Request.Path} {context.Request.QueryString}";
            _logMessages.Add(logMessage);

            logResponse.method = context.Request.Method;
            logResponse.path = context.Request.Path;
            logResponse.queryString = context.Request.QueryString;


            // Read and log the request body if present
            string requestBody = await GetRequestBodyAsync(context.Request);

            logResponse.requestBody = requestBody;

            if (!string.IsNullOrEmpty(requestBody))
            {
                var requestBodyLog = $"Request Body: {requestBody}";
                _logMessages.Add(requestBodyLog);
            }
            
            // Store the values in the HttpContext
            lstLogResponses.Add(logResponse);
            context.Items["logMessages"] = _logMessages;
            context.Items["lstLogResponses"] = lstLogResponses;


            //store the values in the db
            if (logResponse != null)
            {
                _iRequestLoggingMiddleware.PostRequestLoggingMiddleware(logResponse);
            }


            // Call the next middleware in the pipeline
            await _next(context);
        }

        private async Task<dynamic> GetRequestBodyAsync(HttpRequest request)
        {

            // Ensure the request body can be read multiple times
            request.EnableBuffering();

            // Read the request body stream
            using var reader = new StreamReader(request.Body, Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true);
            var requestBody = await reader.ReadToEndAsync();

            // Reset the request body position for subsequent middleware/components
            request.Body.Position = 0;

            return requestBody;
        }
    }
}
