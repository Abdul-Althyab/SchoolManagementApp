using SchoolManagementApp.Models;

namespace SchoolManagementApp.Repositories.Rooms
{
    public interface IRoomRepository
    {
        List<Room> GetAllRooms();
        void Create(Room room);
        void Delete(int roomId);
    }
}
