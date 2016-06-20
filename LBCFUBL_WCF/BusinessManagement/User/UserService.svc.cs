using System;
using System.Collections.Generic;
using LBCFUBL_WCF.DBO;

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

        public void Block(string login, bool block)
        {
            user.Block(login, block);
        }

        public List<Get_User_Account_History_Result> GetUserAccountHistoryResult(string login)
        {
            return user.GetUserAccountHistory(login);
        }

        public List<Get_User_Purchase_History_Result> GetUserPurchaseHistoryResult(string login)
        {
            return user.GetUserPurchaseHistory(login);
        }
    }
}
