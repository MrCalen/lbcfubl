using System;
using System.Collections.Generic;

namespace LBCFUBL_WCF.BusinessManagement.User
{
    public class UserService : IUserService
    {
        private DataAccess.User user = new DataAccess.User();

        public DBO.User GetUserFromLogin(string login)
        {
            return user.GetUserFromLogin(login);
        }

        public DBO.User CreateUser(string login, string password, int role)
        {
            return user.CreateUser(login, password, DataAccess.User.RoleFromInt(role));
        }

        public bool DeleteUser(string login)
        {
            return user.DeleteUser(login);
        }

        public List<DBO.User> GetUsers()
        {
            return user.GetUsers();
        }

        public double GetUserMoney(string login)
        {
            return user.GetUserMoney(login);
        }

        public List<Tuple<string, double>> GetUsersMoneys()
        {
            return user.GetUsersMoneys();
        }
    }
}
