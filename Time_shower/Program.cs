using System.Data;

var builder = WebApplication.CreateBuilder(); //configuration for thr future server

var app = builder.Build();

app.MapGet("/request", HandleRequest);

app.Run();//start the server 
void HandleRequest(HttpContext context)
{
    // address of the request
    Console.WriteLine("Request to url: " + context.Request.Path.Value); // HttpContext/ contain datas about requests and probably create answer
    // Method question (GET/POST)
    Console.WriteLine("Method: " + context.Request.Method);
    //answer
    context.Response.WriteAsync(DateTime.Now.ToString());
}