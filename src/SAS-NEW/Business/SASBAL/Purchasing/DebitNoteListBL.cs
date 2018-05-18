﻿using SDN.Purchasings.BLInterface;
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
            return Debitlist;
        }
        public List<DebitNoteListEntity> GetAllPurDebitJson(string jsondata, bool? ExcincTax)
        {
            IDebitNoteListDAL purDebit = new DebitNoteListDAL();
            var Debitlist = purDebit.GetAllPurDebitJson(jsondata, ExcincTax);
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