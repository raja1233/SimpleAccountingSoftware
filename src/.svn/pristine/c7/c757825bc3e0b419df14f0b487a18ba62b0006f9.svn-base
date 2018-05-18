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
    public class ReceiveMoneyListRepository : IReceiveMoneyListRepository
    {
        public List<ReceiveMoneyListEntity> GetReceiveMoneyList()
        {
            IReceiveMoneyListBL pandsSoldBL = new ReceiveMoneyListBL();
            return pandsSoldBL.GetAllSalesInvoice();
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IReceiveMoneyListBL pandsSoldBL = new ReceiveMoneyListBL();
            return pandsSoldBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }



        public List<ReceiveMoneyListEntity> GetAllSalesInvoiceJson(string jsondata)
        {

            IReceiveMoneyListBL pandsSoldBL = new ReceiveMoneyListBL();
            List<ReceiveMoneyListEntity> quotationlist = pandsSoldBL.GetAllSalesInvoiceJson(jsondata);
            return quotationlist;
        }
        public List<ReceiveMoneyListEntity> GetAllSalesInvoice()
        {

            IReceiveMoneyListBL pandsSoldBL = new ReceiveMoneyListBL();
            List<ReceiveMoneyListEntity> Invoicelist = pandsSoldBL.GetAllSalesInvoice();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            IReceiveMoneyListBL pandsSoldBL = new ReceiveMoneyListBL();
            List<YearEntity> yearrange = pandsSoldBL.GetYearRange();
            return yearrange;
        }

        public string GetLastSelectionData(int ScreenId)
        {
            IReceiveMoneyListBL pandsSoldBL = new ReceiveMoneyListBL();
            var result = pandsSoldBL.GetLastSelectionData(ScreenId);
            return result;
        }
        public string getTotalCount(int ScreenId)
        {
            IReceiveMoneyListBL pandsSoldBL = new ReceiveMoneyListBL();
            var result = pandsSoldBL.getTotalCount(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IReceiveMoneyListBL pandsSoldBL = new ReceiveMoneyListBL();
            var result = pandsSoldBL.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            IReceiveMoneyListBL pandsSoldBL = new ReceiveMoneyListBL();
            return pandsSoldBL.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IReceiveMoneyListBL pandsSoldBL = new ReceiveMoneyListBL();
            return pandsSoldBL.GetOptionSettings();

        }
    }
}
