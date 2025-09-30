using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.SegmentProcessor;

public interface ISegmentProcessor
{
    SegmentPassResult Process(SimpleMagneticPath segment, ITrain train);

    SegmentPassResult Process(PowerMagneticPath segment, ITrain train);

    SegmentPassResult Process(Station segment, ITrain train);
}