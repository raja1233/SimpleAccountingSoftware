﻿using SDN.UI.Entities;
using SDN.UI.Entities.ProductandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.Services
{
    public interface IPandSCodesAndRatesListRepository
    {
        List<PandSCodesAndRatesListEntity> GetPandSList();
        OptionsEntity GetOptionDetails();
        IEnumerable<TaxModel> GetTaxes();
    }
}
