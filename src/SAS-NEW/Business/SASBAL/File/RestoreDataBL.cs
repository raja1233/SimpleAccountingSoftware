using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities;
using SASDAL.File;

namespace SASBAL.File
{
    public class RestoreDataBL : IRestoreDataBL  
    {
        public RestoreDataEntity RestoreDb(string filename)
        {
            IRestoreDataDAL obj = new RestoreDataDAL();
            return obj.RestoreDb(filename);
        }
    }
}
