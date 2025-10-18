using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;

public interface IRouteSegment
{
    SegmentResult GoThrough(SimpleTrain train);
}