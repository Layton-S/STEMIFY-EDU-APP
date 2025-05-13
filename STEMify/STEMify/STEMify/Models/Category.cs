using System.ComponentModel.DataAnnotations.Schema;

namespace STEMify.Models
{
    [Table("Category")] // 👈 force EF to use this exact table name

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        //public ICollection<Course> Courses { get; set; }
    }

}
