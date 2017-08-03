using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using  System.Text.RegularExpressions;

namespace L002SetsAndDictionaries
{
    public class L001ParkingLot
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine();
            var carsList = new SortedSet<string>();

            while (input != "END")
            {
                var tokens = Regex.Split(input, ", ");
                var direction = tokens[0];
                var carNumber = tokens[1];

                if (direction == "IN")
                {
                    carsList.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    carsList.Remove(carNumber);
                }

                input = Console.ReadLine();
            }

            if (carsList.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var number in carsList)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}