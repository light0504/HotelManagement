using HotelManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAL.Repositories
{
    public class ServiceDetailRepo
    {
        private HotelContext _context;

        public List<ServiceDetail> GetAllRoomService() 
        {
            _context = new HotelContext();
            return _context.ServiceDetails.ToList();
        }
        public List<ServiceDetail> GetServiceDetailsByRoomNumber(int roomNumber) 
        {
            _context = new HotelContext();
            return _context.ServiceDetails.ToList().FindAll(s => s.RoomNumber == roomNumber);
        }

        public void Add(ServiceDetail serviceDetail) 
        {
            _context = new();
            _context.ServiceDetails.Add(serviceDetail);
            _context.SaveChanges();
        }

        public void Update(ServiceDetail serviceDetail) 
        {
            _context = new();
            _context.ServiceDetails.Update(serviceDetail);
            _context.SaveChanges();
        }

        public void Update(int serviceDetailId)
        {
            _context = new();
            _context.ServiceDetails.Remove(GetRoomSerivceByServiceDetailId(serviceDetailId));
            _context.SaveChanges();
        }

        public ServiceDetail? GetRoomSerivceByServiceDetailId(int serviceDetailId)
        {
            _context = new();
            return _context.ServiceDetails.FirstOrDefault(s => s.ServiceDetailId == serviceDetailId);
        }

        public decimal GetTotal(int roomNumber)
        {
            _context = new();
            decimal sum = 0;
            foreach (var item in GetServiceDetailsByRoomNumber(roomNumber))
            {
                sum = sum + item.Price * item.Quantity;
            }
            return sum;
        }

        public void GetBill(int roomNumber) 
        {
            _context = new();
            GetServiceDetailsByRoomNumber(roomNumber).ForEach(s => _context.ServiceDetails.Remove(s));
            _context.SaveChanges();
        }
    }
}
