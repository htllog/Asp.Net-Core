namespace WebCore.Controllers;

// 对中间件管道进行分支
public class CustomMapMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMapMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // 检查请求路径
        var path = context.Request.Path.Value?.ToLower();
        
        // 处理不同的路径
        switch (path)
        {
            case "/map1":
                await context.Response.WriteAsync("Map Test 1");
                break;
            case "/map2":
                await context.Response.WriteAsync("Map Test 2");
                break;
            default:
                await context.Response.WriteAsync("Hello from non-Map delegate.");
                break;
        }
    }
}