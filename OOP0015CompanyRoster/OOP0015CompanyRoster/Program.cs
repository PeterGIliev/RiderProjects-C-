using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP0015CompanyRoster
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var numberOfLines = int.Parse(Console.ReadLine());
            var employees = new List<Employee>();

            for (int i = 0; i < numberOfLines; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var name = tokens[0];
                var salaray = double.Parse(tokens[1]);
                var position = tokens[2];
                var department = tokens[3];
                var email = "n/a";
                var age = -1;

                if (tokens.Length == 6)
                {
                    email = tokens[4];
                    age = int.Parse(tokens[5]);
                }

                if (tokens.Length == 5)
                {
                    bool ageExists = int.TryParse(tokens[4], out age);
                    
                    if (!ageExists)
                    {
                        email = tokens[4];
                        age = -1;
                    }
                }
                var employee = new Employee(name, salaray, position, department, email, age);
                
                employees.Add(employee);
            }

            var resultDepartment = employees.GroupBy(e => e.Department)
                .Select(e => new
                {
                    Department = e.Key,
                    AverageSalary = e.Average(emp => emp.Salary),
                    Employee = e
                })
                .OrderByDescending(e => e.AverageSalary)
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {resultDepartment.Department}");

            foreach (var employee in resultDepartment.Employee.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }
    }
}