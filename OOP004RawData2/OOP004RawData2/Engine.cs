namespace OOP004RawData2
{
    public class Engine
    {
        public string model;
        public int power;
        public string displacement;
        public string efficiency;

        public Engine(string model, int power) 
            : this(model, power, @"n\a", @"n\a")
        {
            
        }

        public Engine(string model, int power, string displacement) 
            : this(model, power, displacement, @"n\a")
        {
            
        }

        public Engine(string model, string efficiency, int power) 
            : this(model, power, @"n\a", efficiency)
        {
            
        }
        
        
        public Engine(string model, int power, string displacement, string efficiency)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }
    }
}