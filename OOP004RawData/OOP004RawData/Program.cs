using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP004RawData
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < N; i++)
            {
                var carProperties = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                
                var model = carProperties[0];
                var engineSpeed = int.Parse(carProperties[1]);
                var enginePower = int.Parse(carProperties[2]);
                var cargoWeight = int.Parse(carProperties[3]);
                var cargoType = carProperties[4];
                var tire1Pressure = double.Parse(carProperties[5]);
                var tire1Age = int.Parse(carProperties[6]);
                var tire2Pressure = double.Parse(carProperties[7]);
                var tire2Age = int.Parse(carProperties[8]);
                var tire3Pressure = double.Parse(carProperties[9]);
                var tire3Age = int.Parse(carProperties[10]);
                var tire4Pressure = double.Parse(carProperties[11]);
                var tire4Age = int.Parse(carProperties[12]);
                
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire [] tire = new Tire[4];
                tire[0] = new Tire(tire1Pressure, tire1Age);
                tire[1] = new Tire(tire2Pressure, tire2Age);
                tire[2] = new Tire(tire3Pressure, tire3Age);
                tire[3] = new Tire(tire4Pressure, tire4Age);
                Car car = new Car(model, engine, cargo, tire);
                
                cars.Add(car);

            }

            var cargoTypeForPrint = Console.ReadLine();
            var sortedCars = new List<Car>();

            if (cargoTypeForPrint == "fragile")
            {
                sortedCars = cars.Where(c => c.Cargo.CargoType == "fragile"
                                        && c.Tire.Any(t=>t.Pressure < 1))
                                        .ToList();
            }
            else
            {
                sortedCars = cars.Where(c => c.Cargo.CargoType == "flamable"
                                        && c.Engine.EnginePower > 250)
                                        .ToList();
            }

            foreach (var car in sortedCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}