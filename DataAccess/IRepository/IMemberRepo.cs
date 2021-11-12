using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IMemberRepo
    {
        List<Member> GetAllMembers();
        Member GetMemberByMemberId(int memberId);
        void AddNewMember(Member newMember);
        void UpdateMember(Member updatedMember);
        void DeleteMember(Member deletedMember);
        Member CheckLogin(string email, string password);
    }
}
