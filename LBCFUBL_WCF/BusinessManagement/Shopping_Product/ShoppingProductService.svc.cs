using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LBCFUBL_WCF.DBO;

namespace LBCFUBL_WCF.BusinessManagement.Shopping_Product
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ShoppingProductService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ShoppingProductService.svc ou ShoppingProductService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ShoppingProductService : IShoppingProductService
    {
        private DataAccess.Shopping_Product shopping_product;

        ShoppingProductService()
        {
            shopping_product = new DataAccess.Shopping_Product();
        }
        public void CreateShopping_Product(DBO.Product product, DBO.Shopping shopping, int number)
        {
            shopping_product.CreateShopping_Product(product, shopping, number);
        }

        public bool DeleteShopping_Product(DBO.Shopping shopping, DBO.Product product)
        {
            return shopping_product.DeleteShopping_Product(shopping, product);
        }

        public DBO.Shopping_Product GetShopping_ProductForShoppingAndProduct(DBO.Shopping shopping, DBO.Product product)
        {
            return shopping_product.GetShopping_ProductForShoppingAndProduct(shopping, product);
        }

        public List<DBO.Shopping_Product> GetShopping_ProductsForShopping(DBO.Shopping shopping)
        {
            return shopping_product.GetShopping_ProductsForShopping(shopping);
        }
        public List<DBO.Shopping_Product> GetShopping_ProductsForShoppingId(Guid shoppingId)
        {
            return shopping_product.GetShopping_ProductsForShoppingId(shoppingId);
        }
    }
}
