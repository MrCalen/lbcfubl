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
        public void CreateShoppingWithProducts(DateTime date, List<DBO.Shopping_Product> shopping_products)
        {
            Guid id = Guid.NewGuid();
            DBO.Shopping Shopping = new DBO.Shopping
            {
                id = id,
                date = date
            };
            foreach (DBO.Shopping_Product shopping_product in shopping_products)
                shopping_product.id_shopping = id;
            Shopping.Shopping_Product = shopping_products;
            DBO.DatabaseContext.getInstance().Shoppings.Add(Shopping);
            DBO.DatabaseContext.getInstance().SaveChanges();
        }
        public void CreateShopping(DateTime date)
        {
            DBO.Shopping Shopping = new DBO.Shopping
            {
                id = Guid.NewGuid(),
                date = date
            };
            DBO.DatabaseContext.getInstance().Shoppings.Add(Shopping);
            DBO.DatabaseContext.getInstance().SaveChanges();
        }

        public bool DeleteShopping(DateTime date)
        {
            DBO.Shopping exists = DBO.DatabaseContext.getInstance().Shoppings.FirstOrDefault(s => s.date == date);
            if (exists == null)
                return false;
            DBO.DatabaseContext.getInstance().Shoppings.Remove(exists);
            DBO.DatabaseContext.getInstance().SaveChanges();
            return true;
        }
        public bool DeleteShoppingFromId(Guid id)
        {
            DBO.Shopping exists = DBO.DatabaseContext.getInstance().Shoppings.FirstOrDefault(s => s.id == id);
            if (exists == null)
                return false;
            DBO.DatabaseContext.getInstance().Shoppings.Remove(exists);
            DBO.DatabaseContext.getInstance().SaveChanges();
            return true;
        }
        public DBO.Shopping GetShoppingFromId(Guid id)
        {
            return DBO.DatabaseContext.getInstance().Shoppings.FirstOrDefault(s => s.id == id);
        }
    }
}