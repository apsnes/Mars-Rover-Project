using FluentAssertions;
using Mars_Rover_Project;
using Mars_Rover_Project.Input;

namespace Mars_Rover_Project_Tests
{
    public class Tests
    {
        [Test]
        public void Test_Valid_Plateau_Size()
        {
            //Arrange
            PlateauSize ExpectedPlateau = new PlateauSize(5, 6);

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
            PlateauSize ExpectedPlateau = new PlateauSize(100, 100);

            //Act
            PlateauSize OutputPlateau = InputParser.ParsePlateauSize("100", "100");

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
    }
}