
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.CashBank.ViewModels
{
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using SDN.Common;
    using SDN.CashBank.Views;
    using UI.Entities;
    using Purchasing.View;
    using Sales.Views;
    using SASClient.CashBank.Views;
    using SASClient.CloseRequest;
    using System.Windows;

    public class CashAndBankTabViewModel:CashAndBankTabEntity
    {
        #region "Private members"

        public CashAndBankTabViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

        }
        public CashAndBankTabViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.setdefaultTab();
        }
        StackList listitem = new StackList();
        private readonly IRegionManager regionManager;

        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// The Companydetails click command
        /// </summary>
        private readonly DelegateCommand refundFromSupplierClickCommand = null;
        private readonly DelegateCommand cashBankStatementClickCommand = null;
        private readonly DelegateCommand refundToCustomerClickCommand = null;
        private readonly DelegateCommand payMoneyClickCommand = null;
        private readonly DelegateCommand receiveMoneyClickCommand = null;
        private readonly DelegateCommand transferMoneyClickCommand = null;


        #endregion

        #region "Public properties"

        /// <summary>
        /// Gets the Company details click command.
        /// </summary>
        /// <value>
        /// The Companydetails click command.
        /// </value>
        public DelegateCommand RefundFromSupplierClickCommand
        {
            get
            {
                return (this.refundFromSupplierClickCommand ?? new DelegateCommand(this.ShowRefundFromSupplierView));
            }
        }
        public DelegateCommand CashBankStatementClickCommand
        {
            get
            {
                return (this.cashBankStatementClickCommand ?? new DelegateCommand(this.CashBankStatementView));
            }
        }
        public DelegateCommand RefundToCustomerClickCommand
        {
            get
            {
                return (this.refundToCustomerClickCommand ?? new DelegateCommand(this.ShowRefundToCustomerView));
            }
        }

        public DelegateCommand PayMoneyClickCommand
        {
            get
            {
                return (this.payMoneyClickCommand ?? new DelegateCommand(this.PayMoneyView));
            }
        }

        public DelegateCommand ReceiveMoneyClickCommand
        {
            get
            {
                return (this.receiveMoneyClickCommand ?? new DelegateCommand(this.ReceiveMoneyView));
            }
        }
        public DelegateCommand TransferMoneyClickCommand
        {
            get
            {
                return (this.transferMoneyClickCommand ?? new DelegateCommand(this.TransferMoneyView));
            }
        }
        #endregion

        #region "Private Methods"


         public void CashBankStatementView()
        {
            SharedValues.ScreenCheckName = "Cash & Bank Statement";
            SharedValues.ViewName = "Cash & Bank Statement";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "CashBankStatementTab";
            var view = ServiceLocator.Current.GetInstance<CashBankStatement>();

            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Cash & Bank Statement");
                //var x = view.GetType().Name;
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }
        public void ShowRefundToCustomerView()
        {
            SharedValues.ScreenCheckName = "Refund To Customer";
            SharedValues.ViewName = "Refund To Customers List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "RefundToCustomerTab";
            var view = ServiceLocator.Current.GetInstance<RefundToCustomersListView>();

            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund To Customers List");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        public void PayMoneyView()
        {
            SharedValues.ScreenCheckName = "Pay Money";
            SharedValues.ViewName = "Pay Money List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "PayMoneyTab";
            var view = ServiceLocator.Current.GetInstance<PayMoneyListView>();

            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Pay Money List");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        public void ReceiveMoneyView()
        {
            SharedValues.ScreenCheckName = "Recieve Money";
            SharedValues.ViewName = "Receive Money List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "ReceiveMoneyTab";
            var view = ServiceLocator.Current.GetInstance<ReceiveMoneyListView>();

            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Receive Money List");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        public void TransferMoneyView()
        {
            SharedValues.ScreenCheckName = "Transfer Money";
            SharedValues.ViewName = "Transfer Money List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "TransferMoneyTab";
            var view = ServiceLocator.Current.GetInstance<TransferMoneyListView>();

            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Transfer Money List");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        public void ShowRefundFromSupplierView()
        {
            SharedValues.ScreenCheckName = "Refund to Supplier";
            SharedValues.ViewName = "Refund to Supplier List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "RefundFromSupplierTab";
            var view = ServiceLocator.Current.GetInstance<RefundFromSuppliersListView>();

            //var region = this.regionManager.Regions[RegionNames.MainRegion];
            //region.Add(view);
            //if (region != null)
            //{
            //    region.Activate(view);
            //}
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund From Suppliers List");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }


        #endregion
        private void setdefaultTab()
        {
            if(SharedValues.getValue == "CashBankStatementTab")
            {
                this.CashBankStatementTabTrue = true;
            }
            if (SharedValues.getValue == "RefundFromSupplierTab")
            {
                this.RefundFromSupplierTabTrue = true;
            }
            if (SharedValues.getValue == "RefundToCustomerTab")
            {
                this.RefundToCustomerTabTrue = true;
            }
            if (SharedValues.getValue == "ReceiveMoneyTab")
            {
                this.ReceiveMoneyTabTrue = true;
            }
            if (SharedValues.getValue == "PayMoneyTab")
            {
                this.PayMoneyTabTrue = true;
            }
            if (SharedValues.getValue == "TransferMoneyTab")
            {
                this.TransferMoneyTabTrue = true;
            }
            
        }
    }
}
