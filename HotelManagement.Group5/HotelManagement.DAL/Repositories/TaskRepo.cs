using HotelManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAL.Repositories
{
    public class TaskRepo
    {
        private HotelContext? _context;

        public List<Entities.Task> GetAllTasks() 
        { 
            _context = new HotelContext();
            return _context.Tasks.ToList();
        }

        public Entities.Task? GetTaskById(int id)
        {
            _context = new HotelContext();
            return _context.Tasks.ToList().FirstOrDefault(t => t.TaskId == id);
        }

        public void AddTask(Entities.Task task) 
        {
            _context = new();
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Entities.Task task) 
        { 
            _context = new();
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id) 
        {
            _context = new();
            _context.Tasks.Remove(GetTaskById(id));
            _context.SaveChanges();
        }

        public List<Entities.Task> GetTasksByMemberId(int memberId) 
        {
            _context = new HotelContext();
            return _context.Tasks.ToList().FindAll(t => t.MemberId == memberId);
        }
    }
}
