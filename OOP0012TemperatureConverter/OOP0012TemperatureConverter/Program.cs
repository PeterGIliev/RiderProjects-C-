using System;
using System.Collections.Generic;

namespace OOP0012TemperatureConverter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var tokens = input
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var measurement = double.Parse(tokens[0]);
                var MeasurementSystem = tokens[1];
                var outputSystem = "Celsius";

                var conversion = new Conversion();

                var result = conversion.ConversionMethod(measurement, MeasurementSystem);

                if (MeasurementSystem == "Celsius")
                {
                    outputSystem = "Fahrenheit";
                }

                Console.WriteLine($"{result:F2} {outputSystem}");

                input = Console.ReadLine();

            }

        }
    }
}