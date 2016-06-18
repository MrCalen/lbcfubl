using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBCFUBL_WCF.DataAccess
{
    public class Account
    {
        public List<DBO.Account> GetAccountsForLogin(String login)
        {
            return DBO.DatabaseContext.getInstance().Accounts.Where(a => a.login.Equals(login)).ToList();
        }
        public List<DBO.Account> GetAccountsForLoginBeforeDate(String login, DateTime date)
        {
            return DBO.DatabaseContext.getInstance().Accounts.Where(a => a.login.Equals(login) && a.date <= date).ToList();
        }
        public List<DBO.Account> GetAccountsForLoginAfterDate(String login, DateTime date)
        {
            return DBO.DatabaseContext.getInstance().Accounts.Where(a => a.login.Equals(login) && a.date >= date).ToList();
        }
        public void CreateAccount(String login, float money, DateTime date)
        {
            DBO.Account account = new DBO.Account
            {
                login = login,
                argent = money,
                date = date
            };
            DBO.DatabaseContext.getInstance().Accounts.Add(account);
            DBO.DatabaseContext.getInstance().SaveChanges();
        }

        public bool DeleteAccount(String login, DateTime date)
        {
            DBO.Account exists = DBO.DatabaseContext.getInstance().Accounts.FirstOrDefault(a => a.login.Equals(login) && a.date == date);
            if (exists == null)
                return false;
            DBO.DatabaseContext.getInstance().Accounts.Remove(exists);
            return true;
        }
    }
}