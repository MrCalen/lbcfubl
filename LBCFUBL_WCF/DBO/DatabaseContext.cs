using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBCFUBL_WCF.DBO
{
    public class DatabaseContext
    {
        private static lbcfublEntities instance = null;
        private DatabaseContext()
        {}

        public static lbcfublEntities getInstance()
        {
            if (instance == null)
            {
                instance = new lbcfublEntities();
                instance.Configuration.ProxyCreationEnabled = false;
            }
            return instance;
        }
    }
}