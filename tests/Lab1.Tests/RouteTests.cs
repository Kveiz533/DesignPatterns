using Itmo.ObjectOrientedProgramming.Lab1.PhysicalQuantities;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.Train;
using Itmo.ObjectOrientedProgramming.Lab1.TrainRoute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class RouteTests
{
    [Fact]
    public void Simulation_ForceLessThenRouteLimit_EndedCorrectly()
    {
        // Arrange
        var mass = new Mass(10);
        var force = new Force(100);
        var precisionTime = new Time(2);

        var train = new SimpleTrain(mass, force, precisionTime);

        IEnumerable<IRouteSegment> segments = [
            new PowerMagneticPath(new Length(1000), new Force(100)),
            new SimpleMagneticPath(new Length(10000))
        ];

        var route = new Route(segments, new Velocity(500));

        // Act
        SimulationResult res = route.RunSimulation(train);

        // Assert
        Assert.Equal(res, new SimulationResult.SimulationEndedCorrectly(new Time(86)));
    }

    [Fact]
    public void Simulation_ForceMoreThenRouteLimit_EndedWithFailure()
    {
        // Arrange
        var mass = new Mass(100);
        var force = new Force(100);
        var precisionTime = new Time(2);

        var train = new SimpleTrain(mass, force, precisionTime);

        IEnumerable<IRouteSegment> segments = [
            new PowerMagneticPath(new Length(100), new Force(101)),
            new SimpleMagneticPath(new Length(100))
        ];

        var route = new Route(segments, new Velocity(20));

        // Act
        SimulationResult res = route.RunSimulation(train);

        // Assert
        Assert.Equal(res, new SimulationResult.SimulationEndedWithFailure("Too much force was applied"));
    }

    [Fact]
    public void Simulation_ForceLessThenStationLimitAndLessThenRouteLimit_EndedCorrectly()
    {
        // Arrange
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

        // Act
        SimulationResult res = route.RunSimulation(train);

        // Assert
        Assert.Equal(res, new SimulationResult.SimulationEndedCorrectly(new Time(65)));
    }

    [Fact]
    public void Simulation_ForceMoreThenStationLimit_EndedWithFailure()
    {
        // Arrange
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

        // Act
        SimulationResult res = route.RunSimulation(train);

        // Assert
        Assert.Equal(res, new SimulationResult.SimulationEndedWithFailure("Too high velocity"));
    }

    [Fact]
    public void Simulation_ForceLessThenStationLimitAndMoreThenRouteLimit_EndedWithFailure()
    {
        // Arrange
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

        // Act
        SimulationResult res = route.RunSimulation(train);

        // Assert
        Assert.Equal(res, new SimulationResult.SimulationEndedWithFailure("Too much speed for the end of the route"));
    }

    [Fact]
    public void Simulation_PowerMagneticPathsWhichApplyPositiveAndNegativeForce_EndedCorrectly()
    {
        // Arrange
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

        // Act
        SimulationResult res = route.RunSimulation(train);

        // Assert
        Assert.Equal(res, new SimulationResult.SimulationEndedCorrectly(new Time(131)));
    }

    [Fact]
    public void Simulation_NoForceSimpleMagneticPath_EndedWithFailure()
    {
        // Arrange
        var mass = new Mass(100);
        var force = new Force(10);
        var precisionTime = new Time(2);

        var train = new SimpleTrain(mass, force, precisionTime);

        IEnumerable<IRouteSegment> segments =
        [
            new SimpleMagneticPath(new Length(100))
        ];

        var route = new Route(segments, new Velocity(100));

        // Act
        SimulationResult res = route.RunSimulation(train);

        // Assert
        Assert.Equal(res, new SimulationResult.SimulationEndedWithFailure("The velocity is 0, the train has stopped"));
    }

    [Fact]
    public void Simulation_NegativeForce_EndedWithFailure()
    {
        // Arrange
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

        // Act
        SimulationResult res = route.RunSimulation(train);

        // Assert
        Assert.Equal(res, new SimulationResult.SimulationEndedWithFailure("The velocity is 0, the train has stopped"));
    }
}