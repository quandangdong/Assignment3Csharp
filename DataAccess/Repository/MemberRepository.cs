using BusinessObject.Models;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepo
    {
        public void AddNewMember(Member newMember) => MemberDAO.Instance.AddNewMember(newMember);
        public Member CheckLogin(string email, string password) => MemberDAO.Instance.CheckLogin(email, password);

        public void DeleteMember(Member deletedMember) => MemberDAO.Instance.DeleteMember(deletedMember);

        public List<Member> GetAllMembers() => MemberDAO.Instance.GetAllMembers();

        public Member GetMemberByMemberId(int memberId) => MemberDAO.Instance.GetMemberByMemberId(memberId);


        public void UpdateMember(Member updatedMember) => MemberDAO.Instance.UpdateMember(updatedMember);
    }
}
