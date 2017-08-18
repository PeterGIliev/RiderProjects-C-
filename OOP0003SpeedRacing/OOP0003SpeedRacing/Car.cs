using System;

namespace OOP0003SpeedRacing
{
    public class Car
    {
        public string Model;
        public decimal FuelAmount;
        public decimal FuelCostForKilometer;
        public decimal DistanceTraveled;

        public Car(string model, decimal fuelAmoun, decimal fuelCostForKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmoun;
            this.FuelCostForKilometer = fuelCostForKilometer;
            this.DistanceTraveled = 0;
        }

        public void Drive(decimal amountKM)
        {
            if (amountKM <= this.FuelAmount / this.FuelCostForKilometer)
            {
                this.DistanceTraveled += amountKM;
                this.FuelAmount -= this.FuelAmount * amountKM;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
    }
            
    }
}