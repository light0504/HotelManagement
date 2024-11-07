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
    public class MemberService
    {
        private MemberRepo _repo = new();

        public List<Member> GetAllMembers() => _repo.GetAllMembers();

        public List<Member> GetMembersByName(string name) => _repo.GetMembersByName(name);


        public List<Member> GetMemberListByRole(string role) => _repo.GetMemberListByRole(role);

        public Member GetMemberById(int id) => _repo.GetMemberById(id);

        public Member GetMemberByEmail(string email) => _repo.GetMemberByEmail(email);

        public void AddMember(Member member) => _repo.AddMember(member);

        public void Update(Member member) => _repo.Update(member);

        public void Remove(int memberid) => _repo.Remove(memberid);

        public Member Login(string email, string password) => _repo.Login(email, password);
    }
}
