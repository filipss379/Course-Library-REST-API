using RESTful_API.ValidatinoAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_API.Models
{
    [CourseTitleMustBeDiffrentFromDescription(
        ErrorMessage = "Title must be diffrent from description.")]
    public class CourseForCreationDto
    {
        [Required(ErrorMessage = "You should fill out a title.")]
        [MaxLength(100, ErrorMessage = "The title shouldn't have more than 100 characters")]
        public string Title { get; set; }
        [MaxLength(1500, ErrorMessage = "The description shouldn't have more than 1500 characters")]
        public string Description { get; set; }

    }
}

