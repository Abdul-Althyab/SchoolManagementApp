﻿using Microsoft.AspNetCore.Mvc;
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
            return View(rooms);
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
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View("Index", rooms);
        }

        public ActionResult Delete(int id)
        {
            _roomRepository.Delete(id);
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View("Index", rooms);
        }
    }
}
