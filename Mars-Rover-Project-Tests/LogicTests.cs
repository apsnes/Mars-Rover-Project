using FluentAssertions;
using Mars_Rover_Project.Logic;
using Mars_Rover_Project;
using Mars_Rover_Project.Enums;
using Mars_Rover_Project.Input;
using Mars_Rover_Project.Logic;

namespace Mars_Rover_Project_Tests;

public class LogicTests
{
    [Test]
    public void Test_Change_Direction_CCW()
    {
        //Arrange
        Position pos = new(0, 0, Direction.North);
        Rover testRover = new(pos, 1);

        //Act
        testRover.ChangeDirection("W");

        //Assert
        testRover.Position.Direction.Should().Be(Direction.West);
    }
    [Test]
    public void Test_Change_Direction_Invalid()
    {
        //Arrange
        Position pos = new(0, 0, Direction.North);
        Rover testRover = new(pos, 1);

        //Act
        Action act = () => testRover.ChangeDirection("D");

        //Assert
        act.Should().Throw<ArgumentException>();
    }
    [Test]
    public void Test_Update_Position_Valid()
    {
        //Arrange
        Position pos = new Position(0, 0, Direction.East);

        //Act
        pos.UpdatePosition();

        //Assert
        pos.X.Should().Be(1);
    }
    [Test]
    public void Test_Rover_Move_Valid_Location()
    {
        //Arrange
        PlateauSize.SetInstance(20, 20);
        Position pos = new(0, 0, Direction.North);
        Rover testRover = new(pos, 1);

        //Act
        testRover.Move();

        //Assert
        testRover.Position.Y.Should().Be(1);
    }
    [Test]
    public void Test_Rover_Turn_Left()
    {
        //Arrange
        Position pos = new(0, 0, Direction.North);
        Rover testRover = new(pos, 1);

        //Act
        testRover.Instruct(Instruction.L);

        //Assert
        testRover.Position.Direction.Should().Be(Direction.West);
    }
    [Test]
    public void Test_Rover_Turn_Right()
    {
        //Arrange
        Position pos = new(0, 0, Direction.East);
        Rover testRover = new(pos, 1);

        //Act
        testRover.Instruct(Instruction.R);

        //Assert
        testRover.Position.Direction.Should().Be(Direction.South);
    }
}
