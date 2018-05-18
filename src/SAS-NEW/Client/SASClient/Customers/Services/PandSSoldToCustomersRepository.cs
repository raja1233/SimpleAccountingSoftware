using SDN.Customers.BL;
using SDN.Customers.BLInterface;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Customers.Services
{
    public class PandSSoldToCustomersRepository : IPandSSoldToCustomersRepository
    {
        public List<PandSSoldToCustomersEntity> GetPandSSoldToCustomersList()
        {
            IPandSSoldToCustomersBL pandsSoldBL = new PandSSoldToCustomersBL();
            return pandsSoldBL.GetAllSalesInvoice();
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPandSSoldToCustomersBL pandsSoldBL = new PandSSoldToCustomersBL();
            return pandsSoldBL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }



        public List<PandSSoldToCustomersEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax,bool? IsSummary)
        {

            IPandSSoldToCustomersBL pandsSoldBL = new PandSSoldToCustomersBL();
            List<PandSSoldToCustomersEntity> quotationlist = pandsSoldBL.GetAllSalesInvoiceJson(jsondata, ExcincTax, IsSummary);
            return quotationlist;
        }
        public List<PandSSoldToCustomersEntity> GetAllSalesInvoice()
        {

            IPandSSoldToCustomersBL pandsSoldBL = new PandSSoldToCustomersBL();
            List<PandSSoldToCustomersEntity> Invoicelist = pandsSoldBL.GetAllSalesInvoice();
            return Invoicelist;
        }
        //public List<YearEntity> GetYearRange()
        //{
        //    IPandSSoldToCustomersBL pandsSoldBL = new PandSSoldToCustomersBL();
        //    List<YearEntity> yearrange = pandsSoldBL.GetYearRange();
        //    return yearrange;
        //}
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

        public string GetLastSelectionData(int ScreenId)
        {
            IPandSSoldToCustomersBL pandsSoldBL = new PandSSoldToCustomersBL();
            var result = pandsSoldBL.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IPandSSoldToCustomersBL pandsSoldBL = new PandSSoldToCustomersBL();
            var result = pandsSoldBL.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            IPandSSoldToCustomersBL pandsSoldBL = new PandSSoldToCustomersBL();
            return pandsSoldBL.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IPandSSoldToCustomersBL pandsSoldBL = new PandSSoldToCustomersBL();
            return pandsSoldBL.GetOptionSettings();

        }
        public string getTotalCount(int ScreenId)
        {
            IPandSSoldToCustomersBL pandsSoldBL = new PandSSoldToCustomersBL();
            var result = pandsSoldBL.getTotalCount(ScreenId);
            return result;
        }

    }
}
