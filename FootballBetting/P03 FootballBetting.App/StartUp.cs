using System;
using P03_FootballBetting.Data;

namespace P03_FootballBetting.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new FootballBettingContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}