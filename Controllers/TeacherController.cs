using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.Models;
using SchoolManagementApp.Repositories.Teachers;

namespace SchoolManagementApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View();
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            if (teacher != null)
            {
                _teacherRepository.Create(teacher);
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int teacherId)
        {
            _teacherRepository.Delete(teacherId);
            return View();
        }
    }
}
