namespace OOP005CarSalesman
{
    public class Car
    {
        public string CarModel;
        public string Engine;
        public string Weight;
        public string Color;

        public Car(string carModel, string engine)
        {
            this.CarModel = carModel;
            this.Engine = engine;
            this.Weight = "n/a";
            this.Color = "n/a";
        }
    }
}