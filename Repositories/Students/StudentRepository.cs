using SchoolManagementApp.Context;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Repositories.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyDbContext _myDbConnection;
        public StudentRepository(MyDbContext myDbContext)
        {
            _myDbConnection = myDbContext;
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> students = _myDbConnection.Students.ToList();
                return students;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Create(Student student)
        {
            try
            {
                _myDbConnection.Students.Add(student);
                _myDbConnection.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int studentId)
        {
            try
            {
                _myDbConnection.Students.Remove(_myDbConnection.Students.Find(studentId));
                _myDbConnection.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        public void Register(int studentId, int courseId)
        {
            try
            {
                _myDbConnection.StudentCourses.Add(new StudentCourse
                {
                    StudentId = studentId,
                    CourseId = courseId
                });
                _myDbConnection.SaveChanges();

            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
