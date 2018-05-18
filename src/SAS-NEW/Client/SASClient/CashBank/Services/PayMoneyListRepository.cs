using SASBAL.CashBank;
using SDN.UI.Entities;
using SDN.UI.Entities.CashandBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.CashBank.Services
{
    public class PayMoneyListRepository : IPayMoneyListRepository
    {
        public List<PayMoneyListEntity> GetPayMoneyList()
        {
            IPayMoneyListBL pandsSoldBL = new PayMoneyListBL();
            return pandsSoldBL.GetAllSalesInvoice();
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPayMoneyListBL pandsSoldBL = new PayMoneyListBL();
            return pandsSoldBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }



        public List<PayMoneyListEntity> GetAllSalesInvoiceJson(string jsondata)
        {

            IPayMoneyListBL pandsSoldBL = new PayMoneyListBL();
            List<PayMoneyListEntity> quotationlist = pandsSoldBL.GetAllSalesInvoiceJson(jsondata);
            return quotationlist;
        }
        public List<PayMoneyListEntity> GetAllSalesInvoice()
        {

            IPayMoneyListBL pandsSoldBL = new PayMoneyListBL();
            List<PayMoneyListEntity> Invoicelist = pandsSoldBL.GetAllSalesInvoice();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            IPayMoneyListBL pandsSoldBL = new PayMoneyListBL();
            List<YearEntity> yearrange = pandsSoldBL.GetYearRange();
            return yearrange;
        }

        public string GetLastSelectionData(int ScreenId)
        {
            IPayMoneyListBL pandsSoldBL = new PayMoneyListBL();
            var result = pandsSoldBL.GetLastSelectionData(ScreenId);
            return result;
        }
        public string getTotalCount(int ScreenId)
        {
            IPayMoneyListBL pandsSoldBL = new PayMoneyListBL();
            var result = pandsSoldBL.getTotalCount(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IPayMoneyListBL pandsSoldBL = new PayMoneyListBL();
            var result = pandsSoldBL.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            IPayMoneyListBL pandsSoldBL = new PayMoneyListBL();
            return pandsSoldBL.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IPayMoneyListBL pandsSoldBL = new PayMoneyListBL();
            return pandsSoldBL.GetOptionSettings();

        }
    }
}
