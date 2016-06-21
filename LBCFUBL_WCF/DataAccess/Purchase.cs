using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBCFUBL_WCF.DataAccess
{
    public class Purchase
    {
        public List<DBO.Purchase> GetPurchasesForLogin(String login)
        {
            return DBO.DatabaseContext.getInstance().Purchases.Where(a => a.login.Equals(login)).ToList();
        }
        public List<DBO.Purchase> GetPurchasesForLoginBeforeDate(String login, DateTime date)
        {
            return DBO.DatabaseContext.getInstance().Purchases.Where(a => a.login.Equals(login) && a.date <= date).ToList();
        }
        public List<DBO.Purchase> GetPurchasesForLoginAfterDate(String login, DateTime date)
        {
            return DBO.DatabaseContext.getInstance().Purchases.Where(a => a.login.Equals(login) && a.date >= date).ToList();
        }
        public void CreatePurchase(String login, DateTime date, Guid id_prod, string added_by)
        {
            DBO.Purchase purchase = new DBO.Purchase
            {
                login = login,
                date = date,
                id_prod = id_prod,
                added_by = added_by
            };
            DBO.DatabaseContext.getInstance().Purchases.Add(purchase);
            DBO.DatabaseContext.getInstance().SaveChanges();
        }

        public bool DeletePurchase(String login, DateTime date)
        {
            DBO.Purchase exists = DBO.DatabaseContext.getInstance().Purchases.FirstOrDefault(a => a.login.Equals(login) && a.date == date);
            if (exists == null)
                return false;
            DBO.DatabaseContext.getInstance().Purchases.Remove(exists);
            return true;
        }

        public List<DBO.Get_Stock_For_Date_Result> GetStocksForDate(DateTime dt)
        {
            return DBO.DatabaseContext.getInstance().Get_Stock_For_Date(dt).ToList();
        }
    }
}