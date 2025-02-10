using SchoolManagementApp.Models;

namespace SchoolManagementApp.Repositories.Teachers
{
    public interface ITeacherRepository
    {
        public List<Teacher> GetAllTeachers();
        public void Create(Teacher teacher);
        public void Delete(int teacherId);
    }
}
