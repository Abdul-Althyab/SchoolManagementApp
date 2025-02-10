using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.Models;
using SchoolManagementApp.Repositories.Rooms;

namespace SchoolManagementApp.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View();
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Room room)
        {
            if (room != null)
            {
                _roomRepository.Create(room);
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int roomId)
        {
            _roomRepository.Delete(roomId);
            return View();
        }
    }
}
