using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using SASBAL.Accounts;

namespace SASClient.Accounts.Services
{
    public class UnpaidSalesInvoiceRepository : IUnpaidSalesInvoiceRepository
    {
        public List<UnpaidSalesInvoiceEntity> getCustomerList()
        {
            IUnpaidSalesInvoiceBL obj = new UnpaidSalesInvoiceBL();
            return obj.getCustomerList();
        }

        public List<string>  IsChequeNoPresent()
        {
            IUnpaidSalesInvoiceBL obj = new UnpaidSalesInvoiceBL();
            return obj.IsChequeNoPresent();
        }

        public int SaveUnpaidSalesInvoiceData(UnpaidSalesInvoiceModel JForm)
        {
            IUnpaidSalesInvoiceBL obj = new UnpaidSalesInvoiceBL();
            return obj.SaveUnpaidSalesInvoiceData(JForm);
        }
    }
}
