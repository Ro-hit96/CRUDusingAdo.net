using System.ComponentModel.DataAnnotations;

namespace CRUDMVC.Models
{
    public class Student
    {
        public int Roll_No { get; set; }
        [Required]
        public String? Sname { get; set; }
        [Required]
        public String? City { get; set; }
        [Required]
        public int SPercentage { get; set; }
    }
}
