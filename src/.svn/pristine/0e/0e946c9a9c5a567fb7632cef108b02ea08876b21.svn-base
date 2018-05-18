
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Purchasing.ViewModel
{
    using CloseRequest;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using SASClient.Purchasing.View;
    using SDN.Common;
    using SDN.UI.Entities;
    using System.Windows;

    public class StatementSubTabViewModel: SupplierTabEntity
    {
        #region "Private members"


        private readonly IRegionManager regionManager;
        StackList listitem = new StackList();

        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        public StatementSubTabViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

        }
        public StatementSubTabViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.setdefaultTab();
            //inInitializer();
        }

        /// <summary>
        /// The Companydetails click command
        /// </summary>
        private readonly DelegateCommand unPaidInvoicesClickCommand = null;
        private readonly DelegateCommand invDebitPaymentsClickCommand = null;
        private readonly DelegateCommand costPricesClickCommand = null;
        private readonly DelegateCommand stockQuantitiesClickCommand = null;
        private readonly DelegateCommand gSTCodesRatesClickCommand = null;
        private readonly DelegateCommand stockValuesClickCommand = null;
        private readonly DelegateCommand countandAdjustClickCommand = null;
        private readonly DelegateCommand paymentDueClickCommand = null;
        private readonly DelegateCommand creditPaidDaysClickCommand = null;



        #endregion

        #region "Public properties"

        /// <summary>
        /// Gets the Company details click command.
        /// </summary>
        /// <value>
        /// The Companydetails click command.
        /// </value>

        public DelegateCommand UnPaidInvoicesClickCommand
        {
            get
            {
                return (this.unPaidInvoicesClickCommand ?? new DelegateCommand(this.ShowUnPaidInvoicesView));
            }
        }
        public DelegateCommand InvDebitPaymentsClickCommand
        {
            get
            {
                return (this.invDebitPaymentsClickCommand ?? new DelegateCommand(this.ShowInvDebitPaymentsView));
            }
        }
        public DelegateCommand CostPricesClickCommand
        {
            get
            {
                return (this.costPricesClickCommand ?? new DelegateCommand(this.CostPricesView));
            }
        }
        public DelegateCommand StockQuantitiesClickCommand
        {
            get
            {
                return (this.stockQuantitiesClickCommand ?? new DelegateCommand(this.StockQuantitiesView));
            }
        }
        public DelegateCommand GSTCodesRatesClickCommand
        {
            get
            {
                return (this.gSTCodesRatesClickCommand ?? new DelegateCommand(this.GSTCodesRatesView));
            }
        }
        public DelegateCommand PaymentDueClickCommand 
        {
            get
            {
                return (this.paymentDueClickCommand  ?? new DelegateCommand(this.PaymentDueView));
            }
        }
        public DelegateCommand CreditPaidDaysClickCommand
        {
            get
            {
                return (this.creditPaidDaysClickCommand ?? new DelegateCommand(this.CreditPaidDaysView));
            }
        }


        #endregion

        #region "Private Methods"

        private void ShowUnPaidInvoicesView()
        {
            SharedValues.ScreenCheckName = "Suppliers Statement";
            SharedValues.ViewName = "Suppliers UnPaid Invoices";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "UnpaidInvoicesTab";
            var view = ServiceLocator.Current.GetInstance<SuppliersUnPaidInvoicesView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];

            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Statement");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

        private void PaymentDueView()
        {
            SharedValues.ScreenCheckName = "Suppliers Statement";
            SharedValues.ViewName = "Supplier Payment Due Days";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "PaymentDueDaysTab";
            var view = ServiceLocator.Current.GetInstance<SupplierPaymentDueDaysView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];

            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Statement");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        private void CreditPaidDaysView()
        {
            SharedValues.ScreenCheckName = "Suppliers Statement";
            SharedValues.ViewName = "Supplier Credit Paid Days";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "CreditPaidTab";
            var view = ServiceLocator.Current.GetInstance<SupplierCreditPaidDaysView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];

            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Statement");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

        private void ShowInvDebitPaymentsView()
        {
            SharedValues.ScreenCheckName = "Suppliers Statement";
            SharedValues.ViewName = "Invoice Debit Payments";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "InvDebPaymentTab";
            var view = ServiceLocator.Current.GetInstance<InvoiceDebitPaymentsView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];

            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Statement");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

        private void SellPricesView()
        {
            //SharedValues.getValue = "CountandAdjustStockTab";
            //var view = ServiceLocator.Current.GetInstance<PandSSellPriceListView>();

            ////var region = this.regionManager.Regions[RegionNames.MainRegion];
            ////region.Add(view);
            ////if (region != null)
            ////{
            ////    region.Activate(view);
            ////}
            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            //eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Details List - Sell Prices");
        }

        private void CostPricesView()
        {
            //SharedValues.getValue = "CountandAdjustStockTab";
            //var view = ServiceLocator.Current.GetInstance<PandSCostPriceListView>();

            ////var region = this.regionManager.Regions[RegionNames.MainRegion];
            ////region.Add(view);
            ////if (region != null)
            ////{
            ////    region.Activate(view);
            ////}
            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            //eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Details List - Cost Prices");
        }
        private void StockQuantitiesView()
        {
            //SharedValues.getValue = "CountandAdjustStockTab";
            //var view = ServiceLocator.Current.GetInstance<PandSStockQuantitiesListView>();

            ////var region = this.regionManager.Regions[RegionNames.MainRegion];
            ////region.Add(view);
            ////if (region != null)
            ////{
            ////    region.Activate(view);
            ////}
            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            //eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Details List - Stock Quantities");
        }
        private void GSTCodesRatesView()
        {
            ////SharedValues.getValue = "CountandAdjustStockTab";
            //var view = ServiceLocator.Current.GetInstance<PandSCodesAndRatesListView>();

            ////var region = this.regionManager.Regions[RegionNames.MainRegion];
            ////region.Add(view);
            ////if (region != null)
            ////{
            ////    region.Activate(view);
            ////}
            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            //eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Details List - GST Codes and Rate");
        }
       

        #endregion
        private void setdefaultTab()
        {

            if (SharedValues.getValue == "UnpaidInvoicesTab")
            {
                this.SupplierStatementTabTrue = true;
                this.UnpaidInvoicesTabTrue = true;
            }
            else if (SharedValues.getValue == "InvDebPaymentTab")
            {
                this.SupplierStatementTabTrue = true;
                this.InvDebPaymentTabTrue = true;
            }
            else if (SharedValues.getValue == "PaymentDueDaysTab")
            {
                this.SupplierStatementTabTrue = true;
                this.PaymentDueDaysTabTrue = true;
            }
            else if (SharedValues.getValue == "CreditPaidTab")
            {
                this.SupplierStatementTabTrue = true;
                this.CreditPaidTabTrue = true;
            }
            else
            {
                this.UnpaidInvoicesTabTrue = true;
            }
        }
    }
}
