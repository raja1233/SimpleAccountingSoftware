using SASClient.File.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities;
using SASBAL.File;

namespace SASClient.File.Services
{
    public class RestoreDataRepository : IRestoreDataRepository  
    {
        public RestoreDataEntity RestoreDb(string filename)
        {
            IRestoreDataBL obj = new RestoreDataBL();
            return obj.RestoreDb(filename);
        }
    }
}
