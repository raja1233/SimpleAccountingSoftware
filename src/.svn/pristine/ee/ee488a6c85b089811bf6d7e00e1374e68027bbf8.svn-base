
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Settings.Services
{
    using SDN.UI.Entities;

    public interface ITaxCodesAndRatesRepository
    {
        IEnumerable<TaxModel> GetAllTaxes();
    }

    public interface ITaxRepository
    {
        IEnumerable<TaxModel> GetTax(int taxId);
    }

    public interface ITaxOperationRepository
    {
        void SaveTax(TaxModel taxModel);
        void UpdateTax(TaxModel taxModel);
        void DeleteTax(int taxId);
        
        void SaveTaxName(string taxName);
        bool IsCodeAndRateExists(TaxModel taxModel);

    }

}
