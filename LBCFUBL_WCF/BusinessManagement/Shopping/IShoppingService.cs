using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LBCFUBL_WCF.BusinessManagement.Shopping
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IShoppingService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IShoppingService
    {
        [OperationContract]
        List<DBO.Shopping> GetShoppings();
        [OperationContract]
        List<DBO.Shopping> GetShoppingsBeforeDate(DateTime date);
        [OperationContract]
        List<DBO.Shopping> GetShoppingsAfterDate(DateTime date);
        [OperationContract]
        void CreateShopping(DateTime date);
        [OperationContract]
        void CreateShoppingWithProducts(DateTime date, List<DBO.Shopping_Product> shopping_products);
        [OperationContract]
        bool DeleteShopping(DateTime date);
        [OperationContract]
        DBO.Shopping GetShoppingFromId(Guid id);
        [OperationContract]
        bool DeleteShoppingFromId(Guid id);
    }
}
