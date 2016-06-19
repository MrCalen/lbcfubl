using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBCFUBL_WCF.DataAccess
{
    public class Product
    {
        public DBO.Product GetProductFromName(String name)
        {
            return DBO.DatabaseContext.getInstance().Products.FirstOrDefault(p => p.name.Equals(name));
        }

        public List<DBO.Product> GetAllProducts()
        {
            return DBO.DatabaseContext.getInstance().Products.ToList();
        }

        public DBO.Product CreateProduct(String name, String description, float cost_without_margin, float cost_with_margin)
        {
            DBO.Product exists = GetProductFromName(name);
            if (exists != null)
                return exists;
            DBO.Product product = new DBO.Product
            {
                id = Guid.NewGuid(),
                name = name,
                description = description,
                cost_without_margin = cost_without_margin,
                cost_with_margin = cost_with_margin
            };
            DBO.DatabaseContext.getInstance().Products.Add(product);
            DBO.DatabaseContext.getInstance().SaveChanges();
            return GetProductFromName(name);
        }

        public bool DeleteProduct(String name)
        {
            DBO.Product exists = GetProductFromName(name);
            if (exists == null)
                return false;
            DBO.DatabaseContext.getInstance().Products.Remove(exists);
            DBO.DatabaseContext.getInstance().SaveChanges();
            return true;
        }
        public bool DeleteProductFromId(Guid id)
        {
            DBO.Product exists = GetProductFromId(id);
            if (exists == null)
                return false;
            DBO.DatabaseContext.getInstance().Products.Remove(exists);
            DBO.DatabaseContext.getInstance().SaveChanges();
            return true;
        }
        public DBO.Product GetProductFromId(Guid id)
        {
            return DBO.DatabaseContext.getInstance().Products.FirstOrDefault(p => p.id.Equals(id));
        }
    }
}