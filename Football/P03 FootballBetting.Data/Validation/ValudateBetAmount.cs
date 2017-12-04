using System;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Validation
{
    public class ValudateBetAmount
    {
        public static void Validation(Bet bet, FootballBettingContext context)
        {
            var validation = Data.Validation.Validation.IsValid(bet, out var result);

            if (!validation)
            {
                throw new ArgumentException("Amount must be positive and less than 200");
            }

            context.Bets.Add(bet);
            context.SaveChanges();

        }
        
    }
}