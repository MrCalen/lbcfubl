using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBCFUBL.Services
{
    public class Helper
    {
        public static UserServiceReference.UserServiceClient GetUserClient()
        {
            return ServiceSingleton<UserServiceReference.UserServiceClient>.Instance;
        }
        public static AccountServiceReference.AccountClient GetAccountClient()
        {
            return ServiceSingleton<AccountServiceReference.AccountClient>.Instance;
        }
        public static ProductServiceReference.ProductServiceClient GetProductClient()
        {
            return ServiceSingleton<ProductServiceReference.ProductServiceClient>.Instance;
        }
        public static PurchaseServiceReference.PurchaseServiceClient GetPurchaseClient()
        {
            return ServiceSingleton<PurchaseServiceReference.PurchaseServiceClient>.Instance;
        }
        public static ShoppingProductServiceReference.ShoppingProductServiceClient GetShoppingProductClient()
        {
            return ServiceSingleton<ShoppingProductServiceReference.ShoppingProductServiceClient>.Instance;
        }
        public static ShoppingServiceReference.ShoppingServiceClient GetShoppingClient()
        {
            return ServiceSingleton<ShoppingServiceReference.ShoppingServiceClient>.Instance;
        }

    }
}