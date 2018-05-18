using SASDAL.Customers;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.UI.Entities;
using SDN.UI.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Customers
{
    public class CustomerPaymentDueDaysBL : ICustomerPaymentDueDaysBL
    {
        public List<CustomerPaymentDueDaysEntity> GetAllData()
        {
            ICustomerPaymentDueDaysDAL paymentDAL = new CustomerPaymentDueDaysDAL();
            List<CustomerPaymentDueDaysEntity> PaymentList = paymentDAL.GetAllData();
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
