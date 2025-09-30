using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.SegmentProcessor;
using Itmo.ObjectOrientedProgramming.Lab1.Simulation;
using Itmo.ObjectOrientedProgramming.Lab1.Train;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class XUnitTests
{
    [Fact]
    public void Simulation_ForceLessThenRouteLimit_EndedCorrectly()
    {
        // arrange
        var mass = new Mass(10);
        var force = new Force(100);
        var precisionTime = new Time(2);

        var train = new SimpleTrain(mass, force, precisionTime);

        IEnumerable<IRouteSegment> segments = [
            new PowerMagneticPath(new Length(1000), new Force(100)),
            new SimpleMagneticPath(new Length(10000))
        ];

        var route = new Route(segments, new Velocity(500));
        var processor = new RouteSegmentProcessor();
        var routeSimulator = new RouteSimulator(processor);

        // act
        SimulationResult res = routeSimulator.RunSimulation(route, train);

        // assert
        Assert.Equal(res, new SimulationResult.SimulationEndedCorrectly(new Time(86)));
    }

    [Fact]
    public void Simulation_ForceMoreThenRouteLimit_EndedWithFailure()
    {
        // arrange
        var mass = new Mass(100);
        var force = new Force(100);
        var precisionTime = new Time(2);

        var train = new SimpleTrain(mass, force, precisionTime);

        IEnumerable<IRouteSegment> segments = [
            new PowerMagneticPath(new Length(100), new Force(101)),
            new SimpleMagneticPath(new Length(100))
        ];

        var route = new Route(segments, new Velocity(20));
        var processor = new RouteSegmentProcessor();
        var routeSimulator = new RouteSimulator(processor);

        // act
        SimulationResult res = routeSimulator.RunSimulation(route, train);

        // assert
        Assert.Equal(res, new SimulationResult.SimulationEndedWithFailure(new Time(0), "Too much force was applied"));
    }

    [Fact]
    public void Simulation_ForceLessThenStationLimitAndLessThenRouteLimit_EndedCorrectly()
    {
        // arrange
        var mass = new Mass(100);
        var force = new Force(100);
        var precisionTime = new Time(2);

        var train = new SimpleTrain(mass, force, precisionTime);

        IEnumerable<IRouteSegment> segments =
        [
            new PowerMagneticPath(new Length(100), new Force(50)),
            new SimpleMagneticPath(new Length(100)),
            new Station(new Velocity(100), new Time(15), new Time(10)),
            new SimpleMagneticPath(new Length(100))
        ];

        var route = new Route(segments, new Velocity(20));
        var processor = new RouteSegmentProcessor();
        var routeSimulator = new RouteSimulator(processor);

        // act
        SimulationResult res = routeSimulator.RunSimulation(route, train);

        // assert
        Assert.Equal(res, new SimulationResult.SimulationEndedCorrectly(new Time(65)));
    }

    [Fact]
    public void Simulation_ForceMoreThenStationLimit_EndedWithFailure()
    {
        // arrange
        var mass = new Mass(100);
        var force = new Force(10);
        var precisionTime = new Time(2);

        var train = new SimpleTrain(mass, force, precisionTime);

        IEnumerable<IRouteSegment> segments =
        [
            new PowerMagneticPath(new Length(100), new Force(5)),
            new Station(new Velocity(1), new Time(15), new Time(10)),
            new SimpleMagneticPath(new Length(100))
        ];

        var route = new Route(segments, new Velocity(10));
        var processor = new RouteSegmentProcessor();
        var routeSimulator = new RouteSimulator(processor);

        // act
        SimulationResult res = routeSimulator.RunSimulation(route, train);

        // assert
        Assert.Equal(res, new SimulationResult.SimulationEndedWithFailure(new Time(64), "Too high velocity"));
    }

    [Fact]
    public void Simulation_ForceLessThenStationLimitAndMoreThenRouteLimit_EndedWithFailure()
    {
        // arrange
        var mass = new Mass(100);
        var force = new Force(10);
        var precisionTime = new Time(2);

        var train = new SimpleTrain(mass, force, precisionTime);

        IEnumerable<IRouteSegment> segments =
        [
            new PowerMagneticPath(new Length(100), new Force(5)),
            new Station(new Velocity(100), new Time(15), new Time(10)),
            new SimpleMagneticPath(new Length(100))
        ];

        var route = new Route(segments, new Velocity(1));
        var processor = new RouteSegmentProcessor();
        var routeSimulator = new RouteSimulator(processor);

        // act
        SimulationResult res = routeSimulator.RunSimulation(route, train);

        // assert
        Assert.Equal(res, new SimulationResult.SimulationEndedWithFailure(new Time(121), "Too much speed for the end of the route"));
    }

    [Fact]
    public void Simulation_PowerMagneticPathsWhichApplyPositiveAndNegativeForce_EndedCorrectly()
    {
        // arrange
        var mass = new Mass(100);
        var force = new Force(1000);
        var precisionTime = new Time(2);

        var train = new SimpleTrain(mass, force, precisionTime);

        IEnumerable<IRouteSegment> segments =
        [
            new PowerMagneticPath(new Length(100), new Force(500)),
            new SimpleMagneticPath(new Length(100)),
            new PowerMagneticPath(new Length(100), new Force(-350)),
            new Station(new Velocity(10), new Time(15), new Time(10)),
            new SimpleMagneticPath(new Length(100)),
            new PowerMagneticPath(new Length(100), new Force(900)),
            new SimpleMagneticPath(new Length(100)),
            new PowerMagneticPath(new Length(650), new Force(-100))
        ];

        var route = new Route(segments, new Velocity(10));
        var processor = new RouteSegmentProcessor();
        var routeSimulator = new RouteSimulator(processor);

        // act
        SimulationResult res = routeSimulator.RunSimulation(route, train);

        // assert
        Assert.Equal(res, new SimulationResult.SimulationEndedCorrectly(new Time(131)));
    }

    [Fact]
    public void Simulation_NoForceSimpleMagneticPath_EndedWithFailure()
    {
        // arrange
        var mass = new Mass(100);
        var force = new Force(10);
        var precisionTime = new Time(2);

        var train = new SimpleTrain(mass, force, precisionTime);

        IEnumerable<IRouteSegment> segments =
        [
            new SimpleMagneticPath(new Length(100))
        ];

        var route = new Route(segments, new Velocity(100));
        var processor = new RouteSegmentProcessor();
        var routeSimulator = new RouteSimulator(processor);

        // act
        SimulationResult res = routeSimulator.RunSimulation(route, train);

        // assert
        Assert.Equal(res, new SimulationResult.SimulationEndedWithFailure(new Time(0), "The velocity is 0, the train has stopped"));
    }

    [Fact]
    public void Simulation_NegativeForce_EndedWithFailure()
    {
        // arrange
        var mass = new Mass(100);
        var force = new Force(10);
        var precisionTime = new Time(2);

        var train = new SimpleTrain(mass, force, precisionTime);

        IEnumerable<IRouteSegment> segments =
        [
            new PowerMagneticPath(new Length(100), new Force(5)),
            new PowerMagneticPath(new Length(100), new Force(-10)),
        ];

        var route = new Route(segments, new Velocity(1000));
        var processor = new RouteSegmentProcessor();
        var routeSimulator = new RouteSimulator(processor);

        // act
        SimulationResult res = routeSimulator.RunSimulation(route, train);

        // assert
        Assert.Equal(res, new SimulationResult.SimulationEndedWithFailure(new Time(94), "The velocity is 0, the train has stopped"));
    }
}