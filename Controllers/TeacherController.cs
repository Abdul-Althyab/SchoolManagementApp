using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Controllers
{
    public class TeacherController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
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

            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int teacherId)
        {
            return View();
        }
    }
}
