using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP002CompanyRoster
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            
            var employeeList = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var name = input[0];
                var salary = decimal.Parse(input[1]);
                var position = input[2];
                var department = input[3];
                var email = "n/a";
                var age = -1;
                
                if (input.Length > 4)
                {
                    bool parameter = int.TryParse(input[4], out age);

                    if (!parameter && input.Length > 5)
                    {
                        email = input[4];
                        age = int.Parse(input[5]);
                        
                    } else if (!parameter && input.Length == 5)
                    {
                        email = input[4];
                    }
                }

                var employee = new Employee(name:name, salary:salary, position:position, department:department)
                {
                    age = age,
                    
                    email = email
                };
                
                employeeList.Add(employee);

            }
            
            var result = employeeList.GroupBy(e => e.department)
                .Select(e => new
                {
                    Department = e.Key,
                    AverageSalary = e.Average(emp => emp.salary),
                    Employees = e.OrderByDescending(emp => emp.salary),
                })
                .ToList();

            var re = result.OrderByDescending(ave => ave.AverageSalary)
                .First();

            Console.WriteLine($"Highest Average Salary: {re.Department}");

            foreach (var employee in re.Employees)
            {
                Console.WriteLine($"{employee.name} {employee.salary} {employee.email} {employee.age}");
            }
            

        }
    }
}