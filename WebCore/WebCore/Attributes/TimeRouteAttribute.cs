using Microsoft.AspNetCore.Mvc.ActionConstraints;
using WebCore.RouteConstraints;

namespace WebCore.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class TimeRouteAttribute : Attribute, IActionConstraintFactory
{
    private readonly TimeSpan _startTime;
    private readonly TimeSpan _endTime;

    public string RouteTemplate { get; }

    public TimeRouteAttribute(string startTime, string endTime)
    {
        _startTime = TimeSpan.Parse(startTime);
        _endTime = TimeSpan.Parse(endTime);
        RouteTemplate = "example/[controller]";
    }

    public IActionConstraint CreateInstance(IServiceProvider serviceProvider)
    {
        return new TimeRouteConstraint(_startTime, _endTime);
    }

    public bool IsReusable => true;
}