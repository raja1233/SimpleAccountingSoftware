using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities;
using SASBAL.File;

namespace SASClient.File.Services
{
    public class BackupDataRepository : IBackupDataRepositoty
    {
        public string BackupDataBase(string Name, string FileName)
        {
            IBackupDataBL obj = new BackupDataBL();
            return obj.BackupDataBase(Name, FileName);
        }

        public List<BackupDataEntity> getDataBaseName()
        {
            IBackupDataBL obj = new BackupDataBL();
            return obj.getDataBaseName();
        }

        public List<BackupDataEntity> getServerName()
        {
            IBackupDataBL obj = new BackupDataBL();
            return obj.getServerName();
        }
    }
}
