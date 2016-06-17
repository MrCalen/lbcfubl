using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace LBCFUBL_WCF.DataAccess
{
    public class User
    {
        // power of two => cumulate roles
        public enum role
        {
            anonym = 0,
            assistant = 1,
            chief = 2,
            admin = 4,
        }
        public DBO.User GetUserFromLogin(String login)
        {
            return DBO.DatabaseContext.getInstance().Users.Where(u => u.login.Equals(login)).Single();
        }

        public DBO.User CreateUser(String login, String password, role role)
        {
            DBO.User exists = GetUserFromLogin(login);
            if (exists != null)
                return exists;
            String pass = null;
            using (MD5 md5hash = MD5.Create())
            {
                pass = md5hash.ComputeHash(Encoding.UTF8.GetBytes(password)).ToString();
            }
            DBO.User user = new DBO.User
            {
                login = login,
                password = pass,
                role = (int)role
            };
            DBO.DatabaseContext.getInstance().Users.Add(user);
            DBO.DatabaseContext.getInstance().SaveChanges();
            return GetUserFromLogin(login);
        }

        public bool DeleteUser(String login)
        {
            DBO.User exists = GetUserFromLogin(login);
            if (exists == null)
                return false;
            DBO.DatabaseContext.getInstance().Users.Remove(exists);
            return true;
        }

        public List<DBO.User> GetUsers()
        {
            return DBO.DatabaseContext.getInstance().Users.ToList();
        }
    }
}