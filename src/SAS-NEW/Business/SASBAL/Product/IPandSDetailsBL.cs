
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.BLInterface
{
    //using SDN.UI.Entities;
    using UI.Entities;
    using UI.Entities.Product;
    using UI.Entities.Purchase;
    using UI.Entities.Sales;

    public interface IPandSCategoryContentBL
    {
        List<ContentModel> GetCategoryContent(string catType);
    }

    public interface IPandSTaxCodeAndRateBL
    {
        List<TaxModel> GetTax();

    }
    public interface IPandSAccountDetailsBL
    {
        List<AccountsEntity> GetIncomeAcount();
        List<AccountsEntity> GetCostsAccount();
        List<AccountsEntity> GetAssetsAccount();
    }

    public interface IPAndSDetailsBL
    {
        List<PandSDetailsModel> GetAllPandSCodes();
        List<PandSDetailsModel> GetAllPandSNames();
        List<PandSListModel> GetPandSComboList();
        List<PandSQtyAndStockModel> GetPandSList();
    }

    public interface IPandSPurchaseInvoiceDetailsBL
    {
        List<PurchaseInvoiceEntity> GetPurchaseInvoiceDetails(int psID);
    }

    public interface IPandSSalesInvoiceDetailsBL
    {
        List<SalesInvoiceEntity> GetSalesInvoiceDetails(int psId);
    }

    public interface IOptionsDetailsBL
    {
        OptionsEntity GetOptionsDetails();
    }

    public interface IPandSDetailsOperationBL
    {
        int SavePandS(PandSDetailsModel pandsModel);
        void UpdatePandS(PandSDetailsModel pandsModel);
        void DeletePandS(PandSDetailsModel pandsModel);

        void UpdateRefreshData(int psID);
    }
}
