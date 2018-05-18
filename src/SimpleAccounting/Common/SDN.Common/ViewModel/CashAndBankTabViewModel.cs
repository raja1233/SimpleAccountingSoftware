using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Common.ViewModel
{
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Model;

    public class CashAndBankTabViewModel: CashAndBankTabEntity
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
        private readonly IRegionManager regionManager;

        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// The Companydetails click command
        /// </summary>
        private readonly DelegateCommand refundFromSupplierClickCommand = null;
        private readonly DelegateCommand refundToCustomerClickCommand = null;

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

        public DelegateCommand RefundToCustomerClickCommand
        {
            get
            {
                return (this.refundToCustomerClickCommand ?? new DelegateCommand(this.ShowRefundToCustomerView));
            }
        }

        #endregion

        #region "Private Methods"

        public void ShowRefundToCustomerView()
        {

        }
         public void ShowRefundFromSupplierView()
        {
            //SharedValues.getValue = "PurchaseQuotationTab";
            //var view = ServiceLocator.Current.GetInstance<RefundFromSuppliersListView>();

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
            //eventAggregator.GetEvent<TitleChangedEvent>().Publish("Refund From Suppliers List");
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }
    

        #endregion
        private void setdefaultTab()
        {
            if (SharedValues.getValue == "RefundFromSupplierTab")
            {
                this.RefundFromSupplierTabTrue = true;
            }
            else if (SharedValues.getValue == "RefundToCustomerTab")
            {
                this.RefundToCustomerTabTrue = true;
            }
            else
            {
                this.RefundFromSupplierTabTrue = true;
            }
        }
    }
}
