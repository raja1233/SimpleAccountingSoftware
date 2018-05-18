using SASDAL.HomeScreen;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.HomeScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.HomeScreen
{
    public class TodoUnpaidDetailBL : ITodoUnpaidDetailBL
    {
        public List<TodoUnpaidDetailEntity> GetAllData(int? InvType)
        {
            ITodoUnpaidDetailDAL paymentDAL = new TodoUnpaidDetailDAL();
            List<TodoUnpaidDetailEntity> PaymentList = paymentDAL.GetAllData(InvType);
            return PaymentList;
        }
        public List<TodoUnpaidDetailEntity> GetSummaryData()
        {
            ITodoUnpaidDetailDAL paymentDAL = new TodoUnpaidDetailDAL();
            List<TodoUnpaidDetailEntity> PaymentList = paymentDAL.GetSummaryData();
            return PaymentList;
        }
        public List<TaxModel> GetDefaultTaxes()
        {
            ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
            return objTax.GetAllTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {

            IOptionsDAL optionsDAL = new OptionsDAL();
            return optionsDAL.GetOptionsDetails();
        }
        public bool SavePromisedDate(List<TodoUnpaidDetailEntity> TodoList,string DateFormat)
        {
            ITodoUnpaidDetailDAL paymentBL = new TodoUnpaidDetailDAL();
            bool PaymentList = paymentBL.SavePromisedDate(TodoList, DateFormat);
            return PaymentList;
        }
    }
}
