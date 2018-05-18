
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Sales.BL
{
    using DALInterface;
    using SCN.Sales.DAL;
    using SDN.Sales.BLInterface;
    using UI.Entities.Sales;

    public class SalesInvoiceBL: ISalesInvoiceBL
    {
        public int AddUpdateInvoice(SalesInvoiceForm quotationData)
        {
            ISalesInvoiceDAL PQDAL = new SalesInvoiceDAL();
            return PQDAL.AddUpdateInvoice(quotationData);
        }

        public int DeleteInvoice(string purchaseQuotID)
        {
            ISalesInvoiceDAL PQDAL = new SalesInvoiceDAL();
            return PQDAL.DeleteInvoice(purchaseQuotID);
        }

        public List<SalesInvoiceEntity> GetAllSalesInvoices()
        {
            ISalesInvoiceDAL PQDAL = new SalesInvoiceDAL();
            return PQDAL.GetAllSalesInvoices();
        }

        public string GetLatestInvoiceNo()
        {
            ISalesInvoiceDAL PQDAL = new SalesInvoiceDAL();
            return PQDAL.GetLastInvoiceNo();
        }

        public SalesInvoiceForm GetSalesInvoice(string pqNo)
        {
            ISalesInvoiceDAL PQDAL = new SalesInvoiceDAL();
            return PQDAL.GetSalesInvoice(pqNo);
        }

        public int UpdationInvoice(SalesInvoiceForm quotationData)
        {
            ISalesInvoiceDAL PQDAL = new SalesInvoiceDAL();
            return PQDAL.UpdationInvoice(quotationData);
        }

        public string GetCategoryContent(string catType)
        {
            ISalesInvoiceDAL PQDAL = new SalesInvoiceDAL();
            return PQDAL.GetCategoryContent(catType);
        }

    }
}
