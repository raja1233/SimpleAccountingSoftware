using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Common
{
    public enum ScreenId
    {
        PurchaseQuotationList = 1,
        PurchaseOrderList = 2,
        PurchaseInvoiceList = 3,
        DebitNoteList = 4,
        PaymentsToSuppliersList=5,
        SalesQuotationList=6,
        SalesOrderList=7,
        SalesInvoiceList=8,
        CreditNoteList=9,
        PaymentFromCustomersList=10,
        RefundFromSuppliersList=11,
        RefundToCustomersList=12,
        PandSSold = 13,
        CustomerHistory = 14,
        SupplierHistory = 15,
        TopPandS=16,
        PandSPurchase = 17,
        PandSSoldToCustomers = 18,
        TopCustomers=19,
        TopSuppliers=20
    }
    public enum PI_Status
    {
        All = 0,
        Paid = 1,
        UnPaid = 2,
        Adjusted = 3,
        Cancelled = 4
    }

    public enum SI_Status
    {
        All = 0,
        Paid = 1,
        UnPaid = 2,
        Adjusted = 3,
        Cancelled = 4
    }
    public enum DN_Status
    {
       Adjusted=1,
        UnAdjusted=2,
       Refunded =3
    }
    public enum CN_Status
    {
        Adjusted = 1,
        UnAdjusted = 2,
        Refunded = 3
    }
    public enum CashBankTransactionType
    {
        PaymentToSupplier = 1,
        PaymentFromCustomer = 2,
        AdjustDebitNote = 3,
        AdjustCreditNote = 4,
        RefundFromSupplier = 5,
        RefundToCustomer = 6
    }

    public enum PO_Status
    {
        Collected=1,
        Refunded=2,
        unDeposited=3,
        Cancelled = 4
    }

    public enum Stock_Type
    { 
        IncreaseDecreaseStock=1,
        StockDamaged=2,
        StockTake=3
    }

    public enum Account_Type
    {
        Bank=2,
        Cash=3
    }
}
