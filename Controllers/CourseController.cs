using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.Models;
using SchoolManagementApp.Repositories.Courses;

namespace SchoolManagementApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Course> courses = _courseRepository.GetAllCourses();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (course != null)
            {
                _courseRepository.Create(course);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int courseId)
        {
            _courseRepository.Delete(courseId);
            return View();
        }
    }
}
