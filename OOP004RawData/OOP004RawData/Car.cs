namespace OOP004RawData
{
    public class Car
    {
        public string Model;
        public Engine Engine;
        public Cargo Cargo;
        public Tire[] Tire;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tire = tires;
        }
    }
}