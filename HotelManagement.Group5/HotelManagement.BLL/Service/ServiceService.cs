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
    public class ServiceService
    {
        private ServiceRepo _repo = new();
        public List<DAL.Entities.Service> GetAllService() => _repo.GetAllService();

        public DAL.Entities.Service? GetServiceByID(int id) => _repo.GetServiceByID(id);

        public void AddService(DAL.Entities.Service service) => _repo.AddService(service);

        public void UpdateService(DAL.Entities.Service service) => _repo.UpdateService(service);

        public void RemoveService(int id) => _repo.RemoveService(id);
    }
}
