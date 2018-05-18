using SDN.Settings.BL;
using SDN.Settings.BLInterface;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Settings.Services
{
    public class UserSecurityRepository:IUserSecurityRepository
    {
        public List<UsersSecurityEntity> GetUsers()
        {
            IUserSecurityBL _securityBL = new UserSecurityBL();
            return _securityBL.GetUsers();
        }

       public List<UserRoleModel> GetAllUserRoles()
        {
            IUserSecurityBL _securityBL = new UserSecurityBL();
            return _securityBL.GetAllUserRoles();
        }

        public bool SaveUsers(List<UsersSecurityEntity> Users)
        {
            IUserSecurityBL _securityBL = new UserSecurityBL();
            return _securityBL.SaveUsers(Users);
        }
        public List<UserRoleModel> GetUserRoles(int userID)
        {
            IUserSecurityBL _securityBL = new UserSecurityBL();
            return _securityBL.GetUserRoles(userID);
        }
        public bool AddRoles(List<UserRoleModel> RoleModel, int UserId)
        {
            IUserSecurityBL _securityBL = new UserSecurityBL();
            return _securityBL.AddRoles(RoleModel, UserId);
        }
        public bool DeleteUser(int UserId)
        {
            IUserSecurityBL _securityBL = new UserSecurityBL();
            return _securityBL.DeleteUser(UserId);
        }
    }
}
