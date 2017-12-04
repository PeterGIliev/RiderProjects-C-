using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TeamBuilder.Models;
using TeamBulder.Data;

namespace TeamBuilder.App
{
    class StartUp
    {
        static void Main(string[] args)
        {

            var context = new TeamBuilderContext();


//            var user = new User()
//            {
//                Username = "Peter2",
//                Password = "ahj",
//                Gender = Gender.Male,
//                Age = 14
//                    
//            };
//
//            context.Users.Add(user);
//            context.SaveChanges();
            
            
                
                
            
            
            
            
            
            var human = new User()
            {
                Age = -20
            };
            
            var human2 = new User()
            {
                Age = 20
            };

            var human1ValidationResults = new List<string>();
            
            var human1IsValid = IsValid(human, out human1ValidationResults);
            
            var human2IsValid = IsValid(human2, out human1ValidationResults);

            Console.WriteLine(human1IsValid);
            Console.WriteLine(human2IsValid);
        }

        private static bool IsValid(object obj, out List<string> validationErrors)
        {
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, new ValidationContext(obj),
                validationResults, true);

            
            validationErrors = validationResults.Select(vr => vr.ErrorMessage).ToList();
           
            return isValid;
        }
    }
}