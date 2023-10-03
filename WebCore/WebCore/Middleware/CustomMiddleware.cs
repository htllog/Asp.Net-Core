namespace WebCore.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Response.HasStarted)
            {
                // 在请求到达下一个中间件之前做一些事情
                await context.Response.WriteAsync("CustomMiddleware: Processing request\n");
            }
    
            // 调用管道中的下一个中间件
            await _next(context);
    
            // 请求被所有后续中间件处理后执行某些操作
        }
    }
}