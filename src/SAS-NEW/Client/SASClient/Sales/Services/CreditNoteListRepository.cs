
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.Services
{
    using BL;
    using SDN.Sales.BLInterface;
    using SDN.UI.Entities.Sales;
    using UI.Entities;

    public class CreditNoteListRepository: ICreditNoteListRepository
    {
        public List<CreditNoteListEntity> GetAllSalesCreditJson(string jsondata, bool? ExcincTax)
        {
            ICreditNoteListBL SalesCredit = new CreditNoteListBL();
            List<CreditNoteListEntity> quotationlist = SalesCredit.GetAllSalesCreditJson(jsondata, ExcincTax);
            return quotationlist;
        }
        public List<CreditNoteListEntity> GetAllSalesCredit()
        {
            ICreditNoteListBL SalesCredit = new CreditNoteListBL();
            List<CreditNoteListEntity> Creditlist = SalesCredit.GetAllSalesCredit();
            return Creditlist;
        }
        public List<YearEntity> GetYearRange()
        {
            ICreditNoteListBL SalesCredit = new CreditNoteListBL();
            List<YearEntity> yearrange = SalesCredit.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ICreditNoteListBL SalesCredit = new CreditNoteListBL();
            var result = SalesCredit.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ICreditNoteListBL SalesCredit = new CreditNoteListBL();
            var result = SalesCredit.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            ICreditNoteListBL SalesCredit = new CreditNoteListBL();
            var result = SalesCredit.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            ICreditNoteListBL SalesCredit = new CreditNoteListBL();
            return SalesCredit.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            ICreditNoteListBL SalesCredit = new CreditNoteListBL();
            return SalesCredit.GetOptionSettings();

        }
    }
}
