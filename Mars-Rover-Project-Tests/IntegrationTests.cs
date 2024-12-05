using Mars_Rover_Project.Input;
using Mars_Rover_Project.Logic;
using Mars_Rover_Project.Enums;
using Mars_Rover_Project;
using FluentAssertions;

namespace Mars_Rover_Project_Tests;

public class IntegrationTests
{
    [Test]
    public void Test_Integration1()
    {
        //Arrange
        InputParser.ParsePlateauSize("5", "5");
        Position startingPosition = InputParser.ParsePosition("1", "2", "N");
        Rover myRover = new Rover(startingPosition.X, startingPosition.Y, startingPosition.Direction);
        Position ExpectedPosition = new(1, 3, Direction.North);

        //Act
        myRover.Instruct("L");
        myRover.Instruct("M");
        myRover.Instruct("L");
        myRover.Instruct("M");
        myRover.Instruct("L");
        myRover.Instruct("M");
        myRover.Instruct("L");
        myRover.Instruct("M");
        myRover.Instruct("M");

        //Assert
        myRover.Position.Should().BeEquivalentTo(ExpectedPosition);
    }
    [Test]
    public void Test_Integration2()
    {
        //Arrange
        InputParser.ParsePlateauSize("5", "5");
        Position yourStartingPosition = InputParser.ParsePosition("3", "3", "E");
        Rover yourRover = new Rover(yourStartingPosition.X, yourStartingPosition.Y, yourStartingPosition.Direction);
        Position ExpectedPosition = new(5, 1, Direction.East);

        //Act
        yourRover.Instruct("M");
        yourRover.Instruct("M");
        yourRover.Instruct("R");
        yourRover.Instruct("M");
        yourRover.Instruct("M");
        yourRover.Instruct("R");
        yourRover.Instruct("M");
        yourRover.Instruct("R");
        yourRover.Instruct("R");
        yourRover.Instruct("M");

        //Assert
        yourRover.Position.Should().BeEquivalentTo(ExpectedPosition);
    }
}
