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
    public class TransferMoneyListRepository : ITransferMoneyListRepository
    {
        public List<TransferMoneyListEntity> GetTransferMoneyList()
        {
            ITransferMoneyListBL pandsSoldBL = new TransferMoneyListBL();
            return pandsSoldBL.GetAllSalesInvoice();
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ITransferMoneyListBL pandsSoldBL = new TransferMoneyListBL();
            return pandsSoldBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }



        public List<TransferMoneyListEntity> GetAllSalesInvoiceJson(string jsondata)
        {

            ITransferMoneyListBL pandsSoldBL = new TransferMoneyListBL();
            List<TransferMoneyListEntity> quotationlist = pandsSoldBL.GetAllSalesInvoiceJson(jsondata);
            return quotationlist;
        }
        public List<TransferMoneyListEntity> GetAllSalesInvoice()
        {

            ITransferMoneyListBL pandsSoldBL = new TransferMoneyListBL();
            List<TransferMoneyListEntity> Invoicelist = pandsSoldBL.GetAllSalesInvoice();
            return Invoicelist;
        }
        public List<YearEntity> GetYearRange()
        {
            ITransferMoneyListBL pandsSoldBL = new TransferMoneyListBL();
            List<YearEntity> yearrange = pandsSoldBL.GetYearRange();
            return yearrange;
        }

        public string GetLastSelectionData(int ScreenId)
        {
            ITransferMoneyListBL pandsSoldBL = new TransferMoneyListBL();
            var result = pandsSoldBL.GetLastSelectionData(ScreenId);
            return result;
        }
        public string getTotalCount(int ScreenId)
        {
            ITransferMoneyListBL pandsSoldBL = new TransferMoneyListBL();
            var result = pandsSoldBL.getTotalCount(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ITransferMoneyListBL pandsSoldBL = new TransferMoneyListBL();
            var result = pandsSoldBL.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            ITransferMoneyListBL pandsSoldBL = new TransferMoneyListBL();
            return pandsSoldBL.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            ITransferMoneyListBL pandsSoldBL = new TransferMoneyListBL();
            return pandsSoldBL.GetOptionSettings();

        }
    }
}
