using SASBAL.Customers;
using SDN.UI.Entities;
using SDN.UI.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Customers.Services
{
    public class CustomerPaymentDueDaysRepository : ICustomerPaymentDueDaysRepository
    {
        public List<CustomerPaymentDueDaysEntity> GetAllData()
        {
            ICustomerPaymentDueDaysBL paymentBL = new CustomerPaymentDueDaysBL();
            List<CustomerPaymentDueDaysEntity> PaymentList = paymentBL.GetAllData();
            return PaymentList;
        }
        public List<TaxModel> GetDefaultTaxes()
        {
            ICustomerPaymentDueDaysBL paymentBL = new CustomerPaymentDueDaysBL();
            return paymentBL.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            ICustomerPaymentDueDaysBL paymentBL = new CustomerPaymentDueDaysBL();
            return paymentBL.GetOptionSettings();

        }
    }
}
