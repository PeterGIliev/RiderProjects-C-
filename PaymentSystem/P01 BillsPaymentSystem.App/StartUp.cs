using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using P01_BillsPaymentSystem.Data;

namespace P01_BillsPaymentSystem.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new BillsPaymentSystemContext();

            Console.WriteLine("HELLO");
//            context.Database.EnsureCreated();
            
//            services.AddDbContext<BillsPaymentSystemContext>(options =>
//                options.UseSqlServer(Configuration["Configuration:ConnectionString"],
//                    b => b.MigrationsAssembly("P01' 'BillsPaymentSystem.App")));
            
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BillsPaymentSystemContext>(options =>
                options.UseSqlServer(
                    @"Server=localhost;Database=PaymentSystemTest ;User ID=sa;Password=Peter@76545759"));

        }
    }
}