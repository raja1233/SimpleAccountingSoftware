using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.DALInterface
{
    using SDN.UI.Entities;
    using UI.Entities.Product;
    using UI.Entities.Purchase;
    using UI.Entities.Sales;

    //using UI.Entities;

    public interface IPandSCategoryContentDAL
    {
        List<ContentModel> GetCategoryContent(string catType);
    }

    public interface IPandSTaxCodeAndRateDAL
    {
        List<TaxModel> GetTax();
    }
    public interface IPandSAccountDetailsDAL
    {
        List<AccountsEntity> GetIncomeAcount();
        List<AccountsEntity> GetCostsAccount();
        List<AccountsEntity> GetAssetsAccount();
    }

    public interface IPandSPurchaseInvoiceDetailsDAL
    {
        List<PurchaseInvoiceEntity> GetPurchaseInvoiceDetails(int psId);
    }

    public interface IPandSSalesInvoiceDetailsDAL
    {
        List<SalesInvoiceEntity> GetSalesInvoiceDetails(int psId);
    }

    public interface IOptionsDetailsDAL
    {
        OptionsEntity GetOptionsDetails();
    }

    public interface IPAndSDetailsDAL
    {
        List<PandSDetailsModel> GetAllPandSCodes();
        List<PandSDetailsModel> GetAllPandSNames();
        List<PandSListModel> GetPandSComboList();

        List<PandSQtyAndStockModel> GetPandSList();
    }

    public interface IPandSDetailsOperationDAL
    {
        int SavePandS(PandSDetailsModel pandsModel);
        void UpdatePandS(PandSDetailsModel pandsModel);
        void DeletePandS(PandSDetailsModel pandsModel);

        void UpdateRefreshData(int psID);

    }
}
