using SASBAL.Customers;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Customers.Services
{
    public class CustomerCreditPaidDaysRepository : ICustomerCreditPaidDaysRepository
    {
        public List<CustomerCreditPaidDaysEntity> GetAllSalesInvoiceJson(string jsondata)
        {
            ICustomerCreditPaidDaysBL purInvoice = new CustomerCreditPaidDaysBL();
            List<CustomerCreditPaidDaysEntity> quotationlist = purInvoice.GetAllSalesInvoiceJson(jsondata);
            return quotationlist;
        }

        //public List<YearEntity> GetYearRange()
        //{
        //    ICustomerCreditPaidDaysBL purInvoice = new CustomerCreditPaidDaysBL();
        //    List<YearEntity> yearrange = purInvoice.GetYearRange();
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
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ICustomerCreditPaidDaysBL purInvoice = new CustomerCreditPaidDaysBL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ICustomerCreditPaidDaysBL purInvoice = new CustomerCreditPaidDaysBL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ICustomerCreditPaidDaysBL purInvoice = new CustomerCreditPaidDaysBL();
            var result = purInvoice.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            ICustomerCreditPaidDaysBL purInvoice = new CustomerCreditPaidDaysBL();
            return purInvoice.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            ICustomerCreditPaidDaysBL purInvoice = new CustomerCreditPaidDaysBL();
            return purInvoice.GetOptionSettings();

        }
    }
}
