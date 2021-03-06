﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities;
using SASDAL.File;

namespace SASBAL.File
{
    public class BackupDataBL : IBackupDataBL
    {
        public string BackupDataBase(string Name, string FileName)
        {
            IBackupDataDAL obj = new BackupDataDAL();
            return obj.BackupDataBase(Name, FileName);
        }

        public List<BackupDataEntity> getDataBaseName()
        {
            IBackupDataDAL obj = new BackupDataDAL();
            return obj.getDataBaseName();
        }

        public List<BackupDataEntity> getServerName()
        {
            IBackupDataDAL obj = new BackupDataDAL();
            return obj.getServerName();
        }
    }
}
