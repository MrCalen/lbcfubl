using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LBCFUBL_WCF.DBO;

namespace LBCFUBL_WCF.BusinessManagement.Account
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Account" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Account.svc ou Account.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Account : IAccount
    {
        private DataAccess.Account account;
        Account()
        {
            account = new DataAccess.Account();
        }
        public void CreateAccount(string login, float money, DateTime date)
        {
            account.CreateAccount(login, money, date);
        }

        public bool DeleteAccount(string login, DateTime date)
        {
            return account.DeleteAccount(login, date);
        }

        public List<DBO.Account> GetAccountsForLogin(string login)
        {
            return account.GetAccountsForLogin(login);
        }

        public List<DBO.Account> GetAccountsForLoginAfterDate(string login, DateTime date)
        {
            return account.GetAccountsForLoginAfterDate(login, date);
        }

        public List<DBO.Account> GetAccountsForLoginBeforeDate(string login, DateTime date)
        {
            return account.GetAccountsForLoginBeforeDate(login, date);
        }
    }
}
