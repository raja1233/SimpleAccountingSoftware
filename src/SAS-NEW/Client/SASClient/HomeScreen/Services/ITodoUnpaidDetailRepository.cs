using SDN.UI.Entities;
using SDN.UI.Entities.HomeScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.HomeScreen.Services
{
    public interface ITodoUnpaidDetailRepository
    {
        List<TodoUnpaidDetailEntity> GetAllData(int? InvType);
        List<TodoUnpaidDetailEntity> GetSummaryData();
        List<TaxModel> GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
        bool SavePromisedDate(List<TodoUnpaidDetailEntity> TodoList,string DateFormat);
    }
}
