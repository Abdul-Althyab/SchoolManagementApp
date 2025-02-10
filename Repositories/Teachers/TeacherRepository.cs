using SchoolManagementApp.Context;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Repositories.Teachers
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyDbContext _context;

        public TeacherRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<Teacher> GetAllTeachers()
        {
            try
            {
                List<Teacher> teachers = _context.Teachers.ToList();
                return teachers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Create(Teacher teacher)
        {
            try
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int teacherId)
        {
            try
            {
                Teacher teacher = _context.Teachers.Find(teacherId);
                if (teacher != null)
                {
                    _context.Teachers.Remove(teacher);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
