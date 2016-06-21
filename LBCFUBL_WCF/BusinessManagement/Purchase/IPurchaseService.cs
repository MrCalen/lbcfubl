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
        [ReferencePreservingDataContractFormat]
        List<DBO.Purchase> GetPurchasesForLogin(String login);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<DBO.Purchase> GetPurchasesForLoginBeforeDate(String login, DateTime date);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<DBO.Purchase> GetPurchasesForLoginAfterDate(String login, DateTime date);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void CreatePurchase(String login, DateTime date, Guid id_prod, string added_by);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        bool DeletePurchase(String login, DateTime date);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<DBO.Get_Stock_For_Date_Result> GetStocksForDate(DateTime dt);
    }
}
