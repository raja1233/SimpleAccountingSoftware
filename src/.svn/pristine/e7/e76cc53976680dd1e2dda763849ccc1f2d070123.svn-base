using SDN.Settings.BLInterface;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Settings.BL
{
    public class UserSecurityBL:IUserSecurityBL
    {
        public List<UsersSecurityEntity> GetUsers()
        {
            IUserSecurityDAL _securityDAL = new UserSecurityDAL();
            return _securityDAL.GetUsers();
        }

        public List<UserRoleModel> GetAllUserRoles()
        {
            IUserSecurityDAL _securityDAL = new UserSecurityDAL();
            var userroles = _securityDAL.GetAllUserRoles();
           foreach(var item in userroles)
            {
                if (item.ModuleName == null || item.ModuleName == "" || string.IsNullOrWhiteSpace(item.ModuleName))
                {
                    item.ShowModuleCheckBox = false;
                    item.CheckModule = null;
                    item.CheckTab = false;
                }

                else
                {
                    item.CheckTab = false;
                    item.ShowModuleCheckBox = true;
                    item.CheckModule = false;
                }
                    
            }

            return userroles;


        }

        public List<UserRoleModel> GetUserRoles(int userID)
        {
            IUserSecurityDAL _securityBL = new UserSecurityDAL();
            return _securityBL.GetUserRoles(userID);
        }

        public bool SaveUsers(List<UsersSecurityEntity> Users)
        {
            IUserSecurityDAL _securityBL = new UserSecurityDAL();
            return _securityBL.SaveUsers(Users);
        }
        public bool AddRoles(List<UserRoleModel> RoleModel, int UserId)
        {
            IUserSecurityDAL _securityBL = new UserSecurityDAL();
            return _securityBL.AddRoles(RoleModel, UserId);
        }
        public bool DeleteUser(int UserId)
        {
            IUserSecurityDAL _securityBL = new UserSecurityDAL();
            return _securityBL.DeleteUser(UserId);
        }
    }
}
