using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBCFUBL_WCF.DataAccess
{
    public class Shopping_Product
    {
        public DBO.Shopping_Product GetShopping_ProductForShoppingAndProduct(DBO.Shopping shopping, DBO.Product product)
        {
            return DBO.DatabaseContext.getInstance().Shopping_Product.Where(sp => shopping.id == sp.id_shopping && sp.id_product == product.id).Single();
        }
        public List<DBO.Shopping_Product> GetShopping_ProductsForShopping(DBO.Shopping shopping)
        {
            return DBO.DatabaseContext.getInstance().Shopping_Product.Where(sp => sp.id_shopping == shopping.id).ToList();
        }
        public void CreateShopping_Product(DBO.Product product, DBO.Shopping shopping, int number)
        {
            DBO.Shopping_Product Shopping_Product = new DBO.Shopping_Product
            {
                id_shopping = shopping.id,
                id_product = product.id,
                number = number,
                Product = product,
                Shopping = shopping
            };
            DBO.DatabaseContext.getInstance().Shopping_Product.Add(Shopping_Product);
            DBO.DatabaseContext.getInstance().SaveChanges();
        }

        public bool DeleteShopping_Product(DBO.Shopping shopping, DBO.Product product)
        {
            DBO.Shopping_Product exists = GetShopping_ProductForShoppingAndProduct(shopping, product);
            if (exists == null)
                return false;
            DBO.DatabaseContext.getInstance().Shopping_Product.Remove(exists);
            return true;
        }
    }
}