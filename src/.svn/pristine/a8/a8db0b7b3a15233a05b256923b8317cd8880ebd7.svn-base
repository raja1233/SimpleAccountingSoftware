
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Settings.BLInterface
{
    using SDN.UI.Entities;

    public interface ITaxCodesAndRatesBL
    {
        List<TaxModel> GetAllTaxes();
    }

    public interface ITaxBL
    {
        List<TaxModel> GetTax(int taxId);
    }

    public interface ITaxOperationBL
    {
        void SaveTax(TaxModel taxModel);
        void UpdateTax(TaxModel taxModel);
        void DeleteTax(int taxId);

        bool IsCodeAndRateExists(TaxModel taxModel);
    }
}
