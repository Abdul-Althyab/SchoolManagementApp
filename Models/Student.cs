using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementApp.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string StudentName { get; set; }
        public bool IsActive { get; set; }
        [Range(5, 18)]
        public int StudentAge { get; set; }
        public string StudentPhoto { get; set; }

    }
}
