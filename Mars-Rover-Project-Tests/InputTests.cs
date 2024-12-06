using FluentAssertions;
using Mars_Rover_Project;
using Mars_Rover_Project.Input;
using Mars_Rover_Project.Enums;

namespace Mars_Rover_Project_Tests
{
    public class InputTests
    {
        [Test]
        public void Test_Valid_Plateau_Size()
        {
            //Arrange
            PlateauSize ExpectedPlateau = PlateauSize.SetInstance(5, 6);

            //Act
            PlateauSize OutputPlateau = InputParser.ParsePlateauSize("5", "6");

            //Assert
            ExpectedPlateau.Should().BeEquivalentTo(OutputPlateau);
        }
        [Test]
        public void Test_Invalid_Plateau_Size()
        {
            //Arrange

            //Act
            Action act = () => InputParser.ParsePlateauSize("5", "-6");

            //Assert
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void Test_Invalid_Plateau_Size_0()
        {
            //Arrange

            //Act
            Action act = () => InputParser.ParsePlateauSize("0", "0");

            //Assert
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void Test_Plateau_Too_Large()
        {
            //Arrange

            //Act
            Action act = () => InputParser.ParsePlateauSize("101", "101");

            //Assert
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void Test_Plateau_Max_Size()
        {
            //Arrange
            PlateauSize ExpectedPlateau = PlateauSize.SetInstance(20, 20);

            //Act
            PlateauSize OutputPlateau = InputParser.ParsePlateauSize("20", "20");

            //Assert
            OutputPlateau.Should().BeEquivalentTo(ExpectedPlateau);
        }
        [Test]
        public void Test_Plateau_Non_Integer()
        {
            //Arrange

            //Act
            Action act = () => InputParser.ParsePlateauSize("sdfs", "!!");

            //Assert
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void Test_Valid_Position()
        {
            //Arrange
            Position ExpectedPosition = new Position(20, 20, Direction.East);

            //Act
            Position OutputPosition = InputParser.ParsePosition("20", "20", "E");

            //Assert
            OutputPosition.Should().BeEquivalentTo(ExpectedPosition);
        }
        [Test]
        public void Test_Invalid_Position()
        {
            //Arrange

            //Act
            Action act = () => InputParser.ParsePosition("-20", "20", "N");

            //Assert
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void Test_Invalid_Direction_Position()
        {
            //Arrange

            //Act
            Action act = () => InputParser.ParsePosition("20", "20", "F");

            //Assert
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void Test_Position_Non_Integer()
        {
            //Arrange

            //Act
            Action act = () => InputParser.ParsePosition("dfg0", "20", "F");

            //Assert
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void Test_Position_Too_Large()
        {
            //Arrange

            //Act
            Action act = () => InputParser.ParsePosition("111", "20", "N");

            //Assert
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void Test_Position_Max_Size()
        {
            //Arrange
            Position ExpectedPosition = new Position(20, 20, Direction.North);

            //Act
            Position OutputPosition = InputParser.ParsePosition("20", "20", "N");

            //Assert
            OutputPosition.Should().BeEquivalentTo(ExpectedPosition);
        }
        [Test]
        public void Test_Valid_Direction()
        {
            //Arrange
            Direction ExpectedDirection = Direction.West;

            //Act
            Direction OutputDirection = InputParser.ParseDirection("W");

            //Assert
            OutputDirection.Should().Be(ExpectedDirection);
        }
        [Test]
        public void Test_Invalid_Direction()
        {
            //Arrange

            //Act
            Action act = () => InputParser.ParseDirection("F");

            //Assert
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void Test_Valid_Instruction()
        {
            //Arrange
            Instruction ExpectedInstruction = Instruction.M;

            //Act
            Instruction OutputInstruction = InputParser.ParseInstruction("M");

            //Assert
            OutputInstruction.Should().Be(ExpectedInstruction);
        }
        [Test]
        public void Test_Invalid_Instruction()
        {
            //Arrange

            //Act
            Action act = () => InputParser.ParseInstruction("Move");

            //Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}