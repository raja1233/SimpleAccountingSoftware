using SASDAL.CashBank;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.CashandBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.CashBank
{
    public class PayMoneyListBL : IPayMoneyListBL
    {
        public List<PayMoneyListEntity> GetPayMoneyList()
        {
            IPayMoneyListDAL pandsSoldDAl = new PayMoneyListDAL();
            return pandsSoldDAl.GetAllSalesInvoice();
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPayMoneyListDAL pandsSoldBL = new PayMoneyListDAL();
            return pandsSoldBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }




        public List<PayMoneyListEntity> GetAllSalesInvoice()
        {
            IPayMoneyListDAL pandsSoldDAl = new PayMoneyListDAL();
            var Invoicelist = pandsSoldDAl.GetAllSalesInvoice();

            return Invoicelist;
        }
        public List<PayMoneyListEntity> GetAllSalesInvoiceJson(string jsondata)
        {
            IPayMoneyListDAL pandsSoldDAl = new PayMoneyListDAL();
            var Invoicelist = pandsSoldDAl.GetAllSalesInvoiceJson(jsondata);

            return Invoicelist;
        }

        public string GetLastSelectionData(int ScreenId)
        {
            IPayMoneyListDAL pandsSoldDAl = new PayMoneyListDAL();
            var result = pandsSoldDAl.GetLastSelectionData(ScreenId);
            return result;
        }
        public string getTotalCount(int ScreenId)
        {
            IPayMoneyListDAL pandsSoldDAl = new PayMoneyListDAL();
            var result = pandsSoldDAl.getTotalCount(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IPayMoneyListDAL pandsSoldDAl = new PayMoneyListDAL();
            var result = pandsSoldDAl.GetDateFormat();
            return result;
        }

        private string CheckConvertTo(bool? ConvertedToPI, bool? ConvertedToPO)
        {
            if (ConvertedToPI == true)
                return "Invoice";
            else if (ConvertedToPO == true)
                return "Invoice";
            else
                return "";
        }

        public List<YearEntity> GetYearRange()
        {
            IOptionsDAL YearInfo = new OptionsDAL();
            var StartYear = YearInfo.GetYearStart();
            List<YearEntity> YearRange = new List<YearEntity>();
            YearEntity obj = new YearEntity();
            if (StartYear == 0)
            {
                obj.Year = (DateTime.Today.Year - 1).ToString();
                YearRange.Add(obj);

                obj.Year = DateTime.Today.Year.ToString();
                YearRange.Add(obj);
                return YearRange;
            }
            else
            {
                int diff = DateTime.Now.Year - StartYear;
                for (int i = 0; i <= diff; i++)
                {
                    obj = new YearEntity();
                    obj.Year = StartYear.ToString();
                    obj.ID = i;
                    YearRange.Add(obj);
                    StartYear++;
                }
                return YearRange;
            }
        }

        public TaxModel GetDefaultTaxes()
        {
            ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
            return objTax.GetAllTaxes().FirstOrDefault();
        }
        public OptionsEntity GetOptionSettings()
        {

            IOptionsDAL optionsDAL = new OptionsDAL();
            return optionsDAL.GetOptionsDetails();
        }
    }
}
