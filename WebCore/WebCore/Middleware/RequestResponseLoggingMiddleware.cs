namespace WebCore.Middleware;

// 处理请求进入和离开应用程序时
public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestResponseLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // 记录请求详细信息
        LogRequest(context.Request);
        
        // 调用管道中的下一个中间件
        await _next(context);
        
        // 记录响应详细信息
        LogResponse(context.Response);
    }

    private void LogRequest(HttpRequest request)
    {
        // 在此处记录请求详细信息 (例如请求路径、标头等)
        Console.WriteLine("Request Path: " + request.Path);
    }

    private void LogResponse(HttpResponse response)
    {
        // 在此处记录响应详细信息 (例如状态代码、标头等）
        Console.WriteLine("Response Status Code: " + response.StatusCode);
    }
}