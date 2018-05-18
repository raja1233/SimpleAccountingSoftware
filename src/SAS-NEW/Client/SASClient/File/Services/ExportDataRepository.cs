using SASBAL.File;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.File.Services
{
    public class ExportDataRepository: IExportDataRepository
    {
        public bool ExportData(ObservableCollection<TransactionEntity> transactionlist,string FileName)
        {
            IExportDataBL exportbl = new ExportDataBL();
            return exportbl.ExportData(transactionlist, FileName);
        }
        public bool ExportDataMaster(ObservableCollection<MasterEntity> masterlist, string FileName)
        {
            IExportDataBL exportbl = new ExportDataBL();
            return exportbl.ExportDataMaster(masterlist, FileName);
        }
    }
}
