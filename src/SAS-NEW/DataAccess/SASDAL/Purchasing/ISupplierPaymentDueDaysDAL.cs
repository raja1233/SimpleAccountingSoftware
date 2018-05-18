using SDN.UI.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Purchasing
{
    public interface ISupplierPaymentDueDaysDAL
    {
        List<SupplierPaymentDueDaysEntity> GetAllData();
    }
}
