
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Settings.DALInterface
{
    using SDN.UI.Entities;

    public interface ITaxCodesAndRatesDAL
    {
        List<TaxModel> GetAllTaxes();
        TaxModel GetDefaultTaxes();
    }

    public interface ITaxDAL
    {
       List<TaxModel> GetTax(int taxId);
    }

    public interface ITaxOperationDAL
    {
        void SaveTax(TaxModel taxModel);

        void UpdateTax(TaxModel taxModel);

        void DeleteTax(int id);

        bool IsCodeAndRateExists(TaxModel taxModel);
    }
    
}
