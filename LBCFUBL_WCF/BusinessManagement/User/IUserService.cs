using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LBCFUBL_WCF.BusinessManagement.User
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        DBO.User GetUserFromLogin(String login);

        [OperationContract]
        DBO.User CreateUser(String login, String password, int role);

        [OperationContract]
        bool DeleteUser(String login);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<DBO.User> GetUsers();

        [OperationContract]
        double GetUserMoney(String login);
    }
}
