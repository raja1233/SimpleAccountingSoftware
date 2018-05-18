using SDN.UI.Entities;
using SDN.UI.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Purchasing
{
    public interface ISupplierPaymentDueDaysBL
    {
        List<SupplierPaymentDueDaysEntity> GetAllData();
        List<TaxModel> GetDefaultTaxes();
        OptionsEntity GetOptionSettings();
    }
}
