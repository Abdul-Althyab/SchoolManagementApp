using SchoolManagementApp.Models;

namespace SchoolManagementApp.Repositories
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public void Create(Student student);
        public void Delete(int studentId);
        public void Register(int studentId, int courseId);
    }
}
