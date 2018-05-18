
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.BL
{
    using SDN.Products.BLInterface;

    using SDN.Products.DAL;
    using SDN.Products.DALInterface;
    using UI.Entities;
    using UI.Entities.Product;
    using UI.Entities.Purchase;
    using UI.Entities.Sales;

    public class PandSCategoryContentBL : IPandSCategoryContentBL
    {
        public List<ContentModel> GetCategoryContent(string catType)
        {
            IPandSCategoryContentDAL catDAL = new PandSCategoryContentDAL();
            List<ContentModel> lstcontent= catDAL.GetCategoryContent(catType);
            return lstcontent;
        }
    }

    public class PandSTaxCodeAndRateBL : IPandSTaxCodeAndRateBL
    {
        public List<TaxModel> GetTax()
        {
            IPandSTaxCodeAndRateDAL taxDAL = new PandSTaxCodeAndRateDAL();
            List<TaxModel> lsttax = taxDAL.GetTax();
            return lsttax;
        }
    }

    public class PAndSDetailsBL : IPAndSDetailsBL
    {
        public List<PandSDetailsModel> GetAllPandSCodes()
        {
            IPAndSDetailsDAL pandsDAL = new PAndSDetailsDAL();
            List<PandSDetailsModel> lstModel = pandsDAL.GetAllPandSCodes();
            return lstModel;
        }

        public List<PandSListModel> GetPandSComboList()
        {
            IPAndSDetailsDAL pandsDAL = new PAndSDetailsDAL();
            List<PandSListModel> lstModel = pandsDAL.GetPandSComboList();
            return lstModel;
        }
        public List<PandSDetailsModel> GetAllPandSNames()
        {
            IPAndSDetailsDAL pandsDAL = new PAndSDetailsDAL();
            List<PandSDetailsModel> lstModel = pandsDAL.GetAllPandSCodes();
            return lstModel;
        }
        public List<PandSQtyAndStockModel> GetPandSList()
        {
            IPAndSDetailsDAL pandsDAL = new PAndSDetailsDAL();
            List<PandSQtyAndStockModel> lstModel = pandsDAL.GetPandSList();
            return lstModel;
        }
    }

    public class PandSPurchaseInvoiceDetailsBL : IPandSPurchaseInvoiceDetailsBL
    {
        public List<PurchaseInvoiceEntity> GetPurchaseInvoiceDetails(int psID)
        {
            IPandSPurchaseInvoiceDetailsDAL purchaseDAL = new PandSPurchaseInvoiceDetailsDAL();
            List<PurchaseInvoiceEntity> lstPurchaseInvoices = purchaseDAL.GetPurchaseInvoiceDetails(psID);
            return lstPurchaseInvoices;
        }
    }

    public class PandSSalesInvoiceDetailsBL : IPandSSalesInvoiceDetailsBL
    {
        public List<SalesInvoiceEntity> GetSalesInvoiceDetails(int psId)
        {

            IPandSSalesInvoiceDetailsDAL saleDAL = new PandSSalesInvoiceDetailsDAL();
            List<SalesInvoiceEntity> lstPurchaseInvoices = saleDAL.GetSalesInvoiceDetails(psId);
            return lstPurchaseInvoices;
        }
    }

    public class OptionsDetailsBL : IOptionsDetailsBL
    {
        public OptionsEntity GetOptionsDetails()
        {
            IOptionsDetailsDAL optionDAL = new OptionsDetailsDAL();
            OptionsEntity lstOptions = optionDAL.GetOptionsDetails();
            return lstOptions;
        }
    }

    public class PandSDetailsOperationBL : IPandSDetailsOperationBL
    {
        public void DeletePandS(PandSDetailsModel pandsModel)
        {
            IPandSDetailsOperationDAL pandsOPDAL = new PandSDetailsOperationDAL();
            pandsOPDAL.DeletePandS(pandsModel);
        }

        public int SavePandS(PandSDetailsModel pandsModel)
        {
            IPandSDetailsOperationDAL pandsOPDAL = new PandSDetailsOperationDAL();
            return pandsOPDAL.SavePandS(pandsModel);
            
        }

        public void UpdatePandS(PandSDetailsModel pandsModel)
        {
            IPandSDetailsOperationDAL pandsOPDAL = new PandSDetailsOperationDAL();
            pandsOPDAL.UpdatePandS(pandsModel);
        }

        public void UpdateRefreshData(int psID)
        {
            IPandSDetailsOperationDAL pandsOPDAL = new PandSDetailsOperationDAL();
            pandsOPDAL.UpdateRefreshData(psID);
        }
    }
}
