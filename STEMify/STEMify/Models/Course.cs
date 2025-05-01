using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STEMify.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        [Required]
        public string CourseName { get; set; }

        public string CourseCode { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public int DifficultyLevelID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsActive { get; set; } 
    }
}