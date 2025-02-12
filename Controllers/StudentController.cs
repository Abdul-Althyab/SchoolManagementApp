using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.Models;
using SchoolManagementApp.Models.ViewModels;
using SchoolManagementApp.Repositories.Courses;
using SchoolManagementApp.Repositories.Students;

namespace SchoolManagementApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        public StudentController(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }
        //list of students
        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = _studentRepository.GetAllStudents();
            return View(students);
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
            List<Student> students = _studentRepository.GetAllStudents();
            return View("Index", students);
        }

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Geen geldig ID meegegeven");
            }

            _studentRepository.Delete(id);
            List<Student> students = _studentRepository.GetAllStudents();
            return View("Index", students);
        }

        [HttpGet]
        public ActionResult Register()
        {
            StudentCourseVM studentCourseVM = new StudentCourseVM();
            studentCourseVM.Students = _studentRepository.GetAllStudents();
            studentCourseVM.Courses = _courseRepository.GetAllCourses();
            return View(studentCourseVM);
        }
        [HttpPost]
        public ActionResult Register(int studentId, int courseId)
        {
            //register the student to the course
            _studentRepository.Register(studentId, courseId);
            return RedirectToAction("Register");
        }
    }
}
