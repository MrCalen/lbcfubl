using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBCFUBL_WCF.DataAccess
{
    public class Shopping
    {
        public List<DBO.Shopping> GetShoppings()
        {
            return DBO.DatabaseContext.getInstance().Shoppings.ToList();
        }
        public List<DBO.Shopping> GetShoppingsBeforeDate(DateTime date)
        {
            return DBO.DatabaseContext.getInstance().Shoppings.Where(s => s.date <= date).ToList();
        }
        public List<DBO.Shopping> GetShoppingsAfterDate(DateTime date)
        {
            return DBO.DatabaseContext.getInstance().Shoppings.Where(s => s.date >= date).ToList();
        }
        public void CreateShopping(DateTime date, List<DBO.Shopping_Product> shopping_products)
        {
            DBO.Shopping Shopping = new DBO.Shopping
            {
                date = date,
                Shopping_Product = shopping_products
            };
            DBO.DatabaseContext.getInstance().Shoppings.Add(Shopping);
            DBO.DatabaseContext.getInstance().SaveChanges();
        }

        public bool DeleteShopping(DateTime date)
        {
            DBO.Shopping exists = DBO.DatabaseContext.getInstance().Shoppings.Where(s => s.date == date).Single();
            if (exists == null)
                return false;
            DBO.DatabaseContext.getInstance().Shoppings.Remove(exists);
            return true;
        }
    }
}