
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BL
{
    using DAL;
    using DALInterface;
    using SDN.Sales.BLInterface;
    using SDN.Settings.DALInterface;
    using Settings.DAL;
    using UI.Entities;
    using UI.Entities.Sales;

    public class CreditNoteListBL: ICreditNoteListBL
    {
        public List<CreditNoteListEntity> GetAllSalesCredit()
        {
            ICreditNoteListDAL purCredit = new CreditNoteListDAL();
            var Creditlist = purCredit.GetAllSalesCredit();
            //foreach (var item in Creditlist)
            //{
            //    if (item.CreditDateDateTime != null)
            //    {
            //        item.CreditDate = item.CreditDateDateTime.ToString();

            //    }
            //    if (item.CashChequeNo != null && item.CashChequeNo != "")
            //    {
            //        item.CreditCashNO = item.CashChequeNo;
            //        item.CreditCashDate = item.CashChequeDateDate.ToString();
            //        item.CreditCashAmount = item.CashChequeAmount.ToString();
            //    }

            //    else
            //    {
            //        item.CreditCashNO = item.SalesInvoiceNo;
            //        item.CreditCashDate = item.InvoiceDateDateTime.ToString();
            //        item.CreditCashAmount = item.SalesAmount.ToString();
            //    }
            //    switch (item.Status)
            //    {
            //        case 0:
            //            item.StatusString = "All";
            //            break;
            //        case 1:
            //            item.StatusString = "Adjusted";
            //            break;
            //        case 2:
            //            item.StatusString = "UnAdjusted";
            //            break;
            //        case 3:
            //            item.StatusString = "Refunded";
            //            break;
            //        default:
            //            item.StatusString = "All";
            //            break;
            //    }


            //    if (item.SalesInvoiceNo != null && item.SalesInvoiceNo != "")
            //        item.CashCreditNo = item.SalesInvoiceNo;
            //    else if (item.CashChequeNo != null && item.CashChequeNo != "")
            //        item.CashCreditNo = item.CashChequeNo;
            //    else
            //        item.CashCreditNo = null;
            //    item.CreditAmount = item.CreditAmountValue.ToString();
            //}
            return Creditlist;
        }
        public List<CreditNoteListEntity> GetAllSalesCreditJson(string jsondata, bool? ExcincTax)
        {
            ICreditNoteListDAL purCredit = new CreditNoteListDAL();
            var Creditlist = purCredit.GetAllSalesCreditJson(jsondata, ExcincTax);
            //foreach (var item in Creditlist)
            //{
            //    if (item.CreditDateDateTime != null)
            //    {
            //        item.CreditDate = item.CreditDateDateTime.ToString();

            //    }
              
            //    if (item.CashChequeNo != null && item.CashChequeNo != "")
            //    {
            //        item.CreditCashNO = item.CashChequeNo;
            //        if (item.CashChequeDateDate != null && item.CashChequeDateDate.Value.Year > 2000)
            //            item.CreditCashDate = item.CashChequeDateDate.ToString();
            //        else item.CreditCashDate = null;
            //        item.CreditCashAmount = item.CashChequeAmount.ToString();
            //    }

            //    else
            //    {
            //        item.CreditCashNO = item.SalesInvoiceNo;
            //        if (item.InvoiceDateDateTime != null && item.InvoiceDateDateTime.Value.Year > 2000)
            //            item.CreditCashDate = item.InvoiceDateDateTime.ToString();
            //        else item.CreditCashDate = null;
            //        item.CreditCashAmount = item.SalesAmount.ToString();
            //    }
            //    switch (item.Status)
            //    {
            //        case 0:
            //            item.StatusString = "All";
            //            break;
            //        case 1:
            //            item.StatusString = "Adjusted";
            //            break;
            //        case 2:
            //            item.StatusString = "UnAdjusted";
            //            break;
            //        case 3:
            //            item.StatusString = "Refunded";
            //            break;
            //        default:
            //            item.StatusString = "All";
            //            break;
            //    }
            //    if (item.SalesInvoiceNo != null && item.SalesInvoiceNo != "")
            //        item.CashCreditNo = item.SalesInvoiceNo;
            //    else if (item.CashChequeNo != null && item.CashChequeNo != "")
            //        item.CashCreditNo = item.CashChequeNo;
            //    else
            //        item.CashCreditNo = null;
            //    item.CreditAmount = item.CreditAmountValue.ToString();

            //}
            return Creditlist;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ICreditNoteListDAL purCredit = new CreditNoteListDAL();
            var result = purCredit.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ICreditNoteListDAL purCredit = new CreditNoteListDAL();
            var result = purCredit.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ICreditNoteListDAL purCredit = new CreditNoteListDAL();
            var result = purCredit.GetDateFormat();
            return result;
        }

        private string CheckConvertTo(bool? ConvertedToPI, bool? ConvertedToPO)
        {
            if (ConvertedToPI == true)
                return "Credit";
            else if (ConvertedToPO == true)
                return "Credit";
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
            return objTax.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {

            IOptionsDAL optionsDAL = new OptionsDAL();
            return optionsDAL.GetOptionsDetails();
        }
    }
}
