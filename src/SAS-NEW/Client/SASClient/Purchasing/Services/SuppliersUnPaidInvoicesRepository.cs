using SASBAL.Purchasing;
using SDN.UI.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Purchasing.Services
{
   public class SuppliersUnPaidInvoicesRepository: ISuppliersUnPaidInvoicesRepository
    {
        public List<SuppliersUnpaidInvoicesEntity> GetSuppliersList(string statementDate)
        {
            ISuppliersUnPaidInvoicesBL sDAL = new SuppliersUnPaidInvoicesBL();
            return sDAL.GetSuppliersList(statementDate);
        }
        public SuppliersStatementEntity GetAllUnPaidInvoice(int supplierID, string statementDate)
        {
            ISuppliersUnPaidInvoicesBL sDAL = new SuppliersUnPaidInvoicesBL();
            return sDAL.GetAllUnPaidInvoice(supplierID, statementDate);
        }
    }
}
