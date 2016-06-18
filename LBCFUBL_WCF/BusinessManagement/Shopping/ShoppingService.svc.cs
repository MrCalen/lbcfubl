using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LBCFUBL_WCF.DBO;

namespace LBCFUBL_WCF.BusinessManagement.Shopping
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ShoppingService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ShoppingService.svc ou ShoppingService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ShoppingService : IShoppingService
    {
        private DataAccess.Shopping shopping;
        public ShoppingService()
        {
            shopping = new DataAccess.Shopping();
        }
        public void CreateShopping(DateTime date)
        {
            shopping.CreateShopping(date);
        }
        public void CreateShoppingWithProducts(DateTime date, List<DBO.Shopping_Product> shopping_products)
        {
            shopping.CreateShoppingWithProducts(date, shopping_products);
        }

        public bool DeleteShopping(DateTime date)
        {
            return shopping.DeleteShopping(date);
        }

        public List<DBO.Shopping> GetShoppings()
        {
            return shopping.GetShoppings();
        }

        public List<DBO.Shopping> GetShoppingsAfterDate(DateTime date)
        {
            return shopping.GetShoppingsAfterDate(date);
        }

        public List<DBO.Shopping> GetShoppingsBeforeDate(DateTime date)
        {
            return shopping.GetShoppingsBeforeDate(date);
        }
        public DBO.Shopping GetShoppingFromId(Guid id)
        {
            return shopping.GetShoppingFromId(id);
        }
        public bool DeleteShoppingFromId(Guid id)
        {
            return shopping.DeleteShoppingFromId(id);
        }
    }
}
