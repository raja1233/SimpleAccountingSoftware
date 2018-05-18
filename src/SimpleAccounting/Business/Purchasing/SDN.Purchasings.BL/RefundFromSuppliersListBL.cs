
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BL
{
    using DAL;
    using DALInterface;
    using SDN.Purchasings.BLInterface;
    using SDN.UI.Entities.Purchase;
    using Settings.DAL;
    using Settings.DALInterface;
    using UI.Entities;

    public class RefundFromSuppliersListBL: IRefundFromSuppliersListBL
    {
        public List<RefundFromSuppliersListEntity> GetAllPurInvoice()
        {
            IRefundFromSupplierListDAL purInvoice = new RefundFromSuppliersListDAL();
            var Invoicelist = purInvoice.GetAllPurInvoice();
            foreach (var item in Invoicelist)
            {
                if (item.InvoiceDateDateTime != null)
                {
                    item.InvoiceDate = Convert.ToString(item.InvoiceDateDateTime);

                }
                if (item.InvoiceAmountValue != null)
                {
                    item.InvoiceAmount = Convert.ToString(item.InvoiceAmountValue);
                }

                if (item.CashChequeAmount != null)
                {
                    item.CashAmount = Convert.ToString(item.CashChequeAmount);
                }

                if (item.CashChequeDateDate != null)
                {
                    item.CashChequeDate = Convert.ToString(item.CashChequeDateDate);
                }
            }
            return Invoicelist;
        }

        public List<RefundFromSuppliersListEntity> GetAllPurInvoiceJson(string jsondata)
        {
            IRefundFromSupplierListDAL purInvoice = new RefundFromSuppliersListDAL();
            var Invoicelist = purInvoice.GetAllPurInvoiceJson(jsondata);
            foreach (var item in Invoicelist)
            {
                if (item.InvoiceDateDateTime != null)
                {
                    item.InvoiceDate = Convert.ToString(item.InvoiceDateDateTime);

                }
                if (item.InvoiceAmountValue != null)
                {
                    item.InvoiceAmount = Convert.ToString(item.InvoiceAmountValue);
                }

                if (item.CashChequeAmount != null)
                {
                    item.CashAmount = Convert.ToString(item.CashChequeAmount);
                }

                if (item.CashChequeDateDate != null)
                {
                    item.CashChequeDate = Convert.ToString(item.CashChequeDateDate);
                }
            }
            return Invoicelist;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IRefundFromSupplierListDAL purInvoice = new RefundFromSuppliersListDAL();
            var result = purInvoice.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IRefundFromSupplierListDAL purInvoice = new RefundFromSuppliersListDAL();
            var result = purInvoice.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IRefundFromSupplierListDAL purInvoice = new RefundFromSuppliersListDAL();
            var result = purInvoice.GetDateFormat();
            return result;
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
