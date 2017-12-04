using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Models;
using P03_FootballBetting.Data.Validation;

namespace FootballBetting
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new FootballBettingContext();

//            context.Database.EnsureDeleted();
//            
//            context.Database.EnsureCreated();

            try
            {
                
            var bet = new Bet()
            {
                Amount = 268
            };

            ValudateBetAmount.Validation(bet, context);

            
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        
    }
}