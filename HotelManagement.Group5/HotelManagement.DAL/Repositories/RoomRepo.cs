using HotelManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAL.Repositories
{
    public class RoomRepo
    {
        private HotelContext _context;

        public List<Room> GetAllRooms()
        {
            _context = new HotelContext();
            return _context.Rooms.ToList();
        }

        public List<Room> GetRoomsByStatus(string status)
        {
            _context = new HotelContext();
            return _context.Rooms.ToList().FindAll(r => r.RoomStatus == status);
        }

        public Room? GetRoomByNumber(int number) 
        {
            _context = new HotelContext();
            return _context.Rooms.FirstOrDefault(r => r.RoomNumber == number);
        }

        public void Update(Room room)
        {
            _context = new();
            _context.Rooms.Update(room);
        }

    }
}
