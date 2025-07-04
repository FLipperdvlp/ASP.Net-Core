using System.Text.Json;

namespace Middleware.Middlewares;

public class RequestResponseLoggingMiddleware(RequestDelegate next)
{
    private readonly string logFilePath = "logs.txt";
    //Task Invoke
    public async Task Invoke(HttpContext context)
    {
        context.Request.EnableBuffering();// Буферизация

        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        context.Request.Body.Position = 0; //return indicator back

        var originalBodyStream = context.Response.Body; // save original response body
        using var newBodyStream = new MemoryStream();
        
        context.Response.Body = newBodyStream;

        await next(context); // call next middleware

        //Read body of answer 
        newBodyStream.Seek(0, SeekOrigin.Begin);
        var responseBody = await new StreamReader(newBodyStream).ReadToEndAsync();
        newBodyStream.Seek(0, SeekOrigin.Begin);

        //  Устал дальше комментарии писать( лень ). 
        
        await newBodyStream.CopyToAsync(originalBodyStream);
        
        var log = new ClassesForRequestResponseLoggingMiddleware.LogEntry()
        {
            Time = DateTime.Now,
            Request = new ClassesForRequestResponseLoggingMiddleware.RequestInfo()
            {
                Method = context.Request.Method,
                Url = context.Request.Path + context.Request.QueryString,
                Headers = context.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()),
                Body = requestBody
            },
            Response = new ClassesForRequestResponseLoggingMiddleware.ResponseInfo()
            {
                StatusCode = context.Response.StatusCode,
                Headers = context.Response.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()),
                Body = responseBody
            }
        };
        //=====================================================================================
        var json = JsonSerializer.Serialize(log, new JsonSerializerOptions { WriteIndented = true });
        await File.AppendAllTextAsync("logs.txt", json + "\n==========================NEXT=========================\n");
    }
}
public static class RequestResponseLoggingMiddlewareExtension
{
    public static void UseRequestResponseLoggingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestResponseLoggingMiddleware>();
    }
}