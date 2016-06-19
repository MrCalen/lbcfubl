using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LBCFUBL_WCF.BusinessManagement.Product
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IProductService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        DBO.Product GetProductFromName(String name);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<DBO.Product> GetAllProducts();

        [ReferencePreservingDataContractFormat]
        [OperationContract]
        DBO.Product CreateProduct(String name, String description, float cost_without_margin, float cost_with_margin);

        [ReferencePreservingDataContractFormat]
        [OperationContract]
        bool DeleteProduct(String name);

        [ReferencePreservingDataContractFormat]
        [OperationContract]
        DBO.Product GetProductFromId(Guid id);

        [ReferencePreservingDataContractFormat]
        [OperationContract]
        bool DeleteProductFromId(Guid id);
    }
}
