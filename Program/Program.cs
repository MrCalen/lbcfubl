using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            LBCFUBL_WCF.DataAccess.User u = new LBCFUBL_WCF.DataAccess.User();
            var user = u.CreateUser("login_x", "mabite", LBCFUBL_WCF.DataAccess.User.role.assistant);
            if (user != null)
                Console.Out.WriteLine("ca marche");
            else
                throw new Exception("NOOOOOOON");
        }
    }
}
