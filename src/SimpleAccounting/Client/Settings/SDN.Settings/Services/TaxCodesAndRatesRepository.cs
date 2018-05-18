using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities;

namespace SDN.Settings.Services
{
    using SDN.Settings.BL;
    using SDN.Settings.BLInterface;
    

   public  class TaxCodesAndRatesRepository : ITaxCodesAndRatesRepository
    {
        /// <summary>
        /// This method is used to get all taxes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TaxModel> GetAllTaxes()
        {
            ITaxCodesAndRatesBL taxCRBL = new TaxCodesAndRatesBL();
            List<TaxModel> taxModel = taxCRBL.GetAllTaxes();

            return taxModel;
        }
    }

    public class TaxRepository : ITaxRepository
    {
        /// <summary>
        /// This method is used to get tax by id
        /// </summary>
        /// <param name="taxId"></param>
        /// <returns></returns>
        public IEnumerable<TaxModel> GetTax(int taxId)
        {
            ITaxBL taxBL = new TaxBL();
            List<TaxModel> tax = taxBL.GetTax(taxId);
            return tax;
        }
    }

    public class TaxOperationRepository: ITaxOperationRepository
    {
        /// <summary>
        /// This method is used to save tax
        /// </summary>
        /// <param name="taxModel"></param>
        public void SaveTax(TaxModel taxModel)
        {
            
            ITaxOperationBL taxBL = new TaxOperationBL();
            taxBL.SaveTax(taxModel);
        }

        /// <summary>
        /// This method is used to update tax
        /// </summary>
        /// <param name="taxModel"></param>
        public void UpdateTax(TaxModel taxModel)
        {
            ITaxOperationBL taxBL = new TaxOperationBL();
            taxBL.UpdateTax(taxModel);
        }

        /// <summary>
        /// This method is used to delete tax
        /// </summary>
        /// <param name="taxId"></param>
        public void DeleteTax(int taxId)
        {
            ITaxOperationBL taxBL = new TaxOperationBL();
            taxBL.DeleteTax(taxId);
        }
        
        public void SaveTaxName(string taxName)
        {
            IContentOperationBL catBL = new CategoryContentOperationsBL();
            catBL.SaveTaxName(taxName);
        }

        public bool IsCodeAndRateExists(TaxModel taxModel)
        {
            ITaxOperationBL taxBL = new TaxOperationBL();
            return taxBL.IsCodeAndRateExists(taxModel);
        }
    }

}
