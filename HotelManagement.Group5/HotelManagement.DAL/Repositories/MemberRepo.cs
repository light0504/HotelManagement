using HotelManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAL.Repositories
{
    public class MemberRepo
    {
        private HotelContext _context;

        public List<Member> GetAllMembers()
        {
            _context = new HotelContext();
            return _context.Members.ToList().FindAll(m => m.Status == 1);
        }

        public List<Member> GetMembersByName(string name) => GetAllMembers().FindAll(m => m.Name.ToLower().Contains(name.ToLower()));


        public List<Member> GetMemberListByRole(string role) => GetAllMembers().FindAll(m => m.Role.ToLower().Contains(role.ToLower()));

        public Member GetMemberById(int id) => GetAllMembers().FirstOrDefault(m => m.MemberId == id);

        public Member GetMemberByEmail(string email) => GetAllMembers().FirstOrDefault(m => m.Email.ToLower() == email.ToLower());

        public void AddMember(Member member)
        {
            _context = new();
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public void Update(Member member)
        {
            _context = new HotelContext();
            _context.Members.Update(member);
            _context.SaveChanges();
        }

        public void Remove(int memberid)
        {
            _context = new();
            _context.Members.Remove(GetMemberById(memberid));
            _context.SaveChanges();
        }

        public Member Login(string email, string password)
        {
            _context = new();
            return GetAllMembers().FirstOrDefault(m => m.Email.ToLower().Equals(email.ToLower()) && m.Password.Equals(password));
        }
    }
}
