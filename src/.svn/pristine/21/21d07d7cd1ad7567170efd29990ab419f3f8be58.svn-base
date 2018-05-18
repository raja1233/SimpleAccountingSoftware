using SDN.Purchasings.BLInterface;
using SDN.Purchasings.DAL;
using SDN.Purchasings.DALInterface;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BL
{
    public class PurchaseInvoiceListBL : IPurchaseInvoiceListBL
    {
        public List<PurchaseInvoiceListEntity> GetAllPurInvoice()
        {
            IPurchaseInvoiceListDAL purInvoice = new PurchaseInvoiceListDAL();
            var Invoicelist = purInvoice.GetAllPurInvoice();
            foreach (var item in Invoicelist)
            {
                if (item.InvoiceDateDateTime != null)
                {
                    item.InvoiceDate = item.InvoiceDateDateTime.ToString();

                }
                if (item.CashChequeNo != null && item.CashChequeNo != "")
                {
                    item.DebitCashNO = item.CashChequeNo;
                    item.DebitCashDate = item.CashChequeDateDate.ToString();
                    item.DebitCashAmount = item.CashChequeAmount.ToString();
                }

                else
                {
                    item.DebitCashNO = item.DebitNoteNo;
                    item.DebitCashDate = item.DebitNoteDateDate.ToString();
                    item.DebitCashAmount = item.DebitNoteAmount.ToString();
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


                if (item.DebitNoteNo != null && item.DebitNoteNo != "")
                    item.CashDebitNo = item.DebitNoteNo;
                else if (item.CashChequeNo != null && item.CashChequeNo != "")
                    item.CashDebitNo = item.CashChequeNo;
                else
                    item.CashDebitNo = null;
                item.InvoiceAmount = item.InvoiceAmountValue.ToString();
            }
            return Invoicelist;
        }
        public List<PurchaseInvoiceListEntity> GetAllPurInvoiceJson(string jsondata, bool? ExcincTax)
        {
            IPurchaseInvoiceListDAL purInvoice = new PurchaseInvoiceListDAL();
            var Invoicelist = purInvoice.GetAllPurInvoiceJson(jsondata, ExcincTax);
            foreach (var item in Invoicelist)
            {
                if (item.InvoiceDateDateTime != null)
                {
                    item.InvoiceDate = item.InvoiceDateDateTime.ToString();

                }
                //if (item.CashChequeNo != null && item.CashChequeNo != "")
                //    item.DebitCashNO = item.CashChequeNo;
                //else
                //    item.DebitCashNO = item.DebitNoteNo;
                //if (item.CashChequeDateDate != null && item.CashChequeDateDate.Value.Year>2000)
                //    item.DebitCashDate = item.CashChequeDateDate.ToString();
                //else if(item.DebitNoteDateDate!=null && item.DebitNoteDateDate.Value.Year > 2000)
                //    item.DebitCashDate = item.DebitNoteDateDate.ToString();
                //if (item.CashChequeAmount != null && item.CashChequeAmount != 0)
                //    item.DebitCashAmount = item.CashChequeAmount;
                //else if (item.DebitNoteAmount != null && item.DebitNoteAmount != 0)
                //    item.DebitCashAmount = item.DebitNoteAmount;
                if (item.CashChequeNo != null && item.CashChequeNo != "")
                {
                    item.DebitCashNO = item.CashChequeNo;
                    if (item.CashChequeDateDate != null && item.CashChequeDateDate.Value.Year > 2000)
                        item.DebitCashDate = item.CashChequeDateDate.ToString();
                    else item.DebitCashDate = null;
                    item.DebitCashAmount = item.CashChequeAmount.ToString();
                }

                else
                {
                    item.DebitCashNO = item.DebitNoteNo;
                    if (item.DebitNoteDateDate != null && item.DebitNoteDateDate.Value.Year > 2000)
                        item.DebitCashDate = item.DebitNoteDateDate.ToString();
                    else item.DebitCashDate = null;
                    item.DebitCashAmount = item.DebitNoteAmount.ToString();
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
                if (item.DebitNoteNo != null && item.DebitNoteNo != "")
                    item.CashDebitNo = item.DebitNoteNo;
                else if (item.CashChequeNo != null && item.CashChequeNo != "")
                    item.CashDebitNo = item.CashChequeNo;
                else
                    item.CashDebitNo = null;
                item.InvoiceAmount = item.InvoiceAmountValue.ToString();

            }
            return Invoicelist;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IPurchaseInvoiceListDAL purInvoice = new PurchaseInvoiceListDAL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData()
        {
            IPurchaseInvoiceListDAL purInvoice = new PurchaseInvoiceListDAL();
            var result = purInvoice.GetLastSelectionData();
            return result;
        }
        public string GetDateFormat()
        {
            IPurchaseInvoiceListDAL purInvoice = new PurchaseInvoiceListDAL();
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
                    obj = new YearEntity();
                    obj.Year = StartYear.ToString();
                    obj.ID = i;
                    YearRange.Add(obj);
                    StartYear++;
                }
                return YearRange;
            }
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

    }
}
