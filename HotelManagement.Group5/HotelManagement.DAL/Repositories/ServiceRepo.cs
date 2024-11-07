using HotelManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAL.Repositories
{
    public class ServiceRepo
    {
        private HotelContext _context;

        public List<Service> GetAllService()
        {
            _context = new HotelContext();
            return _context.Services.ToList();
        }

        public Service? GetServiceByID(int id)
        {
            _context = new();
            return _context.Services.ToList().FirstOrDefault(s => s.ServiceId == id);
        }

        public void AddService(Service service) 
        {
            _context = new();
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void UpdateService(Service service) 
        { 
            _context = new();
            _context.Services.Update(service);
            _context.SaveChanges();
        }

        public void RemoveService(int id) 
        {
            _context = new();
            _context.Services.Remove(GetServiceByID(id));
            _context.SaveChanges();
        }
    }
}
