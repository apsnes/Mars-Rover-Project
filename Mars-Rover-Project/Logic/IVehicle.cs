namespace Mars_Rover_Project.Logic
{
    public interface IVehicle
    {
        Position Position { get; set; }
        void ChangeDirection(string input);
        void Move();
    }
}