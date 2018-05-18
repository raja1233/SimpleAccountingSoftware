using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Settings.BLInterface
{
   public interface IUserSecurityBL
    {
        List<UsersSecurityEntity> GetUsers();
        List<UserRoleModel> GetAllUserRoles();
        bool SaveUsers(List<UsersSecurityEntity> Users);
        List<UserRoleModel> GetUserRoles(int userID);
        bool AddRoles(List<UserRoleModel> RoleModel, int UserId);
        bool DeleteUser(int UserId);
    }
}
