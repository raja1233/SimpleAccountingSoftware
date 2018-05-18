using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using SASClient.CloseRequest;
using SASClient.Customers.Views;
using SDN.Common;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SASClient.Customers.ViewModel
{
    public class StatementSubTabViewModel : CustomerTabEntity
    {
        #region "Private members"

        StackList listitem = new StackList();
        private readonly IRegionManager regionManager;

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
        private readonly DelegateCommand invCreditPaymentsClickCommand = null;
        private readonly DelegateCommand costPricesClickCommand = null;
        private readonly DelegateCommand stockQuantitiesClickCommand = null;
        private readonly DelegateCommand gSTCodesRatesClickCommand = null;
        private readonly DelegateCommand stockValuesClickCommand = null;
        private readonly DelegateCommand countandAdjustClickCommand = null;
        private readonly DelegateCommand paymentDueClickCommand = null;
        private readonly DelegateCommand creditPaidDaysCommand = null;



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
        public DelegateCommand InvCreditPaymentsClickCommand
        {
            get
            {
                return (this.invCreditPaymentsClickCommand ?? new DelegateCommand(this.ShowInvoiceCreditPaymentsView));
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
                return (this.paymentDueClickCommand ?? new DelegateCommand(this.PaymentDueView));
            }
        }
        public DelegateCommand CreditPaidDaysCommand
        {
            get
            {
                return (this.creditPaidDaysCommand ?? new DelegateCommand(this.CreditPaidDaysView));
            }
        }


        #endregion

        #region "Private Methods"

        private void ShowUnPaidInvoicesView()
        {
            SharedValues.ScreenCheckName = "Customers Statement";
            SharedValues.ViewName = "Customers Unpaid Invoices";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "UnpaidInvoice";
            var view = ServiceLocator.Current.GetInstance<CustomersUnPaidInvoicesView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];

            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Statement");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        private void PaymentDueView()
        {

            SharedValues.ScreenCheckName = "Customers Statement";
            SharedValues.ViewName = "Customer Payment Due Days";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "PaymentTabTrue";
           
            var view = ServiceLocator.Current.GetInstance<CustomerPaymentDueDaysView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];

            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Statement");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

        private void CreditPaidDaysView()
        {
            SharedValues.ScreenCheckName = "Customers Statement";
            SharedValues.ViewName = "Customer Credit Paid Days";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "CreditPaidDays";
            var view = ServiceLocator.Current.GetInstance<CustomerCreditPaidDaysView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];

            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Statement");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

        private void ShowInvoiceCreditPaymentsView()
        {
            SharedValues.ScreenCheckName = "Customers Statement";
            SharedValues.ViewName = "Invoice Credit Payments";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "InvoiceTabTrue";
            var view = ServiceLocator.Current.GetInstance<InvoiceCreditPaymentsView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];

            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Customers Statement");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
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

            if (SharedValues.getValue == "UnpaidInvoice")
            {
                this.CustomerStatementTrue = true;
                this.UnpaidInvoice = true;
            }
            else if (SharedValues.getValue == "InvoiceTabTrue")
            {
                this.CustomerStatementTrue = true;
                this.InvoiceTabTrue = true;
            }
            else if (SharedValues.getValue == "PaymentTabTrue")
            {
                this.CustomerStatementTrue = true;
                this.PaymentTabTrue = true;
            }
            else if (SharedValues.getValue == "CreditPaidDays")
            {
                this.CustomerStatementTrue = true;
                this.CreditPaidDays = true;
            }
            else
            {
                this.UnpaidInvoice = true;
            }
        }
    }
}
