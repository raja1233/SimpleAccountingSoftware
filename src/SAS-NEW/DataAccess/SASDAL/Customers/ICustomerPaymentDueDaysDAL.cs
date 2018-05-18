using SDN.UI.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Customers
{
    public interface ICustomerPaymentDueDaysDAL
    {
        List<CustomerPaymentDueDaysEntity> GetAllData();
    }
}
