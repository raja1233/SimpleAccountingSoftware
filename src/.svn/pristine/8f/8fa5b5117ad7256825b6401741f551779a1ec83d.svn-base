using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities;
using System.Data.SqlClient;

namespace SASDAL.File
{
    public class BackupDataDAL : IBackupDataDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();

        public string BackupDataBase(string Name, string FileName)
        {
            string Result="";
            try
            {
               Result =  entities.Database.SqlQuery<string>("USP_BackupDatabase @Name,@FileName",
                    new SqlParameter("Name",Name),
                    new SqlParameter("FileName", FileName)).SingleOrDefault();
                
            }
            catch (Exception e)
            {

                throw e;
            }
            return Result;
        }

        public List<BackupDataEntity> getDataBaseName()
        {
            List<BackupDataEntity> list = new List<BackupDataEntity>();
            try
            {
                list = entities.Database.SqlQuery<BackupDataEntity>("USP_getDataBaseName").ToList();
            }
            catch (Exception e)
            {
               
                throw e;
            }
            return list;
        }

        public List<BackupDataEntity> getServerName()
        {
            List<BackupDataEntity> list = new List<BackupDataEntity>();
            try
            {
                list = entities.Database.SqlQuery<BackupDataEntity>("Usp_ServerName").ToList();
            }
            catch (Exception e)
            {
               
                throw e;
            }
            return list;
        }
    }
}
