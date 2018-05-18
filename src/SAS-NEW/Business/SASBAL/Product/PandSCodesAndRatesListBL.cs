﻿using SDN.Products.BLInterface;
using SDN.Products.DAL;
using SDN.Products.DALInterface;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.BL
{
    public class PandSCodesAndRatesListBL : IPandSCodesAndRatesListBL
    {
        public List<PandSCodesAndRatesListEntity> GetPandSList()
        {
            IPandSCodesAndRatesListDAL pandsdal = new PandSCodesAndRatesListDAL();
            return pandsdal.GetPandSList();
        }
        // public List<TaxModel> GetDefaultTaxes()
        //{
        //    ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
        //    return objTax.GetAllTaxes();
        //}
        //public OptionsEntity GetOptionSettings()
        //{
        //    IOptionsDAL optionsDAL = new OptionsDAL();
        //    return optionsDAL.GetOptionsDetails();
        //}
    }
}
