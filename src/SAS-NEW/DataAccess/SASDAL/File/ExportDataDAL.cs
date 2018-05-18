using SDN.UI.Entities.Export;
using SDN.UI.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.File
{
    public class ExportDataDAL : IExportDataDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        //public List<Sales_Quotation_List> GetSalesQuotationsList(string StartDate, string EndDate)
        //{
        //    List<Sales_Quotation_List> salesquotation = entities.Database.SqlQuery<Sales_Quotation_List>("USP_ExportSalesQuotationList @SDate,@EDate",
        //        new SqlParameter("SDate", StartDate),
        //              new SqlParameter("EDate", EndDate)).ToList();
        //    return salesquotation;
        //}
        //public List<Sales_Order_List> GetSalesOrdersList(string StartDate, string EndDate)
        //{
        //    List<Sales_Order_List> salesorder = entities.Database.SqlQuery<Sales_Order_List>("USP_ExportSalesOrderList @SDate,@EDate",
        //        new SqlParameter("SDate", StartDate),
        //              new SqlParameter("EDate", EndDate)).ToList();
        //    return salesorder;
        //}
        public List<Sales_Invoice_list> GetSalesInvoicesList(string StartDate, string EndDate)
        {
            List<Sales_Invoice_list> salesinvoice = entities.Database.SqlQuery<Sales_Invoice_list>("USP_ExportSalesInvoiceList  @SDate,@EDate",
                new SqlParameter("SDate", StartDate),
                      new SqlParameter("EDate", EndDate)).ToList();
            return salesinvoice;
        }
        //public List<Purchase_Quotation_List> GetPurchaseQuotationsList(string StartDate, string EndDate)
        //{
        //    List<Purchase_Quotation_List> purchasequotation = entities.Database.SqlQuery<Purchase_Quotation_List>("USP_ExportPurchaseQuotationList @SDate,@EDate",
        //        new SqlParameter("SDate", StartDate),
        //              new SqlParameter("EDate", EndDate)).ToList();
        //    return purchasequotation;
        //}
        //public List<Purchase_Order_List> GetPurchaseOrdersList(string StartDate, string EndDate)
        //{
        //    List<Purchase_Order_List> purchaseorder = entities.Database.SqlQuery<Purchase_Order_List>("USP_ExportPurchaseOrderList @SDate,@EDate",
        //        new SqlParameter("SDate", StartDate),
        //              new SqlParameter("EDate", EndDate)).ToList();
        //    return purchaseorder;
        //}
        public List<Purchase_Invoice_List> GetPurchaseInvoicesList(string StartDate, string EndDate)
        {
            List<Purchase_Invoice_List> purchaseinvoice = entities.Database.SqlQuery<Purchase_Invoice_List>("USP_ExportPurchaseInvoiceList @SDate,@EDate",
                new SqlParameter("SDate", StartDate),
                      new SqlParameter("EDate", EndDate)).ToList();
            return purchaseinvoice;
        }
        public List<PandS_Sold> GetPandSSoldList(string StartDate, string EndDate)
        {
            List<PandS_Sold> pandssold = entities.Database.SqlQuery<PandS_Sold>("USP_ExportPandSSold @SDate,@EDate",
                new SqlParameter("SDate", StartDate),
                      new SqlParameter("EDate", EndDate)).ToList();
            return pandssold;
        }
        public List<PandS_Purchase> GetPandSPurchaseList(string StartDate, string EndDate)
        {
            List<PandS_Purchase> pandspurchase = entities.Database.SqlQuery<PandS_Purchase>("USP_ExportPandSPurchase @SDate,@EDate",
                new SqlParameter("SDate", StartDate),
                      new SqlParameter("EDate", EndDate)).ToList();
            return pandspurchase;
        }
        public List<Gst_Tax_Collected> GetGstTaxCollected(string StartDate, string EndDate)
        {
            List<Gst_Tax_Collected> gsttaxcollected = entities.Database.SqlQuery<Gst_Tax_Collected>("USP_ExportTaxCollectedList @SDate,@EDate",
                new SqlParameter("SDate", StartDate),
                      new SqlParameter("EDate", EndDate)).ToList();
            return gsttaxcollected;
        }
        public List<Gst_Tax_Paid> GetGstTaxPaid(string StartDate, string EndDate)
        {
            List<Gst_Tax_Paid> gsttaxpaid = entities.Database.SqlQuery<Gst_Tax_Paid>("USP_ExportTaxPaidList @SDate,@EDate",
                new SqlParameter("SDate", StartDate),
                      new SqlParameter("EDate", EndDate)).ToList();
            return gsttaxpaid;
        }
        public List<Gst_Tax_Summary> GetGstTaxSummary(string StartDate, string EndDate)
        {
            List<Gst_Tax_Summary> gsttaxsummary = entities.Database.SqlQuery<Gst_Tax_Summary>("USP_ExportTaxSummaryList @SDate,@EDate",
                new SqlParameter("SDate", StartDate),
                      new SqlParameter("EDate", EndDate)).ToList();
            return gsttaxsummary;
        }
        public List<Credit_Note_List> GetCreditNoteList(string StartDate, string EndDate)
        {
            List<Credit_Note_List> creditnotelist = entities.Database.SqlQuery<Credit_Note_List>("USP_ExportCreditNoteList @SDate,@EDate",
                new SqlParameter("SDate", StartDate),
                      new SqlParameter("EDate", EndDate)).ToList();
            return creditnotelist;
        }
        public List<Debit_Note_List> GetDebitNoteList(string StartDate, string EndDate)
        {
            List<Debit_Note_List> debitnotelist = entities.Database.SqlQuery<Debit_Note_List>("USP_ExportDebitNoteList @SDate,@EDate",
                new SqlParameter("SDate", StartDate),
                      new SqlParameter("EDate", EndDate)).ToList();
            return debitnotelist;
        }

        public List<Customer_Detail> GetCustomerDetailList()
        {
            List<Customer_Detail> salesquotation = entities.Database.SqlQuery<Customer_Detail>("USP_ExportCustomerDetails").ToList();
            return salesquotation;
        }
        public List<Supplier_Detail> GetSupplierDetailList()
        {
            List<Supplier_Detail> supplierlist = entities.Database.SqlQuery<Supplier_Detail>("USP_ExportSupplierDetails").ToList();
            return supplierlist;
        }
        public List<PandS_Details> GetPandSDetailList()
        {
            List<PandS_Details> pandslist = entities.Database.SqlQuery<PandS_Details>("USP_ExportPandSDetails").ToList();
            return pandslist;
        }
        public List<Account_Detail> GetAccountDetailList()
        {
            List<Account_Detail> accountlist = entities.Database.SqlQuery<Account_Detail>("USP_ExportAccountDetails").ToList();
            return accountlist;
        }
        public List<Tax_Codes_and_Rates> GetTaxCodeRatelList()
        {
            List<Tax_Codes_and_Rates> taxcodelist = entities.Database.SqlQuery<Tax_Codes_and_Rates>("USP_ExportTaxCodeRate").ToList();
            return taxcodelist;
        }
        public List<TrailBalance_Details> GetTrialBalanceDetailList()
        {
            List<TrailBalance_Details> trialbalancelist = entities.Database.SqlQuery<TrailBalance_Details>("USP_ExportTrialBalanceDetails").ToList();
            return trialbalancelist;
        }
        public List<Profit_and_Loss_Detail> GetProfitandLossDetailList()
        {
            List<Profit_and_Loss_Detail> profitandloss = entities.Database.SqlQuery<Profit_and_Loss_Detail>("USP_ExportProfitAndLossDetailList").ToList();
            return profitandloss;
        }
        public List<Balance_Sheet> GetBalanceSheetDetailList()
        {
            List<Balance_Sheet> balancesheetlist = entities.Database.SqlQuery<Balance_Sheet>("USP_ExportBalanceSheetList").ToList();
            return balancesheetlist;
        }
    }
}
