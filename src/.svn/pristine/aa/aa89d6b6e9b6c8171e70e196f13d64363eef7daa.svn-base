
using SDN.Customers.BLInterface;
using SDN.Customers.DAL;
using SDN.Customers.DALInterface;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
//using SDN.Settings.DAL;
//using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Customers.BL
{
    public class CustomerHistoryBL : ICustomerHistoryBL
    {
        public List<CustomerHistoryEntity> GetAllSalesInvoice()
        {
            ICustomerHistoryDAL purInvoice = new CustomerHistoryDAL();
            var Invoicelist = purInvoice.GetAllSalesInvoice();
            foreach (var item in Invoicelist)
            {
                if (item.InvoiceDateDateTime != null)
                {
                    item.InvoiceDate = item.InvoiceDateDateTime.ToString();

                }
                if (item.CashChequeNo != null && item.CashChequeNo != "")
                {
                    item.CreditCashNO = item.CashChequeNo;
                    if (item.CashChequeDateDate != null && item.CashChequeDateDate.Value.Year > 2000)
                        item.CreditCashDate = item.CashChequeDateDate.ToString();
                    else item.CreditCashDate = null;
                    item.CreditCashAmount = item.CashChequeAmount.ToString();
                    item.TotalAmount = item.CashChequeAmount;
                }

                else
                {
                    item.CreditCashNO = item.CreditNoteNo;
                    if (item.CreditNoteDateDate != null && item.CreditNoteDateDate.Value.Year > 2000)
                        item.CreditCashDate = item.CreditNoteDateDate.ToString();
                    else item.CreditCashDate = null;
                    item.CreditCashAmount = item.CreditNoteAmount.ToString();
                    item.TotalAmount = item.CreditNoteAmount;
                }
                switch (item.Status)
                {
                    case 0:
                        item.StatusString = "All";
                        break;
                    case 1:
                        item.StatusString = "Paid";
                        break;
                    case 2:
                        item.StatusString = "UnPaid";
                        break;
                    case 3:
                        item.StatusString = "Adjusted";
                        break;
                    case 4:
                        item.StatusString = "Cancelled";
                        break;
                    default:
                        item.StatusString = "All";
                        break;
                }


                if (item.CreditNoteNo != null && item.CreditNoteNo != "")
                    item.CashCreditNo = item.CreditNoteNo;
                else if (item.CashChequeNo != null && item.CashChequeNo != "")
                    item.CashCreditNo = item.CashChequeNo;
                else
                    item.CashCreditNo = null;
                item.InvoiceAmount = item.InvoiceAmountValue.ToString();
            }
            return Invoicelist;
        }
        public List<CustomerHistoryEntity> GetAllSalesInvoiceJson(string jsondata, bool? ExcincTax)
        {
            ICustomerHistoryDAL purInvoice = new CustomerHistoryDAL();
            var Invoicelist = purInvoice.GetAllSalesInvoiceJson(jsondata, ExcincTax);
            foreach (var item in Invoicelist)
            {
                if (item.InvoiceDateDateTime != null)
                {
                    item.InvoiceDate = item.InvoiceDateDateTime.ToString();

                }
                //if (item.CashChequeNo != null && item.CashChequeNo != "")
                //    item.CreditCashNO = item.CashChequeNo;
                //else
                //    item.CreditCashNO = item.CreditNoteNo;
                //if (item.CashChequeDateDate != null && item.CashChequeDateDate.Value.Year>2000)
                //    item.CreditCashDate = item.CashChequeDateDate.ToString();
                //else if(item.CreditNoteDateDate!=null && item.CreditNoteDateDate.Value.Year > 2000)
                //    item.CreditCashDate = item.CreditNoteDateDate.ToString();
                //if (item.CashChequeAmount != null && item.CashChequeAmount != 0)
                //    item.CreditCashAmount = item.CashChequeAmount;
                //else if (item.CreditNoteAmount != null && item.CreditNoteAmount != 0)
                //    item.CreditCashAmount = item.CreditNoteAmount;
                if (item.CashChequeNo != null && item.CashChequeNo != "")
                {
                    item.CreditCashNO = item.CashChequeNo;
                    if (item.CashChequeDateDate != null && item.CashChequeDateDate.Value.Year > 2000)
                        item.CreditCashDate = item.CashChequeDateDate.ToString();
                    else item.CreditCashDate = null;
                    item.CreditCashAmount = item.CashChequeAmount.ToString();
                    item.TotalAmount = item.CashChequeAmount;
                }

                else
                {
                    item.CreditCashNO = item.CreditNoteNo;
                    if (item.CreditNoteDateDate != null && item.CreditNoteDateDate.Value.Year > 2000)
                        item.CreditCashDate = item.CreditNoteDateDate.ToString();
                    else item.CreditCashDate = null;
                    item.CreditCashAmount = item.CreditNoteAmount.ToString();
                    item.TotalAmount = item.CreditNoteAmount;
                }
                switch (item.Status)
                {
                    case 0:
                        item.StatusString = "All";
                        break;
                    case 1:
                        item.StatusString = "Paid";
                        break;
                    case 2:
                        item.StatusString = "UnPaid";
                        break;
                    case 3:
                        item.StatusString = "Adjusted";
                        break;
                    case 4:
                        item.StatusString = "Cancelled";
                        break;
                    default:
                        item.StatusString = "All";
                        break;
                }
                if (item.CreditNoteNo != null && item.CreditNoteNo != "")
                    item.CashCreditNo = item.CreditNoteNo;
                else if (item.CashChequeNo != null && item.CashChequeNo != "")
                    item.CashCreditNo = item.CashChequeNo;
                else
                    item.CashCreditNo = null;
                item.InvoiceAmount = item.InvoiceAmountValue.ToString();

            }
            return Invoicelist;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ICustomerHistoryDAL purInvoice = new CustomerHistoryDAL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ICustomerHistoryDAL purInvoice = new CustomerHistoryDAL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ICustomerHistoryDAL purInvoice = new CustomerHistoryDAL();
            var result = purInvoice.GetDateFormat();
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
                    obj.Year = StartYear.ToString();
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
