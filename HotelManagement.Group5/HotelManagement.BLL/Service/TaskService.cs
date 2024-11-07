using HotelManagement.DAL.Repositories;
using HotelManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BLL.Service
{
    public class TaskService
    {
        private TaskRepo _repo = new();

        public List<DAL.Entities.Task> GetAllTasks() => _repo.GetAllTasks();

        public DAL.Entities.Task GetTaskById(int id) => _repo.GetTaskById(id); 

        public void AddTask(DAL.Entities.Task task) => _repo.AddTask(task);

        public void UpdateTask(DAL.Entities.Task task) => _repo.UpdateTask(task);

        public void RemoveTask(int id) => _repo.DeleteTask(id);

        public List<DAL.Entities.Task> GetTaskByMemberId(int id) => _repo.GetTasksByMemberId(id);
    }
}
