using SDN.UI.Entities;
using SDN.UI.Entities.Product;
using SDN.UI.Entities.Purchase;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.Services
{


    public interface IPandSDetailsRepository
    {
        IEnumerable<ContentModel> GetCategoryContent(string catType);
        IEnumerable<TaxModel> GetTaxes();
        List<PandSQtyAndStockModel> GetPandSList();
        IEnumerable<PandSDetailsModel> GetAllPandS();
        IEnumerable<PandSListModel> GetPandSComboList();
        int SavePandS(PandSDetailsModel pandsModel);
        void UpdatePandS(PandSDetailsModel pandsModel);
        void DeletePandS(PandSDetailsModel pandsModel);

        List<PurchaseInvoiceEntity> GetPurchaseInvoiceDetails(int PSID);
        List<SalesInvoiceEntity> GetSalesInvoiceDetails(int PSID);
        OptionsEntity GetOptionDetails();

        void UpdateRefreshData(int psID);
    }
}
