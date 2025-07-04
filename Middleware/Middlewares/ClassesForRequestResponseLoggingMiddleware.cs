namespace Middleware.Middlewares;

public class ClassesForRequestResponseLoggingMiddleware
{
    public class LogEntry
    {
        public DateTime Time { get; set; }
        public required RequestInfo Request { get; set; }
        public required ResponseInfo Response { get; set; }
    }
    public class RequestInfo
    {
        public required string Method { get; set; }
        public required string Url { get; set; }
        public required Dictionary<string, string> Headers { get; set; }
        public string? Body { get; set; }
    }
    public class ResponseInfo
    {
        public int StatusCode { get; set; }
        public required Dictionary<string, string>  Headers { get; set; }
        public required string Body { get; set; }
    }
}