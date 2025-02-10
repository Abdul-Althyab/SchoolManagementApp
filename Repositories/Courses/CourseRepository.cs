using SchoolManagementApp.Context;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Repositories.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly MyDbContext _context;

        public CourseRepository(MyDbContext context)
        {
            _context = context;
        }
        public void Create(Course course)
        {
            try
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public void Delete(int courseId)
        {
            try
            {
                Course course = _context.Courses.Find(courseId);
                if (course != null)
                {
                    _context.Courses.Remove(course);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Course> GetAllCourses()
        {
            try
            {
                return _context.Courses.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
