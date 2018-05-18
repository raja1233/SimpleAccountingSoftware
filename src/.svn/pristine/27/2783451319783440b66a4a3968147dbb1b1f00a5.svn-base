using SDN.UI.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Customers
{
    public class CustomerPaymentDueDaysDAL : ICustomerPaymentDueDaysDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        public List<CustomerPaymentDueDaysEntity> GetAllData()
        {
            List<CustomerPaymentDueDaysEntity> PaymentList = entities.Database.SqlQuery<CustomerPaymentDueDaysEntity>("USP_CustomersStatementPaymentDueDays").ToList();
            return PaymentList;
            //return null;
        }
    }
}
