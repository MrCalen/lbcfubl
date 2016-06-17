using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LBCFUBL_WCF.BusinessManagement.Product
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ProductService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ProductService.svc ou ProductService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ProductService : IProductService
    {
        private DataAccess.Product product;
        ProductService()
        {
            product = new DataAccess.Product();
        }
        public DBO.Product CreateProduct(string name, string description, float cost_without_margin, float cost_with_margin)
        {
            return product.CreateProduct(name, description, cost_without_margin, cost_with_margin);
        }

        public bool DeleteProduct(string name)
        {
            return product.DeleteProduct(name);
        }

        public List<DBO.Product> GetAllProducts()
        {
            return product.GetAllProducts();
        }

        public DBO.Product GetProductFromName(string name)
        {
            return product.GetProductFromName(name);
        }
    }
}
