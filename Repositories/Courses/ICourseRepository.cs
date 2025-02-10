using SchoolManagementApp.Models;

namespace SchoolManagementApp.Repositories.Courses
{
    public interface ICourseRepository
    {
        public List<Course> GetAllCourses();
        public void Create(Course course);
        public void Delete(int courseId);
    }
}
