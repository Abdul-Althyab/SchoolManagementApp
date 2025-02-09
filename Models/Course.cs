using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementApp.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        [MinLength(3)]
        [MaxLength(50)]
        public string? CourseName { get; set; }
        public int TeacherId { get; set; }
        // To Make teacherId a foreign key
        // Add a Teacher property
        public Teacher Teacher { get; set; }
        [Range(0, 25)]
        public int CourseCapacity { get; set; }
    }
}
