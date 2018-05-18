using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using SASClient.Accounts.Views;
using SASClient.CloseRequest;
using SDN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Accounts.ViewModel
{
    public  class AccountsDetailsTabViewModel : AccountsDetailsTabEntity
    {
        #region "private property"
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        StackList listitem = new StackList();
        #endregion
        #region "public property"
        #endregion
        #region "Constructor"

        public AccountsDetailsTabViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public  AccountsDetailsTabViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.setdefaultTab();

        }
        #endregion
        #region "click command"
        private readonly DelegateCommand unpaidSalesInvoiceClickCommand = null;
        private readonly DelegateCommand unpaidPurchaseInvoiceClickCommand = null;
        private readonly DelegateCommand undeliveredSalesOrdersWithDepositsClickCommand = null;
        private readonly DelegateCommand undeliveredPurchaseOrdersWithDepositsClickCommand = null;
        private readonly DelegateCommand stockClickCommand = null;
        #endregion
        #region "click command definition"
        public DelegateCommand UnpaidSalesInvoiceClickCommand
        {
            get
            {
                return (this.unpaidSalesInvoiceClickCommand ?? new DelegateCommand(this.UnpaidSalesInvoiceView));
            }
        }
        public DelegateCommand UnpaidPurchaseInvoiceClickCommand
        {
            get
            {
                return (this.unpaidPurchaseInvoiceClickCommand ?? new DelegateCommand(this.UnpaidPurchaseInvoiceView));
            }
        }
        public DelegateCommand UndeliveredSalesOrdersWithDepositsClickCommand
        {
            get
            {
                return (this.undeliveredSalesOrdersWithDepositsClickCommand ?? new DelegateCommand(this.UndeliveredSalesOrdersWithDepositsView));
            }
        }
        public DelegateCommand UndeliveredPurchaseOrdersWithDepositsClickCommand
        {
            get
            {
                return (this.undeliveredPurchaseOrdersWithDepositsClickCommand ?? new DelegateCommand(this.UndeliveredPurchaseOrdersWithDepositsView));
            }
        }
        public DelegateCommand StockClickCommand
        {
            get
            {
                return (this.stockClickCommand ?? new DelegateCommand(this.StockView));
            }
        }
        #endregion
        #region "view definition"
        public void  UnpaidSalesInvoiceView()
        {

            SharedValues.ViewName = "Unpaid Sales Invoice";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "UnpaidSalesInvoiceTab";
            var view = ServiceLocator.Current.GetInstance<UnpaidSalesInvoiceView>();
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Previous Accounting System Closing Balances");
            }
            else
            {
                
            }
        }
        public void UnpaidPurchaseInvoiceView()
        {
            SharedValues.ViewName = "Unpaid Purchase Invoice";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "UnpaidPurchaseInvoiceTab";
            var view = ServiceLocator.Current.GetInstance<UnpaidPurchaseInvoiceView>();
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Previous Accounting System Closing Balances");
            }
            else
            {
            }
        }
        public void UndeliveredSalesOrdersWithDepositsView()
        {
            //SharedValues.ViewName = "Undelivered Sales Orders With Deposits";
            SharedValues.ViewName = "Undelivered Sales Orders";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "UndeliveredSalesOrdersWithDepositsTab";
            var view = ServiceLocator.Current.GetInstance<UndeliveredSalesOrdersWithDepositsView>();
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Previous Accounting System Closing Balances");
            }
            else
            {
            }
        }
        public void UndeliveredPurchaseOrdersWithDepositsView()
        {
            //SharedValues.ViewName = "Undelivered Purchase Orders Deposits";
            SharedValues.ViewName = "Undelivered Purchase Orders";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "UndeliveredPurchaseOrdersWithDepositsTab";
            var view = ServiceLocator.Current.GetInstance<UndeliveredPurchaseOrdersDepositsView>();
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Previous Accounting System Closing Balances");
            }
            else
            {
            }
        }
        public void StockView()
        {
            SharedValues.ViewName = "Stock";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "StockTab";
            var view = ServiceLocator.Current.GetInstance<StockView>();
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Previous Accounting System Closing Balances");
            }
            else
            {
            }
        }
        #endregion
        #region "public method"
        private void setdefaultTab()
        {

            if (SharedValues.getValue == "UnpaidSalesInvoiceTab")
            {
                this.UnpaidSalesInvoiceTabTrue = true;
            }
            if (SharedValues.getValue == "UnpaidPurchaseInvoiceTab")
            {
                this.UnpaidPurchaseInvoiceTabTrue = true;
            }
            if (SharedValues.getValue == "UndeliveredSalesOrdersWithDepositsTab")
            {
                this.UndeliveredSalesOrdersWithDepositsTabTrue = true;
            }
            if (SharedValues.getValue == "UndeliveredPurchaseOrdersWithDepositsTab")
            {
                this.UndeliveredPurchaseOrdersWithDepositsTabTrue = true;
            }
            if (SharedValues.getValue == "StockTab")
            {
                this.StockTabTrue = true;
            }
            else
            {
                this.UnpaidSalesInvoiceTabTrue = true;
            }
            
        }
        #endregion
    }
}
