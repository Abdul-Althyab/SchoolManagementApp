using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.Models;
using SchoolManagementApp.Models.ViewModels;
using SchoolManagementApp.Repositories.Courses;
using SchoolManagementApp.Repositories.Students;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SchoolManagementApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        public StudentController(IStudentRepository studentRepository, ICourseRepository courseRepository,
            IHostingEnvironment hostingEnvironment)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _hostingEnvironment = hostingEnvironment;
        }
        //list of students
        [HttpGet]
        public IActionResult Index()
        {
            //state management - viewdata, viewbag, tempdata
            // viewdata -store data for the current request
            // viewbag - store data for the current request

            // ViewBag.Title = "Student List";
            //ViewData["Title"] = "Student List";

            //get all students from the database
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
        public ActionResult Create(Student student, IFormFile studentPhoto)
        {
            var wwwrootPath = _hostingEnvironment.WebRootPath + "/studentPictures/";
            Guid guid = Guid.NewGuid();
            string fullPath = System.IO.Path.Combine(wwwrootPath, guid + studentPhoto.FileName);
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                studentPhoto.CopyTo(fileStream);
            }
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
            //tempdata - store data for the next request
            //TempData["test"] = 10;

            //register the student to the course
            _studentRepository.Register(studentId, courseId);
            return RedirectToAction("Register");

            //redirect to the teacher index page
            //return RedirectToAction("Index", "Teacher");
        }
    }
}
