using System;
using System.Collections.Generic;
using System.Linq;
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
            admin = 3,
        }

        public static role RoleFromInt(int i)
        {
            return Enum.GetValues(typeof(role)).Cast<role>().ElementAt(i);
        }

        public DBO.User GetUserFromLogin(String login)
        {
            return DBO.DatabaseContext.getInstance().Users.FirstOrDefault(u => u.login.Equals(login));
        }

        public DBO.User CreateUser(String login, String password, role role)
        {
            DBO.User exists = GetUserFromLogin(login);
            if (exists != null)
                return exists;
            String pass = CalculateMD5Hash(password);
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
            DBO.DatabaseContext.getInstance().SaveChanges();
            return true;
        }

        public List<DBO.User> GetUsers()
        {
            var list = DBO.DatabaseContext.getInstance().Users.ToList();
            return list;
        }

        public static string CalculateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public double GetUserMoney(String login)
        {
            // return DBO.DatabaseContext.getInstance().Users.FirstOrDefault(u => u.login.Equals(login));
            return DBO.DatabaseContext.getInstance().Get_User_Money(login).First().Value;
        }

        public List<Tuple<string, double>> GetUsersMoneys()
        {
            List<Tuple<string, double>> ret = new List<Tuple<string, double>>();
            var users_list = DBO.DatabaseContext.getInstance().Get_Users_Money().ToList();
            foreach (var user in users_list)
            {
                ret.Add(new Tuple<string, double>(user.login, Math.Round((double)(user.money), 2)));
            }
            return ret;
        }
    }
}