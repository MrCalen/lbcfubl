using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LBCFUBL_WCF.DBO;

namespace LBCFUBL_WCF.BusinessManagement.Purchase
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "PurchaseService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez PurchaseService.svc ou PurchaseService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class PurchaseService : IPurchaseService
    {
        private DataAccess.Purchase purchase;
        public PurchaseService()
        {
            purchase = new DataAccess.Purchase();
        }
        public void CreatePurchase(string login, DateTime date, Guid id_prod, string added_by)
        {
            purchase.CreatePurchase(login, date, id_prod, added_by);
        }

        public bool DeletePurchase(string login, DateTime date)
        {
            return purchase.DeletePurchase(login, date);
        }

        public List<DBO.Purchase> GetPurchasesForLogin(string login)
        {
            return purchase.GetPurchasesForLogin(login);
        }

        public List<DBO.Purchase> GetPurchasesForLoginAfterDate(string login, DateTime date)
        {
            return purchase.GetPurchasesForLoginAfterDate(login, date);
        }

        public List<DBO.Purchase> GetPurchasesForLoginBeforeDate(string login, DateTime date)
        {
            return purchase.GetPurchasesForLoginBeforeDate(login, date);
        }
    }
}
