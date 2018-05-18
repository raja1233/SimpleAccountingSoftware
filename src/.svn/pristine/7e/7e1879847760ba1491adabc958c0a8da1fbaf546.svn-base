using SDN.UI.Entities;
using SDN.UI.Entities.Export;
using SDN.UI.Entities.ProductandServices;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.File
{
    public interface IExportDataDAL
    {
        //List<SalesQuotationEntity> GetSalesQuotationsList(string StartDate, string EndDate);
        //List<SalesOrderListEntity> GetSalesOrdersList(string StartDate, string EndDate);
        //List<SalesInvoiceEntity> GetSalesInvoicesList(string StartDate, string EndDate);
        //List<PurchaseQuotationEntity> GetPurchaseQuotationsList(string StartDate, string EndDate);
        //List<PurchaseOrderEntity> GetPurchaseOrdersList(string StartDate, string EndDate);
        //List<PurchaseInvoiceListEntity> GetPurchaseInvoicesList(string StartDate, string EndDate);
        //List<PandSSoldEntity> GetProductsServicesSold(string StartDate, string EndDate);
        //List<PandSPurchaseEntity> GetProductsServicesPurchased(string StartDate, string EndDate);
        //List<SalesQuotationEntity> GetCashBankStatement(string StartDate, string EndDate);
        //List<SalesQuotationEntity> GetGSTSummary(string StartDate, string EndDate);

        //List<SalesQuotationEntity> GetGSTCollectedDetails(string StartDate, string EndDate);
        //List<SalesQuotationEntity> GetGSTPaidDetails(string StartDate, string EndDate);
        List<Customer_Detail> GetCustomerDetailList();
        List<Supplier_Detail> GetSupplierDetailList();
        List<PandS_Details> GetPandSDetailList();
        List<Account_Detail> GetAccountDetailList();
        List<Tax_Codes_and_Rates> GetTaxCodeRatelList();
        List<TrailBalance_Details> GetTrialBalanceDetailList();
        List<Profit_and_Loss_Detail> GetProfitandLossDetailList();
        List<Balance_Sheet> GetBalanceSheetDetailList();
        //List<Sales_Quotation_List> GetSalesQuotationsList(string StartDate, string EndDate);
        //List<Sales_Order_List> GetSalesOrdersList(string StartDate, string EndDate);
        List<Sales_Invoice_list> GetSalesInvoicesList(string StartDate, string EndDate);
       // List<Purchase_Quotation_List> GetPurchaseQuotationsList(string StartDate, string EndDate);
       // List<Purchase_Order_List> GetPurchaseOrdersList(string StartDate, string EndDate);
        List<Purchase_Invoice_List> GetPurchaseInvoicesList(string StartDate, string EndDate);
        List<PandS_Sold> GetPandSSoldList(string StartDate, string EndDate);
        List<PandS_Purchase> GetPandSPurchaseList(string StartDate, string EndDate);
        List<Gst_Tax_Collected> GetGstTaxCollected(string StartDate, string EndDate);
        List<Gst_Tax_Paid> GetGstTaxPaid(string StartDate, string EndDate);
        List<Gst_Tax_Summary> GetGstTaxSummary(string StartDate, string EndDate);
        List<Credit_Note_List> GetCreditNoteList(string StartDate, string EndDate);
        List<Debit_Note_List> GetDebitNoteList(string StartDate, string EndDate);
    }
}
