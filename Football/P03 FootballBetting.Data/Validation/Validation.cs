using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace P03_FootballBetting.Data.Validation
{
    public class Validation
    {
        public static bool IsValid(object obj, out List<string> validationErrors)
        {
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, new ValidationContext(obj),
                validationResults, true);

            
            validationErrors = validationResults.Select(vr => vr.ErrorMessage).ToList();
           
            return isValid;
        }
    }
}