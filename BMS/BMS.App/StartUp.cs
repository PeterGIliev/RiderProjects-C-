using System;
using BMS.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace BMS.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new BmsDbContext();

            context.Database.EnsureCreated();
        }
    }
}