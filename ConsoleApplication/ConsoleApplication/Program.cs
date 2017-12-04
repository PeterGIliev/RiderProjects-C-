using System;
using P03_FootballBetting.Data;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new FootballBettingContext();

//            context.Database.EnsureDeleted();
//            
            context.Database.EnsureCreated();
        }
    }
}