﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities;

namespace SASDAL.File
{
    public class RestoreDataDAL : IRestoreDataDAL   
    {
        private SASEntitiesEDM entities = new SASEntitiesEDM();
        public RestoreDataEntity RestoreDb(string filename)
        {
            RestoreDataEntity x = new RestoreDataEntity();
            x.Msg = "zz";
            return x;
        }
    }
}