using SASClient.File.ViewModel;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.File.Services
{
    public interface IBackupDataRepositoty
    {
        List<BackupDataEntity> getServerName();
        List<BackupDataEntity> getDataBaseName();
        string BackupDataBase(string Name, string FileName);
    }
}
