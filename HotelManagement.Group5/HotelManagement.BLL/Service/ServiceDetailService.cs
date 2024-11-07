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
    public class ServiceDetailService
    {
        private ServiceDetailRepo _repo = new();

        public List<ServiceDetail> GetAllRoomService() => _repo.GetAllRoomService();
        public List<ServiceDetail> GetServiceDetailsByRoomNumber(int roomNumber) => _repo.GetServiceDetailsByRoomNumber(roomNumber);

        public void Add(ServiceDetail serviceDetail) => _repo.Add(serviceDetail);

        public void Update(ServiceDetail serviceDetail) => _repo.Update(serviceDetail);

        public void Update(int serviceDetailId) => _repo.Update(serviceDetailId);

        public ServiceDetail? GetRoomSerivceByServiceDetailId(int serviceDetailId) => _repo.GetRoomSerivceByServiceDetailId(serviceDetailId);

        public decimal GetTotal(int roomNumber) => _repo.GetTotal(roomNumber);


        public void GetBill(int roomNumber) => _repo.GetBill(roomNumber);
    }
}
