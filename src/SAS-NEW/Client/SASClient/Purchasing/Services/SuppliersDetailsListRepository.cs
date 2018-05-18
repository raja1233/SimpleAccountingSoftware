
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Purchasing.Services
{
    using SASBAL.Purchasing;
    using SDN.Settings.DAL;
    using SDN.Settings.DALInterface;
    using SDN.UI.Entities;
    using SDN.UI.Entities.Purchase;
    public class SuppliersDetailsListRepository: ISuppliersDetailsListRepository
    {
        public List<SuppliersDetailsListEntity> GetSuppliersList(string json)
        {
            ISuppliersDetailsListBL cdDAL = new SuppliersDetailsListBL();
            return cdDAL.GetSuppliersList(json);
        }

        public bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName)
        {
            ISuppliersDetailsListBL cdDAL = new SuppliersDetailsListBL();
            return cdDAL.SaveSearchJson(jsonSearch, ScreenId, ScreenName);
        }
        public string GetLastSelectionData(int ScreenId)
        {
            ISuppliersDetailsListBL cdDAL = new SuppliersDetailsListBL();
            return cdDAL.GetLastSelectionData(ScreenId);
        }
        public TaxModel GetDefaultTaxes()
        {
            ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
            return objTax.GetAllTaxes().FirstOrDefault();
        }
        public OptionsEntity GetOptionSettings()
        {
            IOptionsDAL optionsDAL = new OptionsDAL();
            return optionsDAL.GetOptionsDetails();
        }

        public List<SuppliersDetailsListEntity> GetStatusCount(int ScreenID)
        {
            ISuppliersDetailsListBL obj = new SuppliersDetailsListBL();
            return obj.GetStatusCount(ScreenID);
        }
    }
}
