namespace OOP005CarSalesman
{
    public class Engine
    {
        public string EngineModel;
        public int Power;
        public string Displacement;
        public string Efficiency;

        public Engine(string engineModel, int power)
        {
            this.EngineModel = engineModel;
            this.Power = power;
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }
    }
}