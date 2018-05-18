using SASDAL.Purchasing;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Purchasing
{
    public class SupplierPaymentDueDaysBL: ISupplierPaymentDueDaysBL
    {
        public List<SupplierPaymentDueDaysEntity> GetAllData()
        {
            ISupplierPaymentDueDaysDAL paymentDAL = new SupplierPaymentDueDaysDAL();
            List<SupplierPaymentDueDaysEntity> PaymentList = paymentDAL.GetAllData();
            return PaymentList;
        }
        public List<TaxModel> GetDefaultTaxes()
        {
            ITaxCodesAndRatesDAL objTax = new TaxCodesAndRatesDAL();
            return objTax.GetAllTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {

            IOptionsDAL optionsDAL = new OptionsDAL();
            return optionsDAL.GetOptionsDetails();
        }
    }
}
