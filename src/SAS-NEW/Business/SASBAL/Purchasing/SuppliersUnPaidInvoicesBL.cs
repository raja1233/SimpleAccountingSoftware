
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASBAL.Purchasing
{
    using SASDAL.Purchasing;
    using SDN.UI.Entities.Suppliers;
    public class SuppliersUnPaidInvoicesBL: ISuppliersUnPaidInvoicesBL
    {
        public List<SuppliersUnpaidInvoicesEntity> GetSuppliersList(string statementDate)
        {
            ISuppliersUnpaidInvoicesDAL sDAL = new SuppliersUnPaidInvoicesDAL();
            return sDAL.GetSuppliersList(statementDate);
        }
        public SuppliersStatementEntity GetAllUnPaidInvoice(int supplierID, string statementDate)
        {
            ISuppliersUnpaidInvoicesDAL sDAL = new SuppliersUnPaidInvoicesDAL();
            return sDAL.GetAllUnPaidInvoice(supplierID, statementDate);
        }
     }
}
