using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.File
{
    public interface IExportDataBL
    {
        bool ExportData(ObservableCollection<TransactionEntity> transactionlist, string FileName);

        bool ExportDataMaster(ObservableCollection<MasterEntity> masterlist, string FileName);
    }
}
