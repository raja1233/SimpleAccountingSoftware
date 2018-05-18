
using SDN.Common;
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
    using SDN.UI.Entities;
    using System.Windows;

    public class DetailListSubTabViewModel : SupplierTabEntity
    {
        #region "Private members"


        private readonly IRegionManager regionManager;

        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;
        StackList listitem = new StackList();
        public DetailListSubTabViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

        }
        public DetailListSubTabViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.setdefaultTab();
            //inInitializer();
        }

        /// <summary>
        /// The Companydetails click command
        /// </summary>
        private readonly DelegateCommand list1ClickCommand = null;
        private readonly DelegateCommand list2ClickCommand = null;
        private readonly DelegateCommand list3ClickCommand = null;
        private readonly DelegateCommand list4ClickCommand = null;

        #endregion

        #region "Public properties"

        /// <summary>
        /// Gets the Company details click command.
        /// </summary>
        /// <value>
        /// The Companydetails click command.
        /// </value>

        public DelegateCommand List1ClickCommand
        {
            get
            {
                return (this.list1ClickCommand ?? new DelegateCommand(this.ShowList1View));
            }
        }
        public DelegateCommand List2ClickCommand
        {
            get
            {
                return (this.list2ClickCommand ?? new DelegateCommand(this.ShowList2View));
            }
        }
        public DelegateCommand List3ClickCommand
        {
            get
            {
                return (this.list3ClickCommand ?? new DelegateCommand(this.ShowList3View));
            }
        }
        public DelegateCommand List4ClickCommand
        {
            get
            {
                return (this.list4ClickCommand ?? new DelegateCommand(this.ShowList4View));
            }
        }



        #endregion

        #region "Private Methods"

        private void ShowList1View()
        {
            SharedValues.ScreenCheckName = "Suppliers Details";
            SharedValues.ViewName = "Suppliers Details List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "SupplierDetailList1";
            var view = ServiceLocator.Current.GetInstance<SuppliersDetailsList1View>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];

            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        private void ShowList2View()
        {
            SharedValues.ScreenCheckName = "Suppliers Details";
            SharedValues.ViewName = "Supplier Balance";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "SupplierDetailList2";
            var view = ServiceLocator.Current.GetInstance<SuppliersDetailsList2View>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];

            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

        private void ShowList3View()
        {
            SharedValues.ScreenCheckName = "Suppliers Details";
            SharedValues.ViewName = "Supplier Bill To Address";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "SupplierDetailList3";
            var view = ServiceLocator.Current.GetInstance<SuppliersDetailsList3View>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];

            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }

        private void ShowList4View()
        {
            SharedValues.ScreenCheckName = "Suppliers Details";
            SharedValues.ViewName = "Supplier Ship To Address";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "SupplierDetailList4";
            var view = ServiceLocator.Current.GetInstance<SuppliersDetailsList4View>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];

            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Suppliers Details List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }



        #endregion
        private void setdefaultTab()
        {
            if (SharedValues.getValue == "SupplierDetailList1")
            {
                this.SupplierDetailTabTrue = true;
                this.SupplierDetailList1 = true;
            }
            else if (SharedValues.getValue == "SupplierDetailList2")
            {
                this.SupplierDetailList2 = true;
            }
            else if (SharedValues.getValue == "SupplierDetailList3")
            {
                this.SupplierDetailList3 = true;
            }
            else if (SharedValues.getValue == "SupplierDetailList4")
            {
                this.SupplierDetailList4 = true;
            }
            else
            {
                this.SupplierDetailList1 = true;
            }
        }

    }
}
