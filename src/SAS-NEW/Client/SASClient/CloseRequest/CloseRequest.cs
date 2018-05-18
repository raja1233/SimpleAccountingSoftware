﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using SASClient.Accounts.Views;
using SASClient.CashBank.Views;
using SASClient.Customers.Views;
using SASClient.File.Views;
using SASClient.HomeScreen.Views;
using SASClient.Product.View;
using SASClient.Purchasing.View;
using SDN.CashBank.ViewModels;
using SDN.CashBank.Views;
using SDN.Common;
using SDN.Customers.Views;
using SDN.Product.View;
using SDN.Purchasing.View;
using SDN.Sales.Views;
using SDN.Settings.Views;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.CloseRequest
{
    public class CloseView :ViewModelBase
    {
        //public CloseRequestNew()
        //{
        //}
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        public CloseView(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
        }

        //private bool? _CashBankStatementTabTrue;

        //public bool? CashBankStatementTabTrue
        //{
        //    get
        //    {
        //        return _CashBankStatementTabTrue;
        //    }
        //    set
        //    {
        //        _CashBankStatementTabTrue = value;
        //        OnPropertyChanged("CashBankStatementTabTrue");
        //    }
        //}



        public void CloseViewRequest(string Filename,bool IsClose)
        {
            //var mainregion = 0;
            
            //CashAndBankTabViewModel obj = new CashAndBankTabViewModel(regionManager, eventAggregator);
            try
            {
                if (!string.IsNullOrEmpty(Filename))
                {
                    
                    switch (Filename)
                    {

                        case "MainView":
                            //var view = ServiceLocator.Current.GetInstance<MainView>();
                            IEnumerable<object> h = this.regionManager.Regions[RegionNames.MainRegion].Views;
                            var l = h.ElementAt(3);
                            //var o = l.GetType().Name;
                            IRegion regiona = this.regionManager.Regions[RegionNames.MainRegion];
                            //regiona.Add(l);
                            if (regiona != null)
                            {
                                regiona.Activate(l);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Home");
                            break;

                        case "Cash & Bank Statement":
                            SharedValues.getValue = "CashBankStatementTab";
                            var tabview = ServiceLocator.Current.GetInstance<CashBankTabView>();
                            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion.Add(tabview);
                            if (tabregion != null)
                            {
                                tabregion.Activate(tabview);
                            }
                            var mainview = ServiceLocator.Current.GetInstance<CashBankStatement>();
                            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion.Add(mainview);
                            if (mainregion != null)
                            {
                                mainregion.Activate(mainview);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Cash & Bank Statement");
             
                            break;

                        case "Pay Money List":
                            //SharedValues.NewClick = "New";
                            SharedValues.getValue = "PayMoneyTab";
                            var tabview1 = ServiceLocator.Current.GetInstance<CashBankTabView>();

                            var tabregion1 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion1.Add(tabview1);
                            if (tabregion1 != null)
                            {
                                tabregion1.Activate(tabview1);
                            }

                            var view1 = ServiceLocator.Current.GetInstance<PayMoneyListView>();
                            var region1 = this.regionManager.Regions[RegionNames.MainRegion];
                            //var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
                            region1.Add(view1);
                            if (region1 != null)
                            {
                                region1.Activate(view1);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);

                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Pay Money List");
                            break;

                        case "Pay Money":
                            SharedValues.getValue = "PayMoneyTab";
                            //SharedValues.NewClick = "New";

                            var tabview2 = ServiceLocator.Current.GetInstance<CashBankTabView>();

                            var tabregion2 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion2.Add(tabview2);
                            if (tabregion2 != null)
                            {
                                tabregion2.Activate(tabview2);
                            }

                            var view2 = ServiceLocator.Current.GetInstance<PayMoneyView>();

                            var region2 = this.regionManager.Regions[RegionNames.MainRegion];
                            region2.Add(view2);
                            if (region2 != null)
                            {
                                region2.Activate(view2);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Pay Money");
                            break;

                        case "Receive Money List":
                            SharedValues.getValue = "ReceiveMoneyTab";
                            var tabview3 = ServiceLocator.Current.GetInstance<CashBankTabView>();

                            var tabregion3 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion3.Add(tabview3);
                            if (tabregion3 != null)
                            {
                                tabregion3.Activate(tabview3);
                            }

                            var view3 = ServiceLocator.Current.GetInstance<ReceiveMoneyListView>();
                            var region3 = this.regionManager.Regions[RegionNames.MainRegion];
                            region3.Add(view3);
                            if (region3 != null)
                            {
                                region3.Activate(view3);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);

                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Receive Money List");
                            break;
                        case "Receive Money":

                            SharedValues.getValue = "ReceiveMoneyTab";
                            var tabview4 = ServiceLocator.Current.GetInstance<CashBankTabView>();

                            var tabregion4 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion4.Add(tabview4);
                            if (tabregion4 != null)
                            {
                                tabregion4.Activate(tabview4);
                            }

                            var view4 = ServiceLocator.Current.GetInstance<ReceiveMoneyView>();

                            var region4 = this.regionManager.Regions[RegionNames.MainRegion];
                            region4.Add(view4);
                            if (region4 != null)
                            {
                                region4.Activate(view4);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);

                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Receive Money Form");
                            break;

                        case "Refund To Customer":
                            SharedValues.getValue = "RefundToCustomerTab";

                            var tabview5 = ServiceLocator.Current.GetInstance<CashBankTabView>();

                            var tabregion5 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion5.Add(tabview5);
                            if (tabregion5 != null)
                            {
                                tabregion5.Activate(tabview5);
                            }

                            var view5 = ServiceLocator.Current.GetInstance<RefundToCustomerView>();
                            var region5 = this.regionManager.Regions[RegionNames.MainRegion];
                            region5.Add(view5);
                            if (region5 != null)
                            {
                                region5.Activate(view5);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund To Customer Form");
                            break;
                        case "Refund To Customers List":
                            SharedValues.getValue = "RefundToCustomerTab";

                            var tabview6 = ServiceLocator.Current.GetInstance<CashBankTabView>();

                            var tabregion6 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion6.Add(tabview6);
                            if (tabregion6 != null)
                            {
                                tabregion6.Activate(tabview6);
                            }
                            var view6 = ServiceLocator.Current.GetInstance<RefundToCustomersListView>();
                            var region6 = this.regionManager.Regions[RegionNames.MainRegion];
                            region6.Add(view6);

                            if (region6 != null)
                            {
                                region6.Activate(view6);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund To Customers List");
                            break;
                        case "Refund From Supplier":
                            SharedValues.getValue = "RefundFromSupplierTab";

                            var tabview7 = ServiceLocator.Current.GetInstance<CashBankTabView>();

                            var tabregion7 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion7.Add(tabview7);
                            if (tabregion7 != null)
                            {
                                tabregion7.Activate(tabview7);
                            }

                            var view7 = ServiceLocator.Current.GetInstance<RefundFromSupplierView>();
                            var region7 = this.regionManager.Regions[RegionNames.MainRegion];
                            region7.Add(view7);
                            if (region7 != null)
                            {
                                region7.Activate(view7);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund From Supplier Form");
                            break;
                        case "Refund to Supplier List":
                            SharedValues.getValue = "RefundFromSupplierTab";

                            var tabview8 = ServiceLocator.Current.GetInstance<CashBankTabView>();

                            var tabregion8 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion8.Add(tabview8);
                            if (tabregion8 != null)
                            {
                                tabregion8.Activate(tabview8);
                            }

                            var view8 = ServiceLocator.Current.GetInstance<RefundFromSuppliersListView>();
                            var region8 = this.regionManager.Regions[RegionNames.MainRegion];
                            region8.Add(view8);
                            if (region8 != null)
                            {
                                region8.Activate(view8);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund From Suppliers List");
                            break;

                        case "Transfer Money List":
                            SharedValues.getValue = "TransferMoneyTab";
                            var tabview10 = ServiceLocator.Current.GetInstance<CashBankTabView>();

                            var tabregion10 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion10.Add(tabview10);
                            if (tabregion10 != null)
                            {
                                tabregion10.Activate(tabview10);
                            }
                            var view10 = ServiceLocator.Current.GetInstance<TransferMoneyListView>();
                            var region10 = this.regionManager.Regions[RegionNames.MainRegion];
                            region10.Add(view10);
                            if (region10 != null)
                            {
                                region10.Activate(view10);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Transfer Money List");
                            break;

                        case "Transfer Money":

                            SharedValues.getValue = "TransferMoneyTab";
                            var tabview11 = ServiceLocator.Current.GetInstance<CashBankTabView>();

                            var tabregion11 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion11.Add(tabview11);
                            if (tabregion11 != null)
                            {
                                tabregion11.Activate(tabview11);
                            }

                            var view11 = ServiceLocator.Current.GetInstance<TransferMoneyView>();

                            var region11 = this.regionManager.Regions[RegionNames.MainRegion];
                            region11.Add(view11);
                            if (region11 != null)
                            {
                                region11.Activate(view11);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);

                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Transfer Money Form");
                            break;
                        case "Sales Quotation List":
                            SharedValues.getValue = "SalesQuotationTab";
                            var tabview12 = ServiceLocator.Current.GetInstance<SalesTabView>();

                            var tabregion12 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion12.Add(tabview12);
                            if (tabregion12 != null)
                            {
                                tabregion12.Activate(tabview12);
                            }

                            var view12 = ServiceLocator.Current.GetInstance<SalesQuotationListView>();

                            var region12 = this.regionManager.Regions[RegionNames.MainRegion];
                            region12.Add(view12);
                            if (region12 != null)
                            {
                                region12.Activate(view12);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Quotations List");
                            break;
                        case "Sales Order List":
                            SharedValues.getValue = "SalesOrderTab";
                            var tabview13 = ServiceLocator.Current.GetInstance<SalesTabView>();

                            var tabregion13 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion13.Add(tabview13);
                            if (tabregion13 != null)
                            {
                                tabregion13.Activate(tabview13);
                            }

                            var mainview13 = ServiceLocator.Current.GetInstance<SalesOrderListView>();

                            var mainregion13 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion13.Add(mainview13);
                            if (mainregion13 != null)
                            {
                                mainregion13.Activate(mainview13);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Orders List");
                            break;
                        case "Sales Invoice List":
                            SharedValues.getValue = "SalesInvoiceTab";
                            var tabview14 = ServiceLocator.Current.GetInstance<SalesTabView>();

                            var tabregion14 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion14.Add(tabview14);
                            if (tabregion14 != null)
                            {
                                tabregion14.Activate(tabview14);
                            }

                            var mainview14 = ServiceLocator.Current.GetInstance<SalesInvoiceListView>();

                            var mainregion14 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion14.Add(mainview14);
                            if (mainregion14 != null)
                            {
                                mainregion14.Activate(mainview14);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Invoices List");
                            break;
                        case "Credit Note List":
                            SharedValues.getValue = "CreditNoteTab";
                            var tabview15 = ServiceLocator.Current.GetInstance<SalesTabView>();

                            var tabregion15 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion15.Add(tabview15);
                            if (tabregion15 != null)
                            {
                                tabregion15.Activate(tabview15);
                            }

                            var mainview15 = ServiceLocator.Current.GetInstance<CreditNoteListView>();

                            var mainregion15 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion15.Add(mainview15);
                            if (mainregion15 != null)
                            {
                                mainregion15.Activate(mainview15);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Credit Notes List");
                            break;
                        case "Payment From Customers List":
                            SharedValues.getValue = "PaymentFromCustomerTab";
                            var tabview16 = ServiceLocator.Current.GetInstance<SalesTabView>();

                            var tabregion16 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion16.Add(tabview16);
                            if (tabregion16 != null)
                            {
                                tabregion16.Activate(tabview16);
                            }

                            var mainview16 = ServiceLocator.Current.GetInstance<PaymentFromCustomersListView>();

                            var mainregion16 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion16.Add(mainview16);
                            if (mainregion16 != null)
                            {
                                mainregion16.Activate(mainview16);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Payments From Customers List");
                            break;
                        case "Sales Quotation":
                            SharedValues.getValue = "SalesQuotationTab";
                            var tabview17 = ServiceLocator.Current.GetInstance<SalesTabView>();

                            var tabregion17 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion17.Add(tabview17);
                            if (tabregion17 != null)
                            {
                                tabregion17.Activate(tabview17);
                            }

                            var mainview17 = ServiceLocator.Current.GetInstance<SalesQuotationView>();

                            var mainregion17 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion17.Add(mainview17);
                            if (mainregion17 != null)
                            {
                                mainregion17.Activate(mainview17);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Quotation Form");
                            break;
                        case "Sales Order":
                            SharedValues.getValue = "SalesOrderTab";
                            var tabview18 = ServiceLocator.Current.GetInstance<SalesTabView>();

                            var tabregion18 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion18.Add(tabview18);
                            if (tabregion18 != null)
                            {
                                tabregion18.Activate(tabview18);
                            }

                            var mainview18 = ServiceLocator.Current.GetInstance<SalesOrderView>();

                            var mainregion18 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion18.Add(mainview18);
                            if (mainregion18 != null)
                            {
                                mainregion18.Activate(mainview18);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Order Form");
                            break;
                        case "Sales Invoice":
                            SharedValues.getValue = "SalesInvoiceTab";
                            var tabview19 = ServiceLocator.Current.GetInstance<SalesTabView>();

                            var tabregion19 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion19.Add(tabview19);
                            if (tabregion19 != null)
                            {
                                tabregion19.Activate(tabview19);
                            }

                            var mainview19 = ServiceLocator.Current.GetInstance<SalesInvoiceView>();

                            var mainregion19 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion19.Add(mainview19);
                            if (mainregion19 != null)
                            {
                                mainregion19.Activate(mainview19);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Sales Invoice Form");
                            break;
                        case "Credit Note":
                            SharedValues.getValue = "CreditNoteTab";
                            var tabview20 = ServiceLocator.Current.GetInstance<SalesTabView>();

                            var tabregion20 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion20.Add(tabview20);
                            if (tabregion20 != null)
                            {
                                tabregion20.Activate(tabview20);
                            }

                            var mainview20 = ServiceLocator.Current.GetInstance<CreditNoteView>();

                            var mainregion20 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion20.Add(mainview20);
                            if (mainregion20 != null)
                            {
                                mainregion20.Activate(mainview20);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Credit Note Form");
                            break;
                        case "Payment from Customer":
                            SharedValues.getValue = "PaymentFromCustomerTab";
                            var tabview21 = ServiceLocator.Current.GetInstance<SalesTabView>();

                            var tabregion21 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion21.Add(tabview21);
                            if (tabregion21 != null)
                            {
                                tabregion21.Activate(tabview21);
                            }

                            var mainview21 = ServiceLocator.Current.GetInstance<PaymentFromCustomersView>();

                            var mainregion21 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion21.Add(mainview21);
                            if (mainregion21 != null)
                            {
                                mainregion21.Activate(mainview21);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Payment From Customer Form");
                            break;
                        case "Purchase Quotation":
                           
                            SharedValues.getValue = "PurchaseQuotationTab";
                            var tabview22 = ServiceLocator.Current.GetInstance<PurchaseTabView>();

                            var tabregion22 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion22.Add(tabview22);
                            if (tabregion22 != null)
                            {
                                tabregion22.Activate(tabview22);
                            }

                            var mainview22 = ServiceLocator.Current.GetInstance<PurchaseQuotationView>();

                            //PurchaseTabEntity tabentity = new PurchaseTabEntity();
                            //var tabentityValue = tabentity as PurchaseTabEntity;
                            //tabentityValue.QuotationTabTrue = true;


                            var mainregion22 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion22.Add(mainview22);
                            if (mainregion22 != null)
                            {
                                mainregion22.Activate(mainview22);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Quotation Form");
                            break;
                        case "Purchase Quotation List":
                            SharedValues.getValue = "PurchaseQuotationTab";
                            var tabview23 = ServiceLocator.Current.GetInstance<PurchaseTabView>();

                            var tabregion23 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion23.Add(tabview23);
                            if (tabregion23 != null)
                            {
                                tabregion23.Activate(tabview23);
                            }

                            var mainview23 = ServiceLocator.Current.GetInstance<PurchaseQuotationListView>();

                            var mainregion23 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion23.Add(mainview23);
                            if (mainregion23 != null)
                            {
                                mainregion23.Activate(mainview23);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Quotations List");
                            break;
                        case "Purchase Order List":
                            SharedValues.getValue = "PurchaseOrderTab";
                            var tabview24 = ServiceLocator.Current.GetInstance<PurchaseTabView>();

                            var tabregion24 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion24.Add(tabview24);
                            if (tabregion24 != null)
                            {
                                tabregion24.Activate(tabview24);
                            }
                            //PurchaseTabEntity tabentity = new PurchaseTabEntity();
                            //var tabentityValue = tabentity as PurchaseTabEntity;
                            //tabentityValue.OrderTabTrue = true;

                            var mainview24 = ServiceLocator.Current.GetInstance<PurchaseOrderListView>();

                            var mainregion24 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion24.Add(mainview24);
                            if (mainregion24 != null)
                            {
                                mainregion24.Activate(mainview24);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Orders List");
                            break;
                        case "Purchase Order":
                         
                            SharedValues.getValue = "PurchaseOrderTab";
                            var tabview25 = ServiceLocator.Current.GetInstance<PurchaseTabView>();

                            var tabregion25 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion25.Add(tabview25);
                            if (tabregion25 != null)
                            {
                                tabregion25.Activate(tabview25);
                            }
                            //PurchaseTabEntity tabentity = new PurchaseTabEntity();
                            //var tabentityValue = tabentity as PurchaseTabEntity;
                            //tabentityValue.OrderTabTrue = true;

                            var mainview25 = ServiceLocator.Current.GetInstance<PurchaseOrderView>();

                            var mainregion25 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion25.Add(mainview25);
                            if (mainregion25 != null)
                            {
                                mainregion25.Activate(mainview25);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Order Form");
                            break;
                        case "Purchase Invoice (Products & Services) List":
                            SharedValues.getValue = "PurchaseInvoiceTab";
                            var tabview26 = ServiceLocator.Current.GetInstance<PurchaseTabView>();

                            var tabregion26 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion26.Add(tabview26);
                            if (tabregion26 != null)
                            {
                                tabregion26.Activate(tabview26);
                            }
                            //PurchaseTabEntity tabentity = new PurchaseTabEntity();
                            //var tabentityValue = tabentity as PurchaseTabEntity;
                            //tabentityValue.OrderTabTrue = true;

                            var mainview26 = ServiceLocator.Current.GetInstance<PurchaseInvoiceListView>();

                            var mainregion26 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion26.Add(mainview26);
                            if (mainregion26 != null)
                            {
                                mainregion26.Activate(mainview26);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Invoices List");
                            break;
                        case "Purchase Invoice (Products & Services)":
                            
                            SharedValues.getValue = "PurchaseInvoiceTab";
                            var tabview27 = ServiceLocator.Current.GetInstance<PurchaseTabView>();

                            var tabregion27 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion27.Add(tabview27);
                            if (tabregion27 != null)
                            {
                                tabregion27.Activate(tabview27);
                            }
                            //PurchaseTabEntity tabentity = new PurchaseTabEntity();
                            //var tabentityValue = tabentity as PurchaseTabEntity;
                            //tabentityValue.OrderTabTrue = true;

                            var mainview27 = ServiceLocator.Current.GetInstance<PurchaseInvoicePandSView>();

                            var mainregion27 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion27.Add(mainview27);
                            if (mainregion27 != null)
                            {
                                mainregion27.Activate(mainview27);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Purchase Invoice Form (Products & Services)");
                            break;
                        case "Debit Note List":
                            SharedValues.getValue = "DebitNoteTab";
                            var tabview28 = ServiceLocator.Current.GetInstance<PurchaseTabView>();

                            var tabregion28 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion28.Add(tabview28);
                            if (tabregion28 != null)
                            {
                                tabregion28.Activate(tabview28);
                            }
                            PurchaseTabEntity tabentity = new PurchaseTabEntity();
                            var tabentityValue = tabentity as PurchaseTabEntity;
                            tabentityValue.OrderTabTrue = true;

                            var mainview28 = ServiceLocator.Current.GetInstance<DebitNoteListView>();

                            var mainregion28 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion28.Add(mainview28);
                            if (mainregion28 != null)
                            {
                                mainregion28.Activate(mainview28);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Debit Notes List");
                            break;
                        case "Debit Note":
                            
                            SharedValues.getValue = "DebitNoteTab";
                            var tabview29 = ServiceLocator.Current.GetInstance<PurchaseTabView>();

                            var tabregion29 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion29.Add(tabview29);
                            if (tabregion29 != null)
                            {
                                tabregion29.Activate(tabview29);
                            }
                            PurchaseTabEntity tabentity2 = new PurchaseTabEntity();
                            var tabentityValue2 = tabentity2 as PurchaseTabEntity;
                            tabentityValue2.OrderTabTrue = true;

                            var mainview29 = ServiceLocator.Current.GetInstance<DebitNoteView>();

                            var mainregion29 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion29.Add(mainview29);
                            if (mainregion29 != null)
                            {
                                mainregion29.Activate(mainview29);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Debit Note Form");
                            break;
                        case "Payments To Suppliers List":
                            SharedValues.getValue = "PaymentToSupplierTab";
                            var tabview30 = ServiceLocator.Current.GetInstance<PurchaseTabView>();

                            var tabregion30 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion30.Add(tabview30);
                            if (tabregion30 != null)
                            {
                                tabregion30.Activate(tabview30);
                            }
                            PurchaseTabEntity tabentity3 = new PurchaseTabEntity();
                            var tabentityValue3 = tabentity3 as PurchaseTabEntity;
                            tabentityValue3.OrderTabTrue = true;

                            var mainview30 = ServiceLocator.Current.GetInstance<PaymentsToSuppliersListView>();

                            var mainregion30 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion30.Add(mainview30);
                            if (mainregion30 != null)
                            {
                                mainregion30.Activate(mainview30);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Payments to Suppliers List");
                            break;
                        case "Payment to Supplier":
                            
                            SharedValues.getValue = "PaymentToSupplierTab";
                            var tabview31 = ServiceLocator.Current.GetInstance<PurchaseTabView>();

                            var tabregion31 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion31.Add(tabview31);
                            if (tabregion31 != null)
                            {
                                tabregion31.Activate(tabview31);
                            }
                            PurchaseTabEntity tabentity4 = new PurchaseTabEntity();
                            var tabentityValue4 = tabentity4 as PurchaseTabEntity;
                            tabentityValue4.OrderTabTrue = true;

                            var mainview31 = ServiceLocator.Current.GetInstance<PaymentToSupplierView>();

                            var mainregion31 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion31.Add(mainview31);
                            if (mainregion31 != null)
                            {
                                mainregion31.Activate(mainview31);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Payment to Supplier Form");
                            break;
                        case "Products & Services Details":
                            SharedValues.getValue = "PSDetailsTab";
                            var tabview32 = ServiceLocator.Current.GetInstance<PandSDetailsView>();

                            var tabregion32 = this.regionManager.Regions[RegionNames.MainRegion];
                            tabregion32.Add(tabview32);
                            if (tabregion32 != null)
                            {
                                tabregion32.Activate(tabview32);
                            }

                            var view32 = ServiceLocator.Current.GetInstance<ProductTabView>();

                            IRegion region32 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            region32.Add(view32);
                            if (region32 != null)
                            {
                                region32.Activate(view32);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products & Services Details Form");
                            break;
                        case "P&S Details (Description) List":
                            
                            var tabview33 = ServiceLocator.Current.GetInstance<PandSDescriptionListView>();
                            var tabregion33 = this.regionManager.Regions[RegionNames.MainRegion];
                            tabregion33.Add(tabview33);
                            if (tabregion33 != null)
                            {
                                tabregion33.Activate(tabview33);
                            }
                            SharedValues.getValue = "PSDetailsTab";
                            var view33 = ServiceLocator.Current.GetInstance<ProductTabView>();

                            IRegion region33 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            region33.Add(view33);
                            if (region33 != null)
                            {
                                region33.Activate(view33);
                            }


                            var SubTabView = ServiceLocator.Current.GetInstance<PandSSubTabView>();
                            var subMenuRegion = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion.Add(SubTabView);

                            if (subMenuRegion != null)
                            {
                                subMenuRegion.Activate(SubTabView);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Prodcts and Services Details List - Description");
                            break;
                        case "P&S History":
                            SharedValues.getValue = "PSHistoryTab";
                            var tabview34 = ServiceLocator.Current.GetInstance<PandSHistoryView>();

                            var tabregion34 = this.regionManager.Regions[RegionNames.MainRegion];
                            tabregion34.Add(tabview34);
                            if (tabregion34 != null)
                            {
                                tabregion34.Activate(tabview34);
                            }

                            var view34 = ServiceLocator.Current.GetInstance<ProductTabView>();

                            IRegion region34 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            region34.Add(view34);
                            if (region34 != null)
                            {
                                region34.Activate(view34);
                            }


                            var SubTabView1 = ServiceLocator.Current.GetInstance<PandSSubTabView>();
                            var subMenuRegion1 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion1.Add(SubTabView1);

                            if (subMenuRegion1 != null)
                            {
                                subMenuRegion1.Activate(SubTabView1);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products & Services History");
                            break;
                        case "Stock in/out card":
                            SharedValues.getValue = "StockInOutCardTab";

                            var tabview35 = ServiceLocator.Current.GetInstance<ProductTabView>();

                            var tabregion35 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion35.Add(tabview35);
                            if (tabregion35 != null)
                            {
                                tabregion35.Activate(tabview35);
                            }

                            var mainview35 = ServiceLocator.Current.GetInstance<PandSStockCardView>();

                            var mainregion35 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion35.Add(mainview35);
                            if (mainregion35 != null)
                            {
                                mainregion35.Activate(mainview35);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Stock In/Out Card");
                            break;
                        case "Count & Adjust Stock":
                            SharedValues.getValue = "CountandAdjustStockTab";
                            var tabview36 = ServiceLocator.Current.GetInstance<CountAndAdjustStockView>();

                            var tabregion36 = this.regionManager.Regions[RegionNames.MainRegion];
                            tabregion36.Add(tabview36);
                            if (tabregion36 != null)
                            {
                                tabregion36.Activate(tabview36);
                            }

                            var view36 = ServiceLocator.Current.GetInstance<ProductTabView>();

                            IRegion region36 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            region36.Add(view36);
                            if (region36 != null)
                            {
                                region36.Activate(view36);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            //  eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Count and Adjust Stock Form");
                            break;
                        case "Count And Adjust Stock List":
                            SharedValues.getValue = "CountandAdjustStockTab";
                            var tabview37 = ServiceLocator.Current.GetInstance<CountAndAdjustStockListView>();

                            var tabregion37 = this.regionManager.Regions[RegionNames.MainRegion];
                            tabregion37.Add(tabview37);
                            if (tabregion37 != null)
                            {
                                tabregion37.Activate(tabview37);
                            }

                            var view37 = ServiceLocator.Current.GetInstance<ProductTabView>();

                            IRegion region37 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            region37.Add(view37);
                            if (region37 != null)
                            {
                                region37.Activate(view37);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            // eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Count and Adjust Stock List");
                            break;
                        case "P & S Sold":
                            SharedValues.getValue = "PSSoldTab";
                            var tabview38 = ServiceLocator.Current.GetInstance<PandSSoldView>();

                            var tabregion38 = this.regionManager.Regions[RegionNames.MainRegion];
                            tabregion38.Add(tabview38);
                            if (tabregion38 != null)
                            {
                                tabregion38.Activate(tabview38);
                            }

                            var view38 = ServiceLocator.Current.GetInstance<ProductTabView>();

                            IRegion region38 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            region38.Add(view38);
                            if (region38 != null)
                            {
                                region38.Activate(view38);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Sold");
                            break;
                        case "P & S Purchased":
                            SharedValues.getValue = "PSPurchasedTab";
                            var tabview39 = ServiceLocator.Current.GetInstance<PandSPurchaseView>();

                            var tabregion39 = this.regionManager.Regions[RegionNames.MainRegion];
                            tabregion39.Add(tabview39);
                            if (tabregion39 != null)
                            {
                                tabregion39.Activate(tabview39);
                            }

                            var view39 = ServiceLocator.Current.GetInstance<ProductTabView>();

                            IRegion region39 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            region39.Add(view39);
                            if (region39 != null)
                            {
                                region39.Activate(view39);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Purchased");
                            break;
                        case "Top Products & Services":
                            SharedValues.getValue = "TopPSTab";
                            var tabview40 = ServiceLocator.Current.GetInstance<TopPandSView>();

                            var tabregion40 = this.regionManager.Regions[RegionNames.MainRegion];
                            tabregion40.Add(tabview40);
                            if (tabregion40 != null)
                            {
                                tabregion40.Activate(tabview40);
                            }

                            var view40 = ServiceLocator.Current.GetInstance<ProductTabView>();

                            IRegion region40 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            region40.Add(view40);
                            if (region40 != null)
                            {
                                region40.Activate(view40);
                            }


                            var SubTabView2 = ServiceLocator.Current.GetInstance<PandSSubTabView>();
                            var subMenuRegion2 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion2.Add(SubTabView2);

                            if (subMenuRegion2 != null)
                            {
                                subMenuRegion2.Activate(SubTabView2);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Top Products & Services");
                            break;
                        case "P & S Sell Price List":                     
                            var view41 = ServiceLocator.Current.GetInstance<PandSSellPriceListView>();
                            var region41 = this.regionManager.Regions[RegionNames.MainRegion];
                            region41.Add(view41);
                            if (region41 != null)
                            {
                                region41.Activate(view41);
                            }
                            SharedValues.getValue = "PSDetailsTab";
                            var tabview41 = ServiceLocator.Current.GetInstance<ProductTabView>();

                            IRegion tabregion41 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion41.Add(tabview41);
                            if (tabregion41 != null)
                            {
                                tabregion41.Activate(tabview41);
                            }

                            SharedValues.getValue = "PandSSellPricesTabTrue";
                            var SubTabView41 = ServiceLocator.Current.GetInstance<PandSSubTabView>();
                            var subMenuRegion41 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion41.Add(SubTabView41);

                            if (subMenuRegion41 != null)
                            {
                                subMenuRegion41.Activate(SubTabView41);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Details List - Sell Prices");
                           
                            break;
                        case "P & S Cost Price List":
                            var view42 = ServiceLocator.Current.GetInstance<PandSCostPriceListView>();
                            var region42 = this.regionManager.Regions[RegionNames.MainRegion];
                            region42.Add(view42);
                            if (region42 != null)
                            {
                                region42.Activate(view42);
                            }
                            SharedValues.getValue = "PSDetailsTab";
                            var tabview42 = ServiceLocator.Current.GetInstance<ProductTabView>();

                            IRegion tabregion42 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion42.Add(tabview42);
                            if (tabregion42 != null)
                            {
                                tabregion42.Activate(tabview42);
                            }

                            SharedValues.getValue = "PandSCostPriceTabTrue";
                            var SubTabView42 = ServiceLocator.Current.GetInstance<PandSSubTabView>();
                            var subMenuRegion42 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion42.Add(SubTabView42);

                            if (subMenuRegion42 != null)
                            {
                                subMenuRegion42.Activate(SubTabView42);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Details List - Cost Prices");
                            break;
                        case "P & S Stock Quantities List":
                            var view43 = ServiceLocator.Current.GetInstance<PandSStockQuantitiesListView>();

                            var region43 = this.regionManager.Regions[RegionNames.MainRegion];
                            region43.Add(view43);
                            if (region43 != null)
                            {
                                region43.Activate(view43);
                            }
                            SharedValues.getValue = "PSDetailsTab";
                            var tabview43 = ServiceLocator.Current.GetInstance<ProductTabView>();

                            IRegion tabregion43 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion43.Add(tabview43);
                            if (tabregion43 != null)
                            {
                                tabregion43.Activate(tabview43);
                            }

                            SharedValues.getValue = "PandSStockQuantitiesTabTrue";
                            var SubTabView43 = ServiceLocator.Current.GetInstance<PandSSubTabView>();
                            var subMenuRegion43 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion43.Add(SubTabView43);

                            if (subMenuRegion43 != null)
                            {
                                subMenuRegion43.Activate(SubTabView43);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Details List - Stock Quantities");
                            break;
                        case "P & S Codes and Rates List":
                            var view44 = ServiceLocator.Current.GetInstance<PandSCodesAndRatesListView>();
                            var region44 = this.regionManager.Regions[RegionNames.MainRegion];
                            region44.Add(view44);
                            if (region44 != null)
                            {
                                region44.Activate(view44);
                            }
                            SharedValues.getValue = "PSDetailsTab";
                            var tabview44 = ServiceLocator.Current.GetInstance<ProductTabView>();

                            IRegion tabregion44 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion44.Add(tabview44);
                            if (tabregion44 != null)
                            {
                                tabregion44.Activate(tabview44);
                            }

                            SharedValues.getValue = "PandSCodesAndRatesTabTrue";
                            var SubTabView44 = ServiceLocator.Current.GetInstance<PandSSubTabView>();
                            var subMenuRegion44 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion44.Add(SubTabView44);

                            if (subMenuRegion44 != null)
                            {
                                subMenuRegion44.Activate(SubTabView44);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Details List - GST Codes and Rates");
                            break;
                        case "Stock Value List":
                            var view45 = ServiceLocator.Current.GetInstance<PandSStockValueListView>();
                            var region45 = this.regionManager.Regions[RegionNames.MainRegion];
                            region45.Add(view45);
                            if (region45 != null)
                            {
                                region45.Activate(view45);
                            }
                            SharedValues.getValue = "PSDetailsTab";
                            var tabview45 = ServiceLocator.Current.GetInstance<ProductTabView>();

                            IRegion tabregion45 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion45.Add(tabview45);
                            if (tabregion45 != null)
                            {
                                tabregion45.Activate(tabview45);
                            }

                            SharedValues.getValue = "PandSStockValueTabTrue";
                            var SubTabView45 = ServiceLocator.Current.GetInstance<PandSSubTabView>();
                            var subMenuRegion45 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion45.Add(SubTabView45);

                            if (subMenuRegion45 != null)
                            {
                                subMenuRegion45.Activate(SubTabView45);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Details List - Stock Value");
                            break;
                        case "Suppliers Details":
                            SharedValues.getValue = "SupplierDetailTab";
                            var mainview46 = ServiceLocator.Current.GetInstance<SupplierDetailView>();
                            var mainregion46 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion46.Add(mainview46);
                            if (mainregion46 != null)
                            {
                                mainregion46.Activate(mainview46);
                            }


                            var tabview46 = ServiceLocator.Current.GetInstance<SupplierTabView>();
                            var tabregion46 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion46.Add(tabview46);
                            if (tabregion46 != null)
                            {
                                tabregion46.Activate(tabview46);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details Form");
                            break;
                        case "Suppliers Details List":

                           
                            var view47 = ServiceLocator.Current.GetInstance<SuppliersDetailsList1View>();
                            var region47 = this.regionManager.Regions[RegionNames.MainRegion];
                            region47.Add(view47);
                            if (region47 != null)
                            {
                                region47.Activate(view47);
                            }
                            SharedValues.getValue = "SupplierDetailTab";
                            var tabview47 = ServiceLocator.Current.GetInstance<SupplierTabView>();

                            IRegion tabregion47 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion47.Add(tabview47);
                            if (tabregion47 != null)
                            {
                                tabregion47.Activate(tabview47);
                            }
                            SharedValues.getValue = "SupplierDetailList1";
                            var SubTabView47 = ServiceLocator.Current.GetInstance<SuppliersDetailsSubTabView>();
                            var subMenuRegion47 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion47.Add(SubTabView47);

                            if (subMenuRegion47 != null)
                            {
                                subMenuRegion47.Activate(SubTabView47);
                            }


                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details List");
                            break;
                        case "Suppliers History":
                            SharedValues.getValue = "SupplierHistoryTab";
                            var mainview48 = ServiceLocator.Current.GetInstance<SupplierHistoryView>();
                            var mainregion48 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion48.Add(mainview48);
                            if (mainregion48 != null)
                            {
                                mainregion48.Activate(mainview48);
                            }


                            var tabview48 = ServiceLocator.Current.GetInstance<SupplierTabView>();
                            var tabregion48 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion48.Add(tabview48);
                            if (tabregion48 != null)
                            {
                                tabregion48.Activate(tabview48);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers History");
                            break;
                        case "Top Suppliers":
                            SharedValues.getValue = "TopSuppliersTab";
                            var mainview49 = ServiceLocator.Current.GetInstance<TopSuppliersView>();
                            var mainregion49 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion49.Add(mainview49);
                            if (mainregion49 != null)
                            {
                                mainregion49.Activate(mainview49);
                            }


                            var tabview49 = ServiceLocator.Current.GetInstance<SupplierTabView>();
                            var tabregion49 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion49.Add(tabview49);
                            if (tabregion49 != null)
                            {
                                tabregion49.Activate(tabview49);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Top Suppliers");
                            break;
                        case "Suppliers UnPaid Invoices":
                     

                            var view50 = ServiceLocator.Current.GetInstance<SuppliersUnPaidInvoicesView>();
                            var region50 = this.regionManager.Regions[RegionNames.MainRegion];
                            region50.Add(view50);
                            if (region50 != null)
                            {
                                region50.Activate(view50);
                            }
                            SharedValues.getValue = "SupplierStatementTab";
                            var tabview50 = ServiceLocator.Current.GetInstance<SupplierTabView>();

                            IRegion tabregion50 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion50.Add(tabview50);
                            if (tabregion50 != null)
                            {
                                tabregion50.Activate(tabview50);
                            }
                            SharedValues.getValue = "UnpaidInvoicesTab";
                            var SubTabView50 = ServiceLocator.Current.GetInstance<SASClient.Purchasing.View.StatementSubTabView>();
                            var subMenuRegion50 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion50.Add(SubTabView50);

                            if (subMenuRegion50 != null)
                            {
                                subMenuRegion50.Activate(SubTabView50);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Supliers Statement");
                            break;
                        case "Products and Services Purchased From Supplier":
                            SharedValues.getValue = "PandSPurchasedFromSupplier";
                            var tabview51 = ServiceLocator.Current.GetInstance<SupplierTabView>();

                            var tabregion51 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion51.Add(tabview51);
                            if (tabregion51 != null)
                            {
                                tabregion51.Activate(tabview51);
                            }

                            var mainview51 = ServiceLocator.Current.GetInstance<PandSPurchasedFromSuppliersView>();

                            var mainregion51 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion51.Add(mainview51);
                            if (mainregion51 != null)
                            {
                                mainregion51.Activate(mainview51);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Purchased From Supplier");
                            break;
                        case "Supplier Payment Due Days":
                          
                            var view52 = ServiceLocator.Current.GetInstance<SupplierPaymentDueDaysView>();
                            var region52 = this.regionManager.Regions[RegionNames.MainRegion];

                            region52.Add(view52);
                            if (region52 != null)
                            {
                                region52.Activate(view52);
                            }
                            SharedValues.getValue = "SupplierStatementTab";
                            var tabview52 = ServiceLocator.Current.GetInstance<SupplierTabView>();

                            IRegion tabregion52 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion52.Add(tabview52);
                            if (tabregion52 != null)
                            {
                                tabregion52.Activate(tabview52);
                            }
                            SharedValues.getValue = "PaymentDueDaysTab";
                            var SubTabView52 = ServiceLocator.Current.GetInstance<SASClient.Purchasing.View.StatementSubTabView>();
                            var subMenuRegion52 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion52.Add(SubTabView52);

                            if (subMenuRegion52 != null)
                            {
                                subMenuRegion52.Activate(SubTabView52);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Supliers Statement");
                            break;
                        case "Supplier Credit Paid Days":

       
                            var view53 = ServiceLocator.Current.GetInstance<SupplierCreditPaidDaysView>();
                            var region53 = this.regionManager.Regions[RegionNames.MainRegion];

                            region53.Add(view53);
                            if (region53 != null)
                            {
                                region53.Activate(view53);
                            }
                            SharedValues.getValue = "SupplierStatementTab";
                            var tabview53 = ServiceLocator.Current.GetInstance<SupplierTabView>();

                            IRegion tabregion53 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion53.Add(tabview53);
                            if (tabregion53 != null)
                            {
                                tabregion53.Activate(tabview53);
                            }
                            SharedValues.getValue = "CreditPaidTab";
                            var SubTabView53 = ServiceLocator.Current.GetInstance<SASClient.Purchasing.View.StatementSubTabView>();
                            var subMenuRegion53 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion53.Add(SubTabView53);

                            if (subMenuRegion53 != null)
                            {
                                subMenuRegion53.Activate(SubTabView53);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Supliers Statement");
                            break;
                        case "Invoice Debit Payments":
                          
                            var view54 = ServiceLocator.Current.GetInstance<InvoiceDebitPaymentsView>();
                            var region54 = this.regionManager.Regions[RegionNames.MainRegion];

                            region54.Add(view54);
                            if (region54 != null)
                            {
                                region54.Activate(view54);
                            }
                            SharedValues.getValue = "SupplierStatementTab";
                            var tabview54 = ServiceLocator.Current.GetInstance<SupplierTabView>();

                            IRegion tabregion54 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion54.Add(tabview54);
                            if (tabregion54 != null)
                            {
                                tabregion54.Activate(tabview54);
                            }
                            SharedValues.getValue = "InvDebPaymentTab";
                            var SubTabView54 = ServiceLocator.Current.GetInstance<SASClient.Purchasing.View.StatementSubTabView>();
                            var subMenuRegion54 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion54.Add(SubTabView54);

                            if (subMenuRegion54 != null)
                            {
                                subMenuRegion54.Activate(SubTabView54);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Supliers Statement");
                            break;
                        case "Supplier Balance":
                            var view55 = ServiceLocator.Current.GetInstance<SuppliersDetailsList2View>();
                            var region55 = this.regionManager.Regions[RegionNames.MainRegion];
                            region55.Add(view55);
                            if (region55 != null)
                            {
                                region55.Activate(view55);
                            }
                            SharedValues.getValue = "SupplierDetailTab";
                            var tabview55 = ServiceLocator.Current.GetInstance<SupplierTabView>();

                            IRegion tabregion55 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion55.Add(tabview55);
                            if (tabregion55 != null)
                            {
                                tabregion55.Activate(tabview55);
                            }
                            SharedValues.getValue = "SupplierDetailList2";
                            var SubTabView55 = ServiceLocator.Current.GetInstance<SuppliersDetailsSubTabView>();
                            var subMenuRegion55 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion55.Add(SubTabView55);

                            if (subMenuRegion55 != null)
                            {
                                subMenuRegion55.Activate(SubTabView55);
                            }


                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details List");
                            break;
                        case "Supplier Bill To Address":
                            var view56 = ServiceLocator.Current.GetInstance<SuppliersDetailsList3View>();
                            var region56 = this.regionManager.Regions[RegionNames.MainRegion];
                            region56.Add(view56);
                            if (region56 != null)
                            {
                                region56.Activate(view56);
                            }
                            SharedValues.getValue = "SupplierDetailTab";
                            var tabview56 = ServiceLocator.Current.GetInstance<SupplierTabView>();

                            IRegion tabregion56 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion56.Add(tabview56);
                            if (tabregion56 != null)
                            {
                                tabregion56.Activate(tabview56);
                            }
                            SharedValues.getValue = "SupplierDetailList3";
                            var SubTabView56 = ServiceLocator.Current.GetInstance<SuppliersDetailsSubTabView>();
                            var subMenuRegion56 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion56.Add(SubTabView56);

                            if (subMenuRegion56 != null)
                            {
                                subMenuRegion56.Activate(SubTabView56);
                            }


                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details List");
                            break;
                        case "Supplier Ship To Address":
                            var view58 = ServiceLocator.Current.GetInstance<SuppliersDetailsList4View>();
                            var region58 = this.regionManager.Regions[RegionNames.MainRegion];
                            region58.Add(view58);
                            if (region58 != null)
                            {
                                region58.Activate(view58);
                            }
                            SharedValues.getValue = "SupplierDetailTab";
                            var tabview58 = ServiceLocator.Current.GetInstance<SupplierTabView>();

                            IRegion tabregion58 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion58.Add(tabview58);
                            if (tabregion58 != null)
                            {
                                tabregion58.Activate(tabview58);
                            }
                            SharedValues.getValue = "SupplierDetailList4";
                            var SubTabView58 = ServiceLocator.Current.GetInstance<SuppliersDetailsSubTabView>();
                            var subMenuRegion58 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion58.Add(SubTabView58);

                            if (subMenuRegion58 != null)
                            {
                                subMenuRegion58.Activate(SubTabView58);
                            }


                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details List");
                            break;
                        case "Backup Data":
                            SharedValues.getValue = "BackupDataTab";
                            var tabview59 = ServiceLocator.Current.GetInstance<BackupDataView>();

                            var tabregion59 = this.regionManager.Regions[RegionNames.MainRegion];
                            tabregion59.Add(tabview59);
                            if (tabregion59 != null)
                            {
                                tabregion59.Activate(tabview59);
                            }

                            var view59 = ServiceLocator.Current.GetInstance<FileTabView>();

                            IRegion region59 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            region59.Add(view59);
                            if (region59 != null)
                            {
                                region59.Activate(view59);
                            }


                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Backup Data");
                            break;
                        case "Restore Data":
                            SharedValues.getValue = "RestoreDataTab";
                            var tabview60 = ServiceLocator.Current.GetInstance<RestoreDataView>();

                            var tabregion60 = this.regionManager.Regions[RegionNames.MainRegion];
                            tabregion60.Add(tabview60);
                            if (tabregion60 != null)
                            {
                                tabregion60.Activate(tabview60);
                            }

                            var view60 = ServiceLocator.Current.GetInstance<FileTabView>();

                            IRegion region60 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            region60.Add(view60);
                            if (region60 != null)
                            {
                                region60.Activate(view60);
                            }


                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Restore Data");
                            break;
                        case "Import Data":
                            SharedValues.getValue = "ImportDataTab";
                            var tabview61 = ServiceLocator.Current.GetInstance<ImportDataView>();

                            var tabregion61 = this.regionManager.Regions[RegionNames.MainRegion];
                            tabregion61.Add(tabview61);
                            if (tabregion61 != null)
                            {
                                tabregion61.Activate(tabview61);
                            }

                            var view61 = ServiceLocator.Current.GetInstance<FileTabView>();

                            IRegion region61 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            region61.Add(view61);
                            if (region61 != null)
                            {
                                region61.Activate(view61);
                            }
                            

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Import Data");
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            break;
                        case "Export Transaction Data":
                            SharedValues.getValue = "ExportDataTab";
                            var tabview62 = ServiceLocator.Current.GetInstance<ExportDataView>();

                            var tabregion62 = this.regionManager.Regions[RegionNames.MainRegion];
                            tabregion62.Add(tabview62);
                            if (tabregion62 != null)
                            {
                                tabregion62.Activate(tabview62);
                            }

                            var view62 = ServiceLocator.Current.GetInstance<FileTabView>();

                            IRegion region62 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            region62.Add(view62);
                            if (region62 != null)
                            {
                                region62.Activate(view62);
                            }
                            SharedValues.getValue = "ExportDataTransactionTabTrue";
                            var SubTabView62 = ServiceLocator.Current.GetInstance<FileSubTabView>();
                            var subMenuRegion62 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion62.Add(SubTabView62);

                            if (subMenuRegion62 != null)
                            {
                                subMenuRegion62.Activate(SubTabView62);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Export Data");
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            break;
                        case "Company Details":
                            SharedValues.getValue = "CompanyDetailsTab";
                            var tabview63 = ServiceLocator.Current.GetInstance<SettingsTabView>();

                            var region63 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            region63.Add(tabview63);
                            if (region63 != null)
                            {
                                region63.Activate(tabview63);
                            }

                            var view63 = ServiceLocator.Current.GetInstance<CompanyDetailsView>();

                            var mainregion63 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion63.Add(view63);
                            if (mainregion63 != null)
                            {
                                mainregion63.Activate(view63);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Company Details");
                            break;
                        case "Categories":
                            SharedValues.getValue = "CategoryTab";
                            var tabview64 = ServiceLocator.Current.GetInstance<SettingsTabView>();

                            var region64 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            region64.Add(tabview64);
                            if (region64 != null)
                            {
                                region64.Activate(tabview64);
                            }

                            var view64 = ServiceLocator.Current.GetInstance<CategoryView>();

                            var mainregion64 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion64.Add(view64);
                            if (mainregion64 != null)
                            {
                                mainregion64.Activate(view64);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Categories");
                            break;
                        case "Options":
                            SharedValues.getValue = "OptionsTab";
                            var tabview65 = ServiceLocator.Current.GetInstance<SettingsTabView>();

                            var region65 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            region65.Add(tabview65);
                            if (region65 != null)
                            {
                                region65.Activate(tabview65);
                            }

                            var view65 = ServiceLocator.Current.GetInstance<OptionsView>();

                            var mainregion65 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion65.Add(view65);
                            if (mainregion65 != null)
                            {
                                mainregion65.Activate(view65);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Options");
                            break;
                        case "GST/VAT Codes and Rates":
                            SharedValues.getValue = "CodesandRatesTab";
                            var tabview66 = ServiceLocator.Current.GetInstance<SettingsTabView>();

                            var region66 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            region66.Add(tabview66);
                            if (region66 != null)
                            {
                                region66.Activate(tabview66);
                            }

                            var view66 = ServiceLocator.Current.GetInstance<TaxCodesAndRatesView>();

                            var mainregion66 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion66.Add(view66);
                            if (mainregion66 != null)
                            {
                                mainregion66.Activate(view66);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("GST/VAT Codes and Rates");
                            break;
                        case "Users and Security":
                            SharedValues.getValue = "UsersandSecurityTab";
                            var tabview67 = ServiceLocator.Current.GetInstance<SettingsTabView>();

                            var region67 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            region67.Add(tabview67);
                            if (region67 != null)
                            {
                                region67.Activate(tabview67);
                            }

                            var view67 = ServiceLocator.Current.GetInstance<UsersSecurityView>();

                            var mainregion67 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion67.Add(view67);
                            if (mainregion67 != null)
                            {
                                mainregion67.Activate(view67);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Users and Security");
                            break;
                        case "Customers Details":
                          
                                SharedValues.getValue = "CustomerDetailTab";
                                var view68 = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersView>();

                                IRegion region68 = this.regionManager.Regions[RegionNames.MainRegion];

                            region68.Add(view68);
                                if (region68 != null)
                                {
                                region68.Activate(view68);
                                }

                                var tabview68 = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersTabView>();

                                IRegion tabregion68 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion68.Add(tabview68);
                                if (tabregion68 != null)
                                {
                                tabregion68.Activate(tabview68);
                                }
                            
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details Form");
                            break;
                        case "Customers Details List":
                           
                                
                                var view69 = ServiceLocator.Current.GetInstance<CustomersDetailsList1View>();
                                var region69 = this.regionManager.Regions[RegionNames.MainRegion];
                            region69.Add(view69);
                                if (region69 != null)
                                {
                                region69.Activate(view69);
                                }
                            SharedValues.getValue = "CustomerDetailTab";
                            var tabview69 = ServiceLocator.Current.GetInstance<CustomersTabView>();

                                IRegion tabregion69 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion69.Add(tabview69);
                                if (tabregion69 != null)
                                {
                                tabregion69.Activate(tabview69);
                                }
                            SharedValues.getValue = "CustomerDetailList1";
                            var SubTabView69 = ServiceLocator.Current.GetInstance<CustomersDetailsSubTabView>();
                                var subMenuRegion69 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion69.Add(SubTabView69);

                                if (subMenuRegion69 != null)
                                {
                                subMenuRegion69.Activate(SubTabView69);
                                }

                            
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details List");
                            break;
                        case "Customers History":
                        
                                SharedValues.getValue = "CustomerHistoryTab";
                                var view70 = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomerHistoryView>();

                                IRegion region70 = this.regionManager.Regions[RegionNames.MainRegion];

                            region70.Add(view70);
                                if (region70 != null)
                                {
                                region70.Activate(view70);
                                }

                                var tabview70 = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersTabView>();

                                IRegion tabregion70 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion70.Add(tabview70);
                                if (tabregion70 != null)
                                {
                                tabregion70.Activate(tabview70);
                                }
                            
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers History");
                            break;
                        case "Top Customers":
                          
                                SharedValues.getValue = "TopCustomersTab";
                                var view71 = ServiceLocator.Current.GetInstance<SDN.Customers.Views.TopCustomersView>();

                                IRegion region71 = this.regionManager.Regions[RegionNames.MainRegion];

                            region71.Add(view71);
                                if (region71 != null)
                                {
                                region71.Activate(view71);
                                }

                                var tabview71 = ServiceLocator.Current.GetInstance<SDN.Customers.Views.CustomersTabView>();

                                IRegion tabregion71 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion71.Add(tabview71);
                                if (tabregion71 != null)
                                {
                                tabregion71.Activate(tabview71);
                                }
                            
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Top Customers");
                          
                            break;
                        case "Products and Services Sold to Customers":
                            SharedValues.getValue = "PandSSoldToCustomersTab";

                            var tabview72 = ServiceLocator.Current.GetInstance<CustomersTabView>();

                            var tabregion72 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion72.Add(tabview72);
                            if (tabregion72 != null)
                            {
                                tabregion72.Activate(tabview72);
                            }

                            var mainview72 = ServiceLocator.Current.GetInstance<PandSSoldToCustomersView>();

                            var mainregion72 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion72.Add(mainview72);
                            if (mainregion72 != null)
                            {
                                mainregion72.Activate(mainview72);
                            }
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Sold to Customers");
                            break;
                        case "Customers Unpaid Invoices":
                            

                            var view73 = ServiceLocator.Current.GetInstance<CustomersUnPaidInvoicesView>();
                            var region73 = this.regionManager.Regions[RegionNames.MainRegion];
                            region73.Add(view73);
                            if (region73 != null)
                            {
                                region73.Activate(view73);
                            }
                            SharedValues.getValue = "CustomerStatementTab";
                            var tabview73 = ServiceLocator.Current.GetInstance<CustomersTabView>();

                            IRegion tabregion73 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion73.Add(tabview73);
                            if (tabregion73 != null)
                            {
                                tabregion73.Activate(tabview73);
                            }
                            SharedValues.getValue = "UnpaidInvoice";
                            var SubTabView73 = ServiceLocator.Current.GetInstance<SASClient.Customers.Views.StatementSubTabView>();
                            var subMenuRegion73 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion73.Add(SubTabView73);

                            if (subMenuRegion73 != null)
                            {
                                subMenuRegion73.Activate(SubTabView73);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Statement");
                            break;
                        case "Invoice Credit Payments":
                          
                            var view74 = ServiceLocator.Current.GetInstance<InvoiceCreditPaymentsView>();
                            var region74 = this.regionManager.Regions[RegionNames.MainRegion];
                            region74.Add(view74);
                            if (region74 != null)
                            {
                                region74.Activate(view74);
                            }
                            SharedValues.getValue = "CustomerStatementTab";
                            var tabview74 = ServiceLocator.Current.GetInstance<CustomersTabView>();

                            IRegion tabregion74 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion74.Add(tabview74);
                            if (tabregion74 != null)
                            {
                                tabregion74.Activate(tabview74);
                            }
                            SharedValues.getValue = "InvoiceTabTrue";
                            var SubTabView74 = ServiceLocator.Current.GetInstance<SASClient.Customers.Views.StatementSubTabView>(); 
                            var subMenuRegion74 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion74.Add(SubTabView74);

                            if (subMenuRegion74 != null)
                            {
                                subMenuRegion74.Activate(SubTabView74);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Statement");
                            break;
                        case "Customer Payment Due Days":
                            

                            var view75 = ServiceLocator.Current.GetInstance<CustomerPaymentDueDaysView>();
                            var region75 = this.regionManager.Regions[RegionNames.MainRegion];
                            region75.Add(view75);
                            if (region75 != null)
                            {
                                region75.Activate(view75);
                            }
                            SharedValues.getValue = "CustomerStatementTab";
                            var tabview75 = ServiceLocator.Current.GetInstance<CustomersTabView>();

                            IRegion tabregion75 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion75.Add(tabview75);
                            if (tabregion75 != null)
                            {
                                tabregion75.Activate(tabview75);
                            }
                            SharedValues.getValue = "PaymentTabTrue";
                            var SubTabView75 = ServiceLocator.Current.GetInstance<SASClient.Customers.Views.StatementSubTabView>();
                            var subMenuRegion75 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion75.Add(SubTabView75);

                            if (subMenuRegion75 != null)
                            {
                                subMenuRegion75.Activate(SubTabView75);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Statement");
                            break;
                        case "Customer Credit Paid Days":
                            

                            var view76 = ServiceLocator.Current.GetInstance<CustomerCreditPaidDaysView>();
                            var region76 = this.regionManager.Regions[RegionNames.MainRegion];
                            region76.Add(view76);
                            if (region76 != null)
                            {
                                region76.Activate(view76);
                            }
                            SharedValues.getValue = "CustomerStatementTab";
                            var tabview76 = ServiceLocator.Current.GetInstance<CustomersTabView>();

                            IRegion tabregion76 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion76.Add(tabview76);
                            if (tabregion76 != null)
                            {
                                tabregion76.Activate(tabview76);
                            }
                            SharedValues.getValue = "CreditPaidDays";
                            var SubTabView76 = ServiceLocator.Current.GetInstance<SASClient.Customers.Views.StatementSubTabView>();
                            var subMenuRegion76 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion76.Add(SubTabView76);

                            if (subMenuRegion76 != null)
                            {
                                subMenuRegion76.Activate(SubTabView76);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Statement");
                            break;
                        case "Customers Balance":
                            var view77 = ServiceLocator.Current.GetInstance<CustomersDetailsList2View>();
                            var region77 = this.regionManager.Regions[RegionNames.MainRegion];
                            region77.Add(view77);
                            if (region77 != null)
                            {
                                region77.Activate(view77);
                            }
                            SharedValues.getValue = "CustomerDetailTab";
                            var tabview77 = ServiceLocator.Current.GetInstance<CustomersTabView>();

                            IRegion tabregion77 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion77.Add(tabview77);
                            if (tabregion77 != null)
                            {
                                tabregion77.Activate(tabview77);
                            }
                            SharedValues.getValue = "CustomerDetailList2";
                            var SubTabView77 = ServiceLocator.Current.GetInstance<CustomersDetailsSubTabView>();
                            var subMenuRegion77 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion77.Add(SubTabView77);

                            if (subMenuRegion77 != null)
                            {
                                subMenuRegion77.Activate(SubTabView77);
                            }


                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details List");
                            break;
                        case "Customers Bill To address":
                            var view78 = ServiceLocator.Current.GetInstance<CustomersDetailsList3View>();
                            var region78 = this.regionManager.Regions[RegionNames.MainRegion];
                            region78.Add(view78);
                            if (region78 != null)
                            {
                                region78.Activate(view78);
                            }
                            SharedValues.getValue = "CustomerDetailTab";
                            var tabview78 = ServiceLocator.Current.GetInstance<CustomersTabView>();

                            IRegion tabregion78 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion78.Add(tabview78);
                            if (tabregion78 != null)
                            {
                                tabregion78.Activate(tabview78);
                            }
                            SharedValues.getValue = "CustomerDetailList3";
                            var SubTabView78 = ServiceLocator.Current.GetInstance<CustomersDetailsSubTabView>();
                            var subMenuRegion78 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion78.Add(SubTabView78);

                            if (subMenuRegion78 != null)
                            {
                                subMenuRegion78.Activate(SubTabView78);
                            }


                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details List");
                            break;
                        case "Customers Ship To Address":
                   
                            var view79 = ServiceLocator.Current.GetInstance<CustomersDetailsList4View>();
                            var region79 = this.regionManager.Regions[RegionNames.MainRegion];
                            region79.Add(view79);
                            if (region79 != null)
                            {
                                region79.Activate(view79);
                            }
                            SharedValues.getValue = "CustomerDetailTab";
                            var tabview79 = ServiceLocator.Current.GetInstance<CustomersTabView>();

                            IRegion tabregion79 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion79.Add(tabview79);
                            if (tabregion79 != null)
                            {
                                tabregion79.Activate(tabview79);
                            }
                            SharedValues.getValue = "CustomerDetailList4";
                            var SubTabView79 = ServiceLocator.Current.GetInstance<CustomersDetailsSubTabView>();
                            var subMenuRegion79 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion79.Add(SubTabView79);

                            if (subMenuRegion79 != null)
                            {
                                subMenuRegion79.Activate(SubTabView79);
                            }


                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Details List");
                            break;
                        case "Accounts Details":
                            SharedValues.getValue = "AccountsDetailsTab";
                            SharedValues.NewClick = "New";
                            var tabview80 = ServiceLocator.Current.GetInstance<AccountsTabView>();

                            var tabregion80 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion80.Add(tabview80);
                            if (tabregion80 != null)
                            {
                                tabregion80.Activate(tabview80);
                            }
                          
                            var mainview80 = ServiceLocator.Current.GetInstance<AccountsDetailsView>();

                            var mainregion80 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion80.Add(mainview80);
                            if (mainregion80 != null)
                            {
                                mainregion80.Activate(mainview80);
                            }////
                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Accounts Details Form");
                            break;
                        case "Accounts Details List":

                            SharedValues.getValue = "AccountsDetailsTab";
                            var view81 = ServiceLocator.Current.GetInstance<AccountsDetailsListView>();
                            var region81 = this.regionManager.Regions[RegionNames.MainRegion];
                            region81.Add(view81);
                            if (region81 != null)
                            {
                                region81.Activate(view81);
                            }

                            var tabview81 = ServiceLocator.Current.GetInstance<SASClient.Accounts.Views.AccountsTabView>();
                            var tabregion81 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion81.Add(tabview81);
                            if (tabregion81 != null)
                            {
                                tabregion81.Activate(tabview81);
                            }


                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Accounts Details List");
                            break;
                        case "Profit & Loss Statement":
                          
                                SharedValues.getValue = "ProfitAndLosStatementTab";
                                var view82 = ServiceLocator.Current.GetInstance<AccountHistoryView>();
                                var region82 = this.regionManager.Regions[RegionNames.MainRegion];
                            region82.Add(view82);
                                if (region82 != null)
                                {
                                region82.Activate(view82);
                                }

                                var tabview82 = ServiceLocator.Current.GetInstance<SASClient.Accounts.Views.AccountsTabView>();
                                var tabregion82 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion82.Add(tabview82);
                                if (tabregion82 != null)
                                {
                                tabregion82.Activate(tabview82);
                                }
                            

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Profit & Loss Statement");
                            break;
                        case "Accounts Transactions":
                            SharedValues.getValue = "AccountsTransactionsTab";

                            var view83 = ServiceLocator.Current.GetInstance<AccountsTransactionsView>();
                            var region83 = this.regionManager.Regions[RegionNames.MainRegion];
                            region83.Add(view83);
                            if (region83 != null)
                            {
                                region83.Activate(view83);
                            }

                            var tabview83 = ServiceLocator.Current.GetInstance<AccountsTabView>();

                            IRegion tabregion83 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                            tabregion83.Add(tabview83);
                            if (tabregion83 != null)
                            {
                                tabregion83.Activate(tabview83);
                            }


                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Accounts Transactions");
                            break;
                        case "Journal List":
                            SharedValues.getValue = "JournalTab";
                            var mainview84 = ServiceLocator.Current.GetInstance<JournalListView>();
                            var mainregion84 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion84.Add(mainview84);
                            if (mainregion84 != null)
                            {
                                mainregion84.Activate(mainview84);
                            }


                            var tabview84 = ServiceLocator.Current.GetInstance<AccountsTabView>();
                            var tabregion84 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion84.Add(tabview84);
                            if (tabregion84 != null)
                            {
                                tabregion84.Activate(tabview84);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Journal (JO) List");
                            break;
                        case "Journal":
                         
                            SharedValues.getValue = "JournalTab";
                            var mainview85 = ServiceLocator.Current.GetInstance<JournalView>();
                            var mainregion85 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion85.Add(mainview85);
                            if (mainregion85 != null)
                            {
                                mainregion85.Activate(mainview85);
                            }


                            var tabview85 = ServiceLocator.Current.GetInstance<AccountsTabView>();
                            var tabregion85 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion85.Add(tabview85);
                            if (tabregion85 != null)
                            {
                                tabregion85.Activate(tabview85);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Journal (JO) Form");
                            break;
                        case "Ledger":
                            SharedValues.getValue = "LedgerTab";
                            var mainview86 = ServiceLocator.Current.GetInstance<LedgerView>();
                            var mainregion86 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion86.Add(mainview86);
                            if (mainregion86 != null)
                            {
                                mainregion86.Activate(mainview86);
                            }


                            var tabview86 = ServiceLocator.Current.GetInstance<AccountsTabView>();
                            var tabregion86 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion86.Add(tabview86);
                            if (tabregion86 != null)
                            {
                                tabregion86.Activate(tabview86);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Ledger");
                            break;
                        //case "ProfitAndLossStatementView":
                        //    SharedValues.getValue = "ProfitAndLosStatementTab";
                        //    var tabview87 = ServiceLocator.Current.GetInstance<AccountsTabView>();

                        //    var tabregion87 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                        //    tabregion87.Add(tabview87);
                        //    if (tabregion87 != null)
                        //    {
                        //        tabregion87.Activate(tabview87);
                        //    }

                        //    var mainview87 = ServiceLocator.Current.GetInstance<ProfitAndLossStatementView>();

                        //    var mainregion87 = this.regionManager.Regions[RegionNames.MainRegion];
                        //    mainregion87.Add(mainview87);
                        //    if (mainregion87 != null)
                        //    {
                        //        mainregion87.Activate(mainview87);
                        //    }
                        //    eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                        //    //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                        //    eventAggregator.GetEvent<TitleChangedEvent>().Publish("Profit & Loss Statement");
                        //    break;
                        case "Balance Sheet":
                            SharedValues.getValue = "BalanceSheetTab";
                            var mainview88 = ServiceLocator.Current.GetInstance<BalanceSheetView>();
                            var mainregion88 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion88.Add(mainview88);
                            if (mainregion88 != null)
                            {
                                mainregion88.Activate(mainview88);
                            }


                            var tabview88 = ServiceLocator.Current.GetInstance<AccountsTabView>();
                            var tabregion88 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion88.Add(tabview88);
                            if (tabregion88 != null)
                            {
                                tabregion88.Activate(tabview88);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Balance Sheet");
                            break;
                        case "GST Reports":
                      
                                SharedValues.getValue = "GSTAndVatTab";
                                //SharedValues.NewClick = "New";
                                var tabview89 = ServiceLocator.Current.GetInstance<AccountsTabView>();

                                var tabregion89 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion89.Add(tabview89);
                                if (tabregion89 != null)
                                {
                                tabregion89.Activate(tabview89);
                                }
                                PurchaseTabEntity tabentity89 = new PurchaseTabEntity();
                                var tabentityValue1 = tabentity89 as PurchaseTabEntity;
                                tabentityValue1.OrderTabTrue = true;

                                var mainview89 = ServiceLocator.Current.GetInstance<GstAndVatSummaryView>();

                                var mainregion89 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion89.Add(mainview89);
                                if (mainregion89 != null)
                                {
                                    mainregion89.Activate(mainview89);
                                }////
                                var SubTabView89 = ServiceLocator.Current.GetInstance<GstAndVatSubTab>();
                                var subMenuRegion89 = regionManager.Regions[RegionNames.SubMenuBarRegion];

                            subMenuRegion89.Add(SubTabView89);

                                if (subMenuRegion89 != null)
                                {
                                subMenuRegion89.Activate(SubTabView89);
                                }
                                eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                                eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
                                eventAggregator.GetEvent<TitleChangedEvent>().Publish(" GST / VAT Reports");
                                break;
                        case "Unpaid Sales Invoice":
                            SharedValues.getValue = "UnpaidSalesInvoiceTab";
                            var view90 = ServiceLocator.Current.GetInstance<UnpaidSalesInvoiceView>();
                            var region90 = this.regionManager.Regions[RegionNames.MainRegion];
                            region90.Add(view90);
                            if (region90 != null)
                            {
                                region90.Activate(view90);
                            }
                            var tabview90 = ServiceLocator.Current.GetInstance<AccountsDetailsTabView>();

                            var tabregion90 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion90.Add(tabview90);
                            if (tabregion90 != null)
                            {
                                tabregion90.Activate(tabview90);
                            }
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Previous Accounting System Closing Balances");
                            break;
                        case "Unpaid Purchase Invoice":
                            SharedValues.getValue = "UnpaidPurchaseInvoiceTab";
                            var view91 = ServiceLocator.Current.GetInstance<UnpaidPurchaseInvoiceView>();
                            var region91 = this.regionManager.Regions[RegionNames.MainRegion];
                            region91.Add(view91);
                            if (region91 != null)
                            {
                                region91.Activate(view91);
                            }
                            var tabview91 = ServiceLocator.Current.GetInstance<AccountsDetailsTabView>();

                            var tabregion91 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion91.Add(tabview91);
                            if (tabregion91 != null)
                            {
                                tabregion91.Activate(tabview91);
                            }
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Previous Accounting System Closing Balances");
                            break;
                        case "Undelivered Sales Orders":
                            SharedValues.getValue = "UndeliveredSalesOrdersWithDepositsTab";
                            var view92 = ServiceLocator.Current.GetInstance<UndeliveredSalesOrdersWithDepositsView>();
                            var region92 = this.regionManager.Regions[RegionNames.MainRegion];
                            region92.Add(view92);
                            if (region92 != null)
                            {
                                region92.Activate(view92);
                            }
                            var tabview92 = ServiceLocator.Current.GetInstance<AccountsDetailsTabView>();

                            var tabregion92 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion92.Add(tabview92);
                            if (tabregion92 != null)
                            {
                                tabregion92.Activate(tabview92);
                            }
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Previous Accounting System Closing Balances");
                            break;
                        case "Undelivered Purchase Orders":
                            SharedValues.getValue = "UndeliveredPurchaseOrdersWithDepositsTab";
                            var view93 = ServiceLocator.Current.GetInstance<UndeliveredPurchaseOrdersDepositsView>();
                            var region93 = this.regionManager.Regions[RegionNames.MainRegion];
                            region93.Add(view93);
                            if (region93 != null)
                            {
                                region93.Activate(view93);
                            }
                            var tabview93 = ServiceLocator.Current.GetInstance<AccountsDetailsTabView>();

                            var tabregion93 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion93.Add(tabview93);
                            if (tabregion93 != null)
                            {
                                tabregion93.Activate(tabview93);
                            }
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Previous Accounting System Closing Balances");
                            break;
                        case "Stock":
                            SharedValues.getValue = "StockTab";
                            var view94 = ServiceLocator.Current.GetInstance<StockView>();
                            var region94 = this.regionManager.Regions[RegionNames.MainRegion];
                            region94.Add(view94);
                            if (region94 != null)
                            {
                                region94.Activate(view94);
                            }
                            var tabview94 = ServiceLocator.Current.GetInstance<AccountsDetailsTabView>();

                            var tabregion94 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion94.Add(tabview94);
                            if (tabregion94 != null)
                            {
                                tabregion94.Activate(tabview94);
                            }
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Previous Accounting System Closing Balances");
                            break;
                        case "Trail Balance":
                            SharedValues.getValue = "TrailBalanceTab";
                            var mainview95 = ServiceLocator.Current.GetInstance<TrailBalanceView>();
                            var mainregion95 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion95.Add(mainview95);
                            if (mainregion95 != null)
                            {
                                mainregion95.Activate(mainview95);
                            }


                            var tabview95 = ServiceLocator.Current.GetInstance<AccountsTabView>();
                            var tabregion95 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion95.Add(tabview95);
                            if (tabregion95 != null)
                            {
                                tabregion95.Activate(tabview95);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Trial Balance");
                            //SharedValues.NewClick = "New";    
                            break;
                        case "Notifications":
                            SharedValues.getValue = "NotificationTab";
                            var mainview96 = ServiceLocator.Current.GetInstance<NotificationsView>();
                            var mainregion96 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion96.Add(mainview96);
                            if (mainregion96 != null)
                            {
                                mainregion96.Activate(mainview96);
                            }


                            var tabview96 = ServiceLocator.Current.GetInstance<HomeScreenTabView>();
                            var tabregion96 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion96.Add(tabview96);
                            if (tabregion96 != null)
                            {
                                tabregion96.Activate(tabview96);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Notifications");
                            break;
                        case "Audit Trail":
                            SharedValues.getValue = "AuditTrailTabTrue";
                            var mainview97 = ServiceLocator.Current.GetInstance<AuditTrailView>();
                            var mainregion97 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion97.Add(mainview97);
                            if (mainregion97 != null)
                            {
                                mainregion97.Activate(mainview97);
                            }


                            var tabview97 = ServiceLocator.Current.GetInstance<HomeScreenTabView>();
                            var tabregion97 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion97.Add(tabview97);
                            if (tabregion97 != null)
                            {
                                tabregion97.Activate(tabview97);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Audit Trail");
                            break;
                        case "To Do List":
                            SharedValues.getValue = "TodoListTabTrue";
                            var mainview98 = ServiceLocator.Current.GetInstance<ToDoUnpaidDetailView>();
                            var mainregion98 = this.regionManager.Regions[RegionNames.MainRegion];
                            mainregion98.Add(mainview98);
                            if (mainregion98 != null)
                            {
                                mainregion98.Activate(mainview98);
                            }


                            var tabview98 = ServiceLocator.Current.GetInstance<HomeScreenTabView>();
                            var tabregion98 = this.regionManager.Regions[RegionNames.MenuBarRegion];
                            tabregion98.Add(tabview98);
                            if (tabregion98 != null)
                            {
                                tabregion98.Activate(tabview98);
                            }

                            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("To Do List");
                            break;
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        private void setdefaultTab()
        {
            //if (SharedValues.getValue == "CashBankStatementTab")
            //{
            //    this.CashBankStatementTabTrue = true;
            //}
            //if (SharedValues.getValue == "RefundFromSupplierTab")
            //{
            //    this.RefundFromSupplierTabTrue = true;
            //}
            //if (SharedValues.getValue == "RefundToCustomerTab")
            //{
            //    this.RefundToCustomerTabTrue = true;
            //}
            //if (SharedValues.getValue == "ReceiveMoneyTab")
            //{
            //    this.ReceiveMoneyTabTrue = true;
            //}
            //if (SharedValues.getValue == "PayMoneyTab")
            //{
            //    this.PayMoneyTabTrue = true;
            //}
            //if (SharedValues.getValue == "TransferMoneyTab")
            //{
            //    this.TransferMoneyTabTrue = true;
            //}

        }
    }
}