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
        [ReferencePreservingDataContractFormat]
        List<DBO.Shopping> GetShoppings();
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<DBO.Shopping> GetShoppingsBeforeDate(DateTime date);
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<DBO.Shopping> GetShoppingsAfterDate(DateTime date);
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void CreateShopping(DateTime date);
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void CreateShoppingWithProducts(DateTime date, List<DBO.Shopping_Product> shopping_products);
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        bool DeleteShopping(DateTime date);
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        DBO.Shopping GetShoppingFromId(Guid id);
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        bool DeleteShoppingFromId(Guid id);
    }
}
