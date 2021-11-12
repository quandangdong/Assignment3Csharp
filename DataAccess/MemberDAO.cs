using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObject.Models;

namespace DataAccess
{
    public class MemberDAO
    {
        private Sales_Management_lab03Context _databaseContext;
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Member> GetAllMembers()
        {
            using (_databaseContext = new Sales_Management_lab03Context())
            {
                return _databaseContext.Members.ToList();
            }
        }

        public Member GetMemberByMemberId(int memberId)
        {
            using (_databaseContext = new Sales_Management_lab03Context())
            {
                return _databaseContext.Members.FirstOrDefault(member => member.MemberId == memberId);
            }
        }

        public void AddNewMember(Member newMember)
        {
            using (_databaseContext = new Sales_Management_lab03Context())
            {
                _databaseContext.Add(newMember);
                _databaseContext.SaveChanges();
            }
        }

        public void UpdateMember(Member updatedMember)
        {
            using (_databaseContext = new Sales_Management_lab03Context())
            {
                _databaseContext.Update<Member>(updatedMember);
                _databaseContext.SaveChanges();
            }
        }

        public void DeleteMember(Member deleteMember)
        {
            using (_databaseContext = new Sales_Management_lab03Context())
            {
                _databaseContext.Remove<Member>(deleteMember);
                _databaseContext.SaveChanges();
            }
        }


        public Member CheckLogin(string email, string password)
        {
            using (_databaseContext = new Sales_Management_lab03Context())
            {
                return _databaseContext.Members.FirstOrDefault(member =>
                    member.Email == email && member.Password == password);
            }
        }
    }
}