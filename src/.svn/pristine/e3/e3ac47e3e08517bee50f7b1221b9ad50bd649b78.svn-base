
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.ViewModel
{
    using Common;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using SASClient.CloseRequest;
    using SASClient.Product.View;
    using System.Windows;
    using UI.Entities.Product;
    using View;

    public class ProductTabViewModel : ProductTabEntity
    {
        #region "Private members"

        public ProductTabViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

        }
        public ProductTabViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
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
        private readonly DelegateCommand pandsDetailsClickCommand = null;
        private readonly DelegateCommand pandsHistoryClickCommand = null;
        private readonly DelegateCommand stockInOutCardClickCommand = null;
        private readonly DelegateCommand countandAdjustListClickCommand = null;
        private readonly DelegateCommand pandSSoldClickCommand = null;
        private readonly DelegateCommand pandSPurchaseClickCommand = null;
        private readonly DelegateCommand topPandSClickCommand = null;
        StackList listitem = new StackList();

        #endregion

        #region "Public properties"

        /// <summary>
        /// Gets the Company details click command.
        /// </summary>
        /// <value>
        /// The Companydetails click command.
        /// </value>

        public DelegateCommand CountandAdjustListClickCommand
        {
            get
            {
                return (this.countandAdjustListClickCommand ?? new DelegateCommand(this.ShowCountAndAdjustStockListView));
            }
        }

        public DelegateCommand PandSDetailsClickCommand
        {
            get
            {
                return (this.pandsDetailsClickCommand ?? new DelegateCommand(this.ShowPandSDescriptionView));
            }
        }
        public DelegateCommand PandSSoldClickCommand
        {
            get
            {
                return (this.pandSSoldClickCommand ?? new DelegateCommand(this.PandSSoldView));
            }
        }


        public DelegateCommand PandSPurchaseClickCommand
        {
            get
            {
                return (this.pandSPurchaseClickCommand ?? new DelegateCommand(this.PandSPurchaseView));
            }
        }
        public DelegateCommand TopPandSClickCommand
        {
            get
            {
                return (this.topPandSClickCommand ?? new DelegateCommand(this.TopPandSView));
            }
        }
        public DelegateCommand PandSHistoryClickCommand
        {
            get
            {
                return (this.pandsHistoryClickCommand ?? new DelegateCommand(this.ShowPandSHistoryView));
            }
        }
        public DelegateCommand StockInOutCardClickCommand
        {
            get
            {
                return (this.stockInOutCardClickCommand ?? new DelegateCommand(this.StockInOutTabView));
            }
        }
        #endregion

        #region "Private Methods"

        public void ShowCountAndAdjustStockListView()
        {
            SharedValues.ScreenCheckName = "Count & Adjust Stock";
            SharedValues.ViewName = "Count And Adjust Stock List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "CountandAdjustStockTab";
            var view = ServiceLocator.Current.GetInstance<CountAndAdjustStockListView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Count and Adjust Stock List");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        public void PandSSoldView()
        {
            SharedValues.ScreenCheckName = "P & S Sold";
            SharedValues.ViewName = "P & S Sold";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "PSSoldTab";
            var view = ServiceLocator.Current.GetInstance<PandSSoldView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("P & S Sold");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        public void PandSPurchaseView()
        {
            SharedValues.ScreenCheckName = "P & S Purchased";
            SharedValues.ViewName = "P & S Purchased";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "PSPurchasedTab";
            var view = ServiceLocator.Current.GetInstance<PandSPurchaseView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("P & S Purchased");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        public void ShowPandSDescriptionView()
        {
            SharedValues.ScreenCheckName = "P & S Details List";
            SharedValues.ViewName = "P&S Details (Description) List";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "PSDetailsTab";
            var view = ServiceLocator.Current.GetInstance<PandSDescriptionListView>();
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }

            var view2 = ServiceLocator.Current.GetInstance<ProductTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products & Services Details List");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        public void TopPandSView()
        {
            SharedValues.ScreenCheckName = "Top Products & Services";
            SharedValues.ViewName = "Top Products & Services";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "TopPSTab";
            var view = ServiceLocator.Current.GetInstance<TopPandSView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Top P & S");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }
        public void ShowPandSHistoryView()
        {
            SharedValues.ScreenCheckName = "P&S History";
            SharedValues.ViewName = "P&S History";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "PSHistoryTab";
            var view = ServiceLocator.Current.GetInstance<PandSHistoryView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("P & S History");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.");
            }
        }

        public void StockInOutTabView()
        {
            SharedValues.ScreenCheckName = "Stock in/out card";
            SharedValues.ViewName = "Stock in/out card";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "StockInOutCardTab";
            var view = ServiceLocator.Current.GetInstance<PandSStockCardView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Stock In/Out Card");
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
            if (SharedValues.getValue == "PSDetailsTab")
            {
                this.PSDetailsTabTrue = true;
                
            }
            else if (SharedValues.getValue == "PSHistoryTab")
            {
                this.PSHistoryTabTrue = true;
            }
            else if(SharedValues.getValue == "StockInOutCardTab")
            {
                this.StockInOutCardTabTrue = true;
            }
            else if (SharedValues.getValue == "CountandAdjustStockTab")
            {
                this.CountandAdjustStockTabTrue = true;
            }
            else if(SharedValues.getValue == "PSSoldTab")
            {
                this.PSSoldTabTrue = true;
            }
            else if (SharedValues.getValue == "PSPurchasedTab")
            {
                this.PSPurchasedTabTrue = true;
            }
            else if(SharedValues.getValue == "TopPSTab")
            {
                this.TopPSTabTrue = true;
            }
            else
            {
                this.PSDetailsTabTrue = true;
            }
        }
    }
}
