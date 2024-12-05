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
        Rover testRover = new();

        //Act
        testRover.ChangeDirection("W");

        //Assert
        testRover.Position.Direction.Should().Be(Direction.West);
    }
    [Test]
    public void Test_Change_Direction_Invalid()
    {
        //Arrange
        Rover testRover = new();

        //Act
        Action act = () => testRover.ChangeDirection("D");

        //Assert
        act.Should().Throw<ArgumentException>();
    }
    [Test]
    public void Test_Update_Position_Invalid()
    {
        //Arrange
        Position pos = new Position(0, 0, Direction.South);        

        //Act
        Action act = () => pos.UpdatePosition();

        //Assert
        act.Should().Throw<InvalidOperationException>();
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
        PlateauSize.GetInstance(20, 20);
        Rover testRover = new(0, 0, Direction.North);

        //Act
        testRover.Move();

        //Assert
        testRover.Position.Y.Should().Be(1);
    }
}
