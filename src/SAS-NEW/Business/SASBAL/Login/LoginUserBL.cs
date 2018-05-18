using SASDAL.Login;
using SDN.UI.Entities;
using SDN.UI.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Login
{
    public class LoginUserBL: ILoginUserBL
    {
        public bool GetAuthorizedUser(string uid, string pwd)
        {
            ILoginUserDAL piBL = new LoginUserDAL();
            return piBL.GetAuthorizedUser(uid, pwd);
        }
        public List<LoginUserEntity> GetUsers()
        {
            ILoginUserDAL piBL = new LoginUserDAL();
            return piBL.GetUsers();
        }
        public List<LoginUserEntity> GetUserRoles(int userID)
        {
            ILoginUserDAL _securityBL = new LoginUserDAL();
            return _securityBL.GetUserRoles(userID);
        }
        public List<UserRoleModel> GetAllUserRoles()
        {
            ILoginUserDAL _securityBL = new LoginUserDAL();
            return _securityBL.GetAllUserRoles();
        }

    }
}
