namespace Mars_Rover_Project.Logic
{
    internal interface IVehicle
    {
        Position Position { get; set; }
        void ChangeDirection(string input);
        void Move();
    }
}