using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.Models;
using SchoolManagementApp.Repositories.Students;

namespace SchoolManagementApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        //list of students
        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = _studentRepository.GetAllStudents();
            return View();
        }

        //Runder the view to create a new student
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            //save the student to the database
            _studentRepository.Create(student);
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int studentId)
        {
            //delete the student from the database
            _studentRepository.Delete(studentId);
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(int studentId, int courseId)
        {
            //register the student to the course
            _studentRepository.Register(studentId, courseId);
            return View();
        }
    }
}
