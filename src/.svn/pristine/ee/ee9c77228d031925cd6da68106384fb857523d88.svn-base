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
    public class DebitNoteListBL : IDebitNoteListBL
    {
        public List<DebitNoteListEntity> GetAllPurDebit()
        {
            IDebitNoteListDAL purDebit = new DebitNoteListDAL();
            var Debitlist = purDebit.GetAllPurDebit();
            foreach (var item in Debitlist)
            {
                if (item.DebitDateDateTime != null)
                {
                    item.DebitDate = item.DebitDateDateTime.ToString();

                }
                if (item.CashChequeNo != null && item.CashChequeNo != "")
                {
                    item.DebitCashNO = item.CashChequeNo;
                    item.DebitCashDate = item.CashChequeDateDate.ToString();
                    item.DebitCashAmount = item.CashChequeAmount.ToString();
                }

                else
                {
                    item.DebitCashNO = item.PurchaseInvoiceNo;
                    item.DebitCashDate = item.InvoiceDateDateTime.ToString();
                    item.DebitCashAmount = item.PurchaseAmount.ToString();
                }
                switch (item.Status)
                {
                    case 0:
                        item.StatusString = "All";
                        break;
                    case 1:
                        item.StatusString = "Adjusted";
                        break;
                    case 2:
                        item.StatusString = "UnAdjusted";
                        break;
                    case 3:
                        item.StatusString = "Refunded";
                        break;
                    default:
                        item.StatusString = "All";
                        break;
                }


                if (item.PurchaseInvoiceNo != null && item.PurchaseInvoiceNo != "")
                    item.CashDebitNo = item.PurchaseInvoiceNo;
                else if (item.CashChequeNo != null && item.CashChequeNo != "")
                    item.CashDebitNo = item.CashChequeNo;
                else
                    item.CashDebitNo = null;
                item.DebitAmount = item.DebitAmountValue.ToString();
            }
            return Debitlist;
        }
        public List<DebitNoteListEntity> GetAllPurDebitJson(string jsondata, bool? ExcincTax)
        {
            IDebitNoteListDAL purDebit = new DebitNoteListDAL();
            var Debitlist = purDebit.GetAllPurDebitJson(jsondata, ExcincTax);
            foreach (var item in Debitlist)
            {
                if (item.DebitDateDateTime != null)
                {
                    item.DebitDate = item.DebitDateDateTime.ToString();

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
                    item.DebitCashNO = item.PurchaseInvoiceNo;
                    if (item.InvoiceDateDateTime != null && item.InvoiceDateDateTime.Value.Year > 2000)
                        item.DebitCashDate = item.InvoiceDateDateTime.ToString();
                    else item.DebitCashDate = null;
                    item.DebitCashAmount = item.PurchaseAmount.ToString();
                }
                switch (item.Status)
                {
                    case 0:
                        item.StatusString = "All";
                        break;
                    case 1:
                        item.StatusString = "Adjusted";
                        break;
                    case 2:
                        item.StatusString = "UnAdjusted";
                        break;
                    case 3:
                        item.StatusString = "Refunded";
                        break;
                   
                    default:
                        item.StatusString = "All";
                        break;
                }
                if (item.PurchaseInvoiceNo != null && item.PurchaseInvoiceNo != "")
                    item.CashDebitNo = item.PurchaseInvoiceNo;
                else if (item.CashChequeNo != null && item.CashChequeNo != "")
                    item.CashDebitNo = item.CashChequeNo;
                else
                    item.CashDebitNo = null;
                item.DebitAmount = item.DebitAmountValue.ToString();

            }
            return Debitlist;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IDebitNoteListDAL purDebit = new DebitNoteListDAL();
            var result = purDebit.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IDebitNoteListDAL purDebit = new DebitNoteListDAL();
            var result = purDebit.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IDebitNoteListDAL purDebit = new DebitNoteListDAL();
            var result = purDebit.GetDateFormat();
            return result;
        }

        private string CheckConvertTo(bool? ConvertedToPI, bool? ConvertedToPO)
        {
            if (ConvertedToPI == true)
                return "Debit";
            else if (ConvertedToPO == true)
                return "Debit";
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
            return objTax.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {

            IOptionsDAL optionsDAL = new OptionsDAL();
            return optionsDAL.GetOptionsDetails();
        }

    }
}
