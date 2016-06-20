using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LBCFUBL_WCF.BusinessManagement.Shopping_Product
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IShoppingProductService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IShoppingProductService
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        DBO.Shopping_Product GetShopping_ProductForShoppingAndProduct(DBO.Shopping shopping, DBO.Product product);
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<DBO.Shopping_Product> GetShopping_ProductsForShopping(DBO.Shopping shopping);
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        void CreateShopping_Product(DBO.Product product, DBO.Shopping shopping, int number);
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        bool DeleteShopping_Product(DBO.Shopping shopping, DBO.Product product);
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<DBO.Shopping_Product> GetShopping_ProductsForShoppingId(Guid shoppingId);
    }
}
