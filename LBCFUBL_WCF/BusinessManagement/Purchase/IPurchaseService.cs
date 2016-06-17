using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LBCFUBL_WCF.BusinessManagement.Purchase
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IPurchaseService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IPurchaseService
    {
        [OperationContract]
        List<DBO.Purchase> GetPurchasesForLogin(String login);
        [OperationContract]
        List<DBO.Purchase> GetPurchasesForLoginBeforeDate(String login, DateTime date);
        [OperationContract]
        List<DBO.Purchase> GetPurchasesForLoginAfterDate(String login, DateTime date);
        [OperationContract]
        void CreatePurchase(String login, DateTime date, Guid id_prod);
        [OperationContract]
        bool DeletePurchase(String login, DateTime date);
    }
}
