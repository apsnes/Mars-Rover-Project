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
        Rover myRover = new Rover(startingPosition, 1);
        Position ExpectedPosition = new(1, 3, Direction.North);

        //Act
        myRover.Instruct(Instruction.L);
        myRover.Instruct(Instruction.M);
        myRover.Instruct(Instruction.L);
        myRover.Instruct(Instruction.M);
        myRover.Instruct(Instruction.L);
        myRover.Instruct(Instruction.M);
        myRover.Instruct(Instruction.L);
        myRover.Instruct(Instruction.M);
        myRover.Instruct(Instruction.M);

        //Assert
        myRover.Position.Should().BeEquivalentTo(ExpectedPosition);
    }
    [Test]
    public void Test_Integration2()
    {
        //Arrange
        InputParser.ParsePlateauSize("5", "5");
        Position yourStartingPosition = InputParser.ParsePosition("3", "3", "E");
        Rover yourRover = new Rover(yourStartingPosition, 2);
        Position ExpectedPosition = new(4, 1, Direction.East);

        //Act
        yourRover.Instruct(Instruction.M);
        yourRover.Instruct(Instruction.M);
        yourRover.Instruct(Instruction.R);
        yourRover.Instruct(Instruction.M);
        yourRover.Instruct(Instruction.M);
        yourRover.Instruct(Instruction.R);
        yourRover.Instruct(Instruction.M);
        yourRover.Instruct(Instruction.R);
        yourRover.Instruct(Instruction.R);
        yourRover.Instruct(Instruction.M);

        //Assert
        yourRover.Position.Should().BeEquivalentTo(ExpectedPosition);
    }
}
