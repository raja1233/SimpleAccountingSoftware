using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.Services
{

    using SDN.Products.BL;
    using SDN.Products.BLInterface;
    using UI.Entities;
    using UI.Entities.Product;
    using UI.Entities.Purchase;
    using UI.Entities.Sales;

    public class PandSDetailsRepository:IPandSDetailsRepository
    {
        /// <summary>
        /// This method is used to get contents from categories content table
        /// </summary>
        /// <param name="catType"></param>
        /// <returns></returns>
        public IEnumerable<ContentModel> GetCategoryContent(string catType)
        {
            IPandSCategoryContentBL pandSCategoryBL = new PandSCategoryContentBL();
            List<ContentModel> lstContent= pandSCategoryBL.GetCategoryContent(catType);
            return lstContent;

        }

        /// <summary>
        /// This method is used to get taxes 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TaxModel> GetTaxes()
        {
            IPandSTaxCodeAndRateBL pandSTaxBL = new PandSTaxCodeAndRateBL();
            List<TaxModel> lsttaxes = pandSTaxBL.GetTax();
            return lsttaxes;
        }
        
        /// <summary>
        /// This method is used to get all P and S 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PandSDetailsModel> GetAllPandS()
        {
            IPAndSDetailsBL pandSBL = new PAndSDetailsBL();
            List<PandSDetailsModel> lstPandS= pandSBL.GetAllPandSCodes();
            return lstPandS;
        }

        public IEnumerable<PandSListModel> GetPandSComboList()
        {
            IPAndSDetailsBL pandSBL = new PAndSDetailsBL();
            List<PandSListModel> lstPandS = pandSBL.GetPandSComboList();
            return lstPandS;
        }

        public List<PandSQtyAndStockModel> GetPandSList()
        {
            IPAndSDetailsBL pandSBL = new PAndSDetailsBL();
            List<PandSQtyAndStockModel> lstPandS = pandSBL.GetPandSList();
            return lstPandS;
        }

        public int SavePandS(PandSDetailsModel pandsModel)
        {
            IPandSDetailsOperationBL pandSBL = new PandSDetailsOperationBL();
           return pandSBL.SavePandS(pandsModel);
        }

        public void UpdatePandS(PandSDetailsModel pandsModel)
        {
            IPandSDetailsOperationBL pandsBL = new PandSDetailsOperationBL();
            pandsBL.UpdatePandS(pandsModel);
        }
         
        public void DeletePandS(PandSDetailsModel pandSModel)
        {
            IPandSDetailsOperationBL pandsBL = new PandSDetailsOperationBL();
            pandsBL.DeletePandS(pandSModel);
        }
        public List<PurchaseInvoiceEntity> GetPurchaseInvoiceDetails(int PSID)
        {
            IPandSPurchaseInvoiceDetailsBL purchaseDAL = new PandSPurchaseInvoiceDetailsBL();
            List<PurchaseInvoiceEntity> lstPurchaseInvoices = purchaseDAL.GetPurchaseInvoiceDetails(PSID);
            return lstPurchaseInvoices;
        }
        public List<SalesInvoiceEntity> GetSalesInvoiceDetails(int PSID)
        {
            IPandSSalesInvoiceDetailsBL saleDAL = new PandSSalesInvoiceDetailsBL();
            List<SalesInvoiceEntity> lstPurchaseInvoices = saleDAL.GetSalesInvoiceDetails(PSID);
            return lstPurchaseInvoices;
        }
        public OptionsEntity GetOptionDetails()
        {
            IOptionsDetailsBL optionDAL = new OptionsDetailsBL();
            OptionsEntity lstOptions = optionDAL.GetOptionsDetails();
            return lstOptions;
        }

       public void UpdateRefreshData(int psID)
        {
            IPandSDetailsOperationBL pandsBL = new PandSDetailsOperationBL();
            pandsBL.UpdateRefreshData(psID);
        }
    }
}
