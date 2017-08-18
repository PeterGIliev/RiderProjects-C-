using System;
using System.Collections.Generic;

namespace OOP0005PokemonTrainer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "Tournament")
            {
                var tokens = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var trainerName = tokens[0];
                var pokemonName = tokens[1];
                var pokemonElement = tokens[2];
                var pokemonHealth = tokens[3];
                
                
            }
        }
    }
}