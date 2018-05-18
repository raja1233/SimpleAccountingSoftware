using SDN.Purchasings.BL;
using SDN.Purchasings.BLInterface;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    public class DebitNoteListRepository : IDebitNoteListRepository
    {

        public List<DebitNoteListEntity> GetAllPurDebitJson(string jsondata, bool? ExcincTax)
        {
            IDebitNoteListBL purDebit = new DebitNoteListBL();
            List<DebitNoteListEntity> quotationlist = purDebit.GetAllPurDebitJson(jsondata, ExcincTax);
            return quotationlist;
        }
        public List<DebitNoteListEntity> GetAllPurDebit()
        {
            IDebitNoteListBL purDebit = new DebitNoteListBL();
            List<DebitNoteListEntity> Debitlist = purDebit.GetAllPurDebit();
            return Debitlist;
        }
        public List<YearEntity> GetYearRange()
        {
            IDebitNoteListBL purDebit = new DebitNoteListBL();
            List<YearEntity> yearrange = purDebit.GetYearRange();
            return yearrange;
        }
        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            IDebitNoteListBL purDebit = new DebitNoteListBL();
            var result = purDebit.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
            return result;
        }
        public string GetLastSelectionData(int ScreenId)
        {
            IDebitNoteListBL purDebit = new DebitNoteListBL();
            var result = purDebit.GetLastSelectionData(ScreenId);
            return result;
        }
        public string GetDateFormat()
        {
            IDebitNoteListBL purDebit = new DebitNoteListBL();
            var result = purDebit.GetDateFormat();
            return result;
        }
        public TaxModel GetDefaultTaxes()
        {
            IDebitNoteListBL purDebit = new DebitNoteListBL();
            return purDebit.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            IDebitNoteListBL purDebit = new DebitNoteListBL();
            return purDebit.GetOptionSettings();

        }
    }
}
