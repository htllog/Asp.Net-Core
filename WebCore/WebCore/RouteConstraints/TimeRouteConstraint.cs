using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace WebCore.RouteConstraints;

public class TimeRouteConstraint : IActionConstraint
{
    private readonly TimeSpan _startTime;
    private readonly TimeSpan _endTime;

    public TimeRouteConstraint(TimeSpan startTime, TimeSpan endTime)
    {
        _startTime = startTime;
        _endTime = endTime;
    }

    public int Order { get; } = 0;

    public bool Accept(ActionConstraintContext context)
    {
        var now = DateTime.Now.TimeOfDay;
        return now >= _startTime && now <= _endTime;
    }
}