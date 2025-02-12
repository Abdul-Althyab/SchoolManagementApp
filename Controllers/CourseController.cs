using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.Models;
using SchoolManagementApp.Repositories.Courses;
using SchoolManagementApp.Repositories.Teachers;

namespace SchoolManagementApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;

        public CourseController(ICourseRepository courseRepository, ITeacherRepository teacherRepository)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Course> courses = _courseRepository.GetAllCourses();
            return View(courses);
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View(teachers);
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (course != null)
            {
                _courseRepository.Create(course);
                return RedirectToAction("Index");
            }
            List<Course> courses = _courseRepository.GetAllCourses();
            return View("Index", courses);
        }

        public IActionResult Delete(int id)
        {
            _courseRepository.Delete(id);
            List<Course> courses = _courseRepository.GetAllCourses();
            return View("Index", courses);
        }
    }
}
