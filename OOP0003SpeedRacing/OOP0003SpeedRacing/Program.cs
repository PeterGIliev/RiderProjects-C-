using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP0003SpeedRacing
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var autoPark = new List<Car>();

            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var model = input[0];
                var fuelAmount = decimal.Parse(input[1]);
                var fuelCostForKilometer = decimal.Parse(input[2]);
                
                var car = new Car(model, fuelAmount, fuelCostForKilometer);
                autoPark.Add(car);
                
            }

            var inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                var tokens = inputLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var carModel = tokens[1];
                var amountKM = decimal.Parse(tokens[2]);

                Car carToDrive = autoPark.First(c => c.Model == carModel);
                carToDrive.Drive(amountKM);
                    
                inputLine = Console.ReadLine();
            }

            foreach (var car in autoPark)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTraveled:F0}");
            }

        }  
    }
}