using RESTful_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_API.ValidatinoAttributes
{
    public class CourseTitleMustBeDiffrentFromDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            var course = (CourseForManipulationDto)validationContext.ObjectInstance;

            if (course.Title == course.Description)
            {
                return new ValidationResult(
                    ErrorMessage,
                    new[] { "CourseForManipulationDto" });
            }

            return ValidationResult.Success;
        }
    }
}
