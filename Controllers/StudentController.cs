using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Controllers
{
    public class StudentController : Controller
    {
        //list of students
        [HttpGet]
        public IActionResult Index()
        {
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
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int studentId)
        {
            //delete the student from the database
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
            return View();
        }
    }
}
