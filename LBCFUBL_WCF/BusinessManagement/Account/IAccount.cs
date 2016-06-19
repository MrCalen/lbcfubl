using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LBCFUBL_WCF.BusinessManagement.Account
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IAccount" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IAccount
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<DBO.Account> GetAccounts();
        [OperationContract]
        List<DBO.Account> GetAccountsForLogin(String login);
        [OperationContract]
        List<DBO.Account> GetAccountsForLoginBeforeDate(String login, DateTime date);
        [OperationContract]
        List<DBO.Account> GetAccountsForLoginAfterDate(String login, DateTime date);
        [OperationContract]
        void CreateAccount(String login, float money, DateTime date);
        [OperationContract]
        bool DeleteAccount(String login, DateTime date);
        [OperationContract]
        DBO.Account GetAccountForId(Guid id);
        [OperationContract]
        bool DeleteAccountForId(Guid id);
    }
}
