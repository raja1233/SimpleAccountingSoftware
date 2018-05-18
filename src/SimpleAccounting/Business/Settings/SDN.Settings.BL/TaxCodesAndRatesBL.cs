using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Settings.BL
{
    using SDN.Settings.BLInterface;
    using SDN.Settings.DAL;
    using SDN.Settings.DALInterface;
    using UI.Entities;

    public class TaxCodesAndRatesBL : ITaxCodesAndRatesBL
    {
        /// <summary>
        /// This method is used to get all taxes
        /// </summary>
        /// <returns></returns>
        public List<TaxModel> GetAllTaxes()
        {
            ITaxCodesAndRatesDAL taxCRBL = new TaxCodesAndRatesDAL();
             List<TaxModel> lstTaxes= taxCRBL.GetAllTaxes();
            foreach (var e in lstTaxes)
            {
                e.StrTaxRate = Convert.ToString(e.TaxRate) + " %";
            }
            return lstTaxes;
        }
    }

    public class TaxBL : ITaxBL
    {
        /// <summary>
        /// This method is used to get tax by id
        /// </summary>
        /// <param name="taxId"></param>
        /// <returns></returns>
        public List<TaxModel> GetTax(int taxId)
        {
            ITaxDAL taxDAL = new TaxDAL();
            List<TaxModel> tax = taxDAL.GetTax(taxId);
            foreach (var e in tax)
            {
                decimal s = 0;
                bool ok = Decimal.TryParse(e.StrTaxRate.Replace("%", "").Trim(), out s);
                e.TaxRate = s;
            }

            return tax;

        }
    }

    public class TaxOperationBL : ITaxOperationBL
    {
        public void DeleteTax(int taxId)
        {
            ITaxOperationDAL taxDAL = new TaxOperationDAL();
            taxDAL.DeleteTax(taxId);
        }

        public bool IsCodeAndRateExists(TaxModel taxModel)
        {
            ITaxOperationDAL taxDAL = new TaxOperationDAL();
            return taxDAL.IsCodeAndRateExists(taxModel);
        }

        public void SaveTax(TaxModel taxModel)
        {
            
            ITaxOperationDAL taxDAL = new TaxOperationDAL();
            taxDAL.SaveTax(taxModel);
        }

        public void UpdateTax(TaxModel taxModel)
        {
            ITaxOperationDAL taxDAL = new TaxOperationDAL();
            taxDAL.UpdateTax(taxModel);
        }

        
    }
}
