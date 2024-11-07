using HotelManagement.DAL.Entities;
using HotelManagement.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BLL.Service
{
    public class RoomService
    {
        private RoomRepo _repo = new();

        public List<Room> GetAllRooms() => _repo.GetAllRooms();

        public List<Room> GetRoomsByStatus(string status) => _repo.GetRoomsByStatus(status);

        public Room? GetRoomByNumber(int number) => _repo.GetRoomByNumber(number);

        public void Update(Room room) => _repo.Update(room);
    }
}
