using SASBAL.HomeScreen;
using SDN.UI.Entities;
using SDN.UI.Entities.HomeScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.HomeScreen.Services
{
    public class TodoUnpaidDetailRepository : ITodoUnpaidDetailRepository
    {
        public List<TodoUnpaidDetailEntity> GetAllData(int? InvType)
        {
            ITodoUnpaidDetailBL paymentBL = new TodoUnpaidDetailBL();
            List<TodoUnpaidDetailEntity> PaymentList = paymentBL.GetAllData(InvType);
            return PaymentList;
        }
           public List<TodoUnpaidDetailEntity> GetSummaryData()
        {
            ITodoUnpaidDetailBL paymentBL = new TodoUnpaidDetailBL();
            List<TodoUnpaidDetailEntity> PaymentList = paymentBL.GetSummaryData();
            return PaymentList;
        }
        public List<TaxModel> GetDefaultTaxes()
        {
            ITodoUnpaidDetailBL paymentBL = new TodoUnpaidDetailBL();
            return paymentBL.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            ITodoUnpaidDetailBL paymentBL = new TodoUnpaidDetailBL();
            return paymentBL.GetOptionSettings();

        }
        public bool  SavePromisedDate(List<TodoUnpaidDetailEntity> TodoList, string DateFormat)
        {
            ITodoUnpaidDetailBL paymentBL = new TodoUnpaidDetailBL();
            bool PaymentList = paymentBL.SavePromisedDate(TodoList, DateFormat);
            return PaymentList;
        }
    }
}
