using System;
using Microsoft.EntityFrameworkCore.Storage;
using P01_HospitalDatabase.Data;
using P01_HospitalDatabase.Initializer;

namespace P01_HospitalDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseInitializer.ResetDatabase();

            using (var context = new HospitalContext())
            {
                DatabaseInitializer.SeedPatients(context, 100);
            }
        }
    }
}