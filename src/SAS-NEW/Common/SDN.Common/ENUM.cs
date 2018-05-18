﻿using System;
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
        PaymentsToSuppliersList = 5,
        SalesQuotationList = 6,
        SalesOrderList = 7,
        SalesInvoiceList = 8,
        CreditNoteList = 9,
        PaymentFromCustomersList = 10,
        RefundFromSuppliersList = 11,
        RefundToCustomersList = 12,
        PandSSold = 13,
        CustomerHistory = 14,
        SupplierHistory = 15,
        TopPandS = 16,
        PandSPurchase = 17,
        PandSSoldToCustomers = 18,
        TopCustomers = 19,
        TopSuppliers = 20,
        PandSPurchasedFromSuppliers = 22,

        PandSHistoryList=21,
        ReceiveMoneyList = 23,
        PayMoneyList = 24,
        TransferMoneyList = 25,
        InvoiceDebitPaymentsList=26,
        SupplierCreditPaidDays = 28,
        InvoiceCreditPaymentsList=27,
        CustomerCreditPaidDays = 29,
        CustomerDetailsList=30,
        SupplierDetailsList=31,
        NotificationList = 32,
        AuditTrailList = 33,
        CountAndAdjustStockList = 34,
        JournalList = 35,
        AccountTransaction =36,
        AccountHistory = 37,
        StockCardList=38,
        CashandBankStatement = 39,
        GstVatSummary = 40,
        LedgerList = 41
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
        Adjusted = 1,
        UnAdjusted = 2,
        Refunded = 3
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
        RefundToCustomer = 6,
        PayMoney=7,
        ReceiveMoney=8,
        TransferMoney=9
    }

    public enum PO_Status
    {
        Collected = 1,
        Refunded = 2,
        unDeposited = 3,
        Cancelled = 4
    }

    public enum Stock_Type
    {
        IncreaseDecreaseStock = 1,
        StockDamaged = 2,
        StockTake = 3
    }

    public enum Account_Type
    {
        Cash = 1,
        Bank = 1,
        CurrentAssets =2,
        FixedAssets=3,
        CurrentLiabilities=4,
        LongTermLiabilities=5,
        Capital=6,
        Income=7,
        Costs=8,
        Expenses=9,
        CreditCard=24    
    }
    public enum Account_TypeCode
    {
        NetGst=9,
        UserCreatedAsset=18,
            UserCreatedLiabilities=19,
            UserCreatedIncome=21,
            User​Created​​Cost=22,
        User​Created​​Expenses=23
    }
    public enum Print_Type
    {
        SQP = 1,
        SOP = 2,
        SIP = 3,
        CNP = 4,
        RFQP = 5,
        POP = 6,
        DNP = 7,
        DOP = 8,
        USIP = 9,
        SICNPP = 10,
        PIDNP = 11
    }
   
}