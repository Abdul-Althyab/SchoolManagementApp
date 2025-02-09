using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementApp.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        [MinLength(3)]
        [MaxLength(50)]
        public string? TeacherName { get; set; }
        [Range(25, 60)]
        public int TeacherAge { get; set; }
    }
}
