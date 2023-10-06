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
        var path = context.Request.Path.Value?.ToLower();

        switch (path)
        {
            case "/map1":
                // 提取 “/map1” 之后的子路径
                var subPathMap1 = context.Request.Path.Value?.Substring("/map1".Length);
                await context.Response.WriteAsync($"Map Test 1{subPathMap1}");
                break;

            case "/map2":
                var subPathMap2 = context.Request.Path.Value?.Substring("/map2".Length);
                await context.Response.WriteAsync($"Map Test 2{subPathMap2}");
                break;

            default:
                await context.Response.WriteAsync("Hello from non-Map delegate.");
                break;
        }
    }
}