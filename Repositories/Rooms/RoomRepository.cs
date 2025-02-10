using SchoolManagementApp.Context;
using SchoolManagementApp.Models;

namespace SchoolManagementApp.Repositories.Rooms
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyDbContext _context;

        public RoomRepository(MyDbContext context)
        {
            _context = context;
        }
        public void Create(Room room)
        {
            try
            {
                _context.Rooms.Add(room);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int roomId)
        {
            try
            {
                Room room = _context.Rooms.Find(roomId);
                if (room != null)
                {
                    _context.Rooms.Remove(room);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Room> GetAllRooms()
        {
            try { return _context.Rooms.ToList(); }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
