using SDN.UI.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Purchasing
{
    public class SupplierPaymentDueDaysDAL: ISupplierPaymentDueDaysDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        public List<SupplierPaymentDueDaysEntity> GetAllData()
        {
            List<SupplierPaymentDueDaysEntity> PaymentList = entities.Database.SqlQuery<SupplierPaymentDueDaysEntity>("USP_SuppliersStatementPaymentDueDays").ToList();
            return PaymentList;
            //return null;
        }
    }
}
