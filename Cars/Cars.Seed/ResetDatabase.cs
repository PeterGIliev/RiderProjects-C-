using System;
using Cars.Data;
using Cars.Data.Models;

namespace Cars.Seed
{
    public class Reset
    {


        public static void ResetDatabase(CarsDbContext context)
        {
            context.Database.EnsureDeleted();

          

            Seed(context);
        }
        
        private static void Seed(CarsDbContext context)
        {
            var makes = new[]
            {
                new Make() {Name = "Ford"},
                new Make() {Name = "Mercedes"},
                new Make() {Name = "Audi"},
                new Make() {Name = "BMW"},
                new Make() {Name = "АЗЛК"},
                new Make() {Name = "Лада"},
                new Make() {Name = "Трабант"},
            };

            var engines = new[]
            {
                new Engine() {Capacity = 1.6, Cyllinder = 4, FuelType = FuelType.Petrol, HorsePower = 95}, 
                new Engine() {Capacity = 3.0, Cyllinder = 8, FuelType = FuelType.Diesel, HorsePower = 318}, 
                new Engine() {Capacity = 1.2, Cyllinder = 3, FuelType = FuelType.Gas, HorsePower = 60}, 
            };
            
            var cars = new[]
            {
                new Car(){Engine = engines[2], Make = makes[6], Doors = 4, Model = "Стар", ProductionYear = new DateTime(1958, 1, 1), Transmission = Transmission.Manual},
                new Car(){Engine = engines[1], Make = makes[4], Doors = 3, Model = "Стар 2", ProductionYear = new DateTime(1954, 1, 1), Transmission = Transmission.Automatic},
                new Car(){Engine = engines[0], Make = makes[0], Doors = 4, Model = "Escort", ProductionYear = new DateTime(1955, 1, 1), Transmission = Transmission.Manual},
            };
            
            context.Cars.AddRange(cars);
            
            var dealerships = new []
            {
                new Dealership(){Name = "Softuni-Car"},
                new Dealership(){Name = "Fast and Furious"},
            };
            
            context.Dealerships.AddRange(dealerships);

            var carsdealerships = new[]
            {
                new CarDealership(){Car = cars[0], Dealership = dealerships[0]}, 
                new CarDealership(){Car = cars[1], Dealership = dealerships[1]}, 
                new CarDealership(){Car = cars[0], Dealership = dealerships[1]}, 
            };
            
            context.CarDealerships.AddRange(carsdealerships);

            var licenseplates = new[]
            {
                new LicensePlate() {Number = "СА1265КМ"},
                new LicensePlate() {Number = "СА7654ХТ"},
                new LicensePlate() {Number = "СА4254АВ"},
            };

            context.LicensePlates.AddRange(licenseplates);

            context.SaveChanges();
        }
    }
}