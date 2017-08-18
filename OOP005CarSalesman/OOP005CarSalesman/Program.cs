using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP005CarSalesman
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var engineCounts = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();
            var cars = new List<Car>();

            for (int i = 0; i < engineCounts; i++)
            {
                var tokens = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                
                var engineModel = tokens[0];
                var power = int.Parse(tokens[1]);
                var displacement = string.Empty;
                var efficienty = string.Empty;

                if (tokens.Length > 3)
                {
                    displacement = tokens[2];
                    efficienty = tokens[3];
                }
                else if (tokens.Length > 2)
                {
                    var temp = 0;
                    bool checkDisplacement = int.TryParse(tokens[2], out temp);

                    if (checkDisplacement)
                    {
                        displacement = temp.ToString();
                        efficienty = "n/a";
                    }
                    else
                    {
                        displacement = "n/a";
                        efficienty = tokens[2];
                    }
                    
                }
                else
                {
                    displacement = "n/a";
                    efficienty = "n/a";
                }
                
                var engine = new Engine(engineModel, power)
                {
                    Displacement = displacement,
                    Efficiency = efficienty
                };
                
                engines.Add(engine);
            }

            var carCounts = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCounts; i++)
            {
                var tokens2 = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var carModel = tokens2[0];
                var engine = tokens2[1];
                var weight = string.Empty;
                var color = string.Empty;
                
                if (tokens2.Length > 3)
                {
                    weight = tokens2[2];
                    color = tokens2[3];
                }
                else if (tokens2.Length > 2)
                {
                    var temp = 0;
                    bool checkWight = int.TryParse(tokens2[2], out temp);

                    if (checkWight)
                    {
                        weight = temp.ToString();
                        color = "n/a";
                    }
                    else
                    {
                        weight = "n/a";
                        color = tokens2[2];
                    }
                }
                else
                {
                    weight = "n/a";
                    color = "n/a";
                }
                
                var car = new Car(carModel, engine)
                {
                    Weight = weight,
                    Color = color
                };
                
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.CarModel}:");
                Console.WriteLine($"  {car.Engine}:");

                var p = engines.Where(e => e.EngineModel == car.Engine).Select(e => e.Power).First();
                Console.WriteLine($"    Power: {p}");
                
                var dis = engines.Where(e => e.EngineModel == car.Engine).Select(e => e.Displacement).First();
                Console.WriteLine($"    Displacement: {dis}");
                
                var eff = engines.Where(e => e.EngineModel == car.Engine).Select(e => e.Efficiency).First();
                Console.WriteLine($"    Efficiency: {eff}");

                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}