

namespace SDN.Purchasing.Services
{
    using SDN.Purchasings.BL;
    using SDN.Purchasings.BLInterface;
    using SDN.UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class PurchaseQuotationListRepository: IPurchaseQuotationListRepository
    {
        public List<PurchaseQuotationListEntity> GetAllPurQuotationJson(string jsondata,bool? ExcincTax)
        {
            IPurchaseQuotationListBL purQuotation = new PurchaseQuotationListBL();
            List<PurchaseQuotationListEntity> quotationlist = purQuotation.GetAllPurQuotationJson(jsondata, ExcincTax);
            return quotationlist;
        }
        public List<PurchaseQuotationListEntity> GetAllPurQuotation()
        {
            IPurchaseQuotationListBL purQuotation = new PurchaseQuotationListBL();
            List<PurchaseQuotationListEntity> quotationlist = purQuotation.GetAllPurQuotation();
            return quotationlist;
        }
        public List<YearEntity> GetYearRange()
        {
            IPurchaseQuotationListBL purQuotation = new PurchaseQuotationListBL();
            List<YearEntity> yearrange = purQuotation.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson( string jsonSearch, int ScreenId, string ScreenName)
        {
            IPurchaseQuotationListBL purQuotation = new PurchaseQuotationListBL();
            var result = purQuotation.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData()
        {
            IPurchaseQuotationListBL purQuotation = new PurchaseQuotationListBL();
            var result = purQuotation.GetLastSelectionData();
            return result;
        }
        public string GetDateFormat()
        {
            IPurchaseQuotationListBL purQuotation = new PurchaseQuotationListBL();
            var result = purQuotation.GetDateFormat();
            return result;
        }
        public List<TaxModel> GetDefaultTaxes()
        {
            IPurchaseQuotationListBL purQuotation = new PurchaseQuotationListBL();
            return purQuotation.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IPurchaseQuotationListBL purQuotation = new PurchaseQuotationListBL();
            return purQuotation.GetOptionSettings();
           
        }
    }
}
    