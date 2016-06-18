using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using LBCFUBL.Services;

namespace LBCFUBL.BusinessManagement
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            // objContext.Users.FirstOrDefault(x => x.AppUserName == username);
            var objUser = Helper.GetUserClient().GetUserFromLogin(username);
            if (objUser == null)
                    return null;
            else
            {
                string[] ret = new string[] { LBCFUBL_WCF.DataAccess.User.RoleFromInt(objUser.role).ToString() };
                return ret;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}