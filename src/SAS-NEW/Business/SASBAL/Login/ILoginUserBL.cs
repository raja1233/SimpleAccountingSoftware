﻿using SDN.UI.Entities;
using SDN.UI.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Login
{
    public interface ILoginUserBL
    {
        List<UserRoleModel> GetAllUserRoles();
        List<LoginUserEntity> GetUserRoles(int userID);
        List<LoginUserEntity> GetUsers();
        bool GetAuthorizedUser(string uid, string pwd);
        
    }
}
