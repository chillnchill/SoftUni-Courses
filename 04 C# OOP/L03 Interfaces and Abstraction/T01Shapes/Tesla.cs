
namespace Cars
{
    public class Tesla : IElectricCar
    {

        public Tesla(int battery, string model, string color)
        {
            Battery = battery;
            Model = model;
            Color = color;
        }

        public int Battery { get; }

        public string Model { get; }

        public string Color { get; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
    }
}
