﻿using SDN.UI.Entities;
using SDN.UI.Entities.Login;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SASDAL.Login
{
    public class LoginUserDAL : ILoginUserDAL
    {
        public bool GetAuthorizedUser(string uid, string pwd)
        {
            
            using (SASEntitiesEDM objProdEntities = new SASEntitiesEDM())
            {
                try
                {
                    var user = objProdEntities.Users.Where(x => x.IsDeleted != true && x.User_Name == uid).Select(x => new LoginUserEntity
                    {
                        UserName = x.User_Name.ToLower(),

                        EncryptedPassword = x.User_Password,
                        ID = x.UserId

                    }).SingleOrDefault();
                    if (user == null && uid != null && uid != "" && pwd != null && pwd != "")
                    {
                        MessageBox.Show("Enter correct User Name and Password");
                        return false;
                    }
                    else
                    {
                        if(user != null)
                        {
                            var z = Decrypt(user.EncryptedPassword);
                            if (user.UserName == uid && pwd == z)
                            {
                                //MessageBox.Show("Login SuccessFull");
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("UserName or Password is Wrong");
                                return false;
                            }
                        }
                       else
                        {
                            return false;
                        }
                    }


                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
        public List<LoginUserEntity> GetUsers()
        {
            SASEntitiesEDM objProdEntities = new SASEntitiesEDM();
            
            List<LoginUserEntity> users = objProdEntities.Users.Where(x => x.IsDeleted != true).Select(x => new LoginUserEntity
            {
                UserName = x.User_Name,
                EncryptedPassword = x.User_Password,
                ID = x.UserId
            }).ToList();
            foreach (var item in users)
            {
                if (item.EncryptedPassword != null && item.EncryptedPassword != "")
                    item.Password = Decrypt(item.EncryptedPassword);
            }

            return users.OrderBy(x => x.UserName).ToList();
        }
        public List<LoginUserEntity> GetUserRoles(int userID)
        {
            SASEntitiesEDM objProdEntities = new SASEntitiesEDM();
            try
            {
                //var result = objProdEntities.UserSecurities.Where(x => x.User_Id == userID).Select(x => new UserRoleModel
                //{
                //    TabId = x.Tab_Id,

                //}).ToList();

                //return result;
                var result = (from usersecuritytable in objProdEntities.UserSecurities
                              join mastrmoduletable in objProdEntities.MasterModules
                              on usersecuritytable.Tab_Id equals mastrmoduletable.Tab_Id.ToString()
                              where usersecuritytable.User_Id == userID
                              select new LoginUserEntity
                              {
                                  TabId = usersecuritytable.Tab_Id,
                                  TabName = mastrmoduletable.Tab_Name
                              }).ToList();

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserRoleModel> GetAllUserRoles()
        {
            SASEntitiesEDM objProdEntities = new SASEntitiesEDM();
            List<UserRoleModel> lstuserRoles = new List<UserRoleModel>();
            try
            {

                lstuserRoles = (from u in objProdEntities.MasterModules
                                select new UserRoleModel
                                {
                                    ID = u.ID,
                                    ModuleId = u.Module_Id,
                                    ModuleName = u.Module_Name,
                                    TabId = u.Tab_Id.ToString(),
                                    TabName = u.Tab_Name,
                                    OrderId = u.Order_Id

                                }).OrderBy(x => x.OrderId).ToList<UserRoleModel>();

                return lstuserRoles;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #region PasswordEncryption and Decryption 

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "Simple";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }


        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "Simple";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        #endregion
    }
}