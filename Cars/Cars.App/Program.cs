using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Cars.Data;
using Cars.Data.Models;
using Cars.Seed;
using Newtonsoft.Json;

namespace Cars.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CarsDbContext();

            var carMake = context.Cars
                .GroupBy(c => c.Make.Name)
                .Select(g => new
                {
                    MakeName = g.Key,
                    Count = g.Count()
                });

            foreach (var element in carMake)
            {
                Console.WriteLine($"{element.MakeName} has {element.Count} number");
            }

//            Reset.ResetDatabase(context);
//
//            Console.WriteLine();

            //----------
            //Read xml from a file

            var xmlString = File.ReadAllText("xmlArray.xml");
            var xml = XDocument.Parse(xmlString);

            var root = xml.Root.Elements();

            foreach (XElement xElement in root)
            {
                var name = xElement.Element("Name").Value;
                var description = xElement.Element("Description")?.Value ?? "No description found!";
            }

        }
    }
}