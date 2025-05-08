using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raja_Form_API.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateOnly DOB { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public bool IsEnrolled { get; set; }
        public string Subjects { get; set; }
        public string FavoriteColor { get; set; }
        public string ImagePath { get; set; }
        public string VideoPath { get; set; }
        public string AudioPath { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }

        [NotMapped]
        public IFormFile? Video { get; set; }

        [NotMapped]
        public IFormFile? Audio { get; set; }
    }
}
