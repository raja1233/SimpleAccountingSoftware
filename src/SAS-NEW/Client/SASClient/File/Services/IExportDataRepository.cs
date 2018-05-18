using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.File.Services
{
    public interface IExportDataRepository
    {
        bool ExportData(ObservableCollection<TransactionEntity> TransactionList,string FileName);
        bool ExportDataMaster(ObservableCollection<MasterEntity> MasterList, string FileName);
    }
}
