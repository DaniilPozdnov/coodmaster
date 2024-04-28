using System.ComponentModel.DataAnnotations;
using WebApplication11.Data;

namespace WebApplication11.Models.Validators
{
    public class NameExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || validationContext == null) return null;

            if(validationContext.ObjectInstance == null || 
                    !(validationContext.ObjectInstance  is not StudentModel))
            {
                return null;
                //throw new ArgumentException("NameExistsAttribute contains wrong object");
            }

            var student = validationContext.ObjectInstance as StudentModel;

            var ctx = validationContext.GetService<ApplicationDbContext>();
            if(ctx.Students.Any(s => s.Id != student.Id && s.Name == value.ToString()))
            {
                return new ValidationResult("Name exists");
            }
            return ValidationResult.Success;
        }
    }
}
