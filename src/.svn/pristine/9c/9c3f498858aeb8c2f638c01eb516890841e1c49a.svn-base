
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

        public DelegateCommand  PandSDetailsClickCommand 
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


        #endregion

        #region "Private Methods"

        public void ShowCountAndAdjustStockListView()
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
        public void PandSSoldView()
        {
            SharedValues.getValue = "PSSoldTab";
            var view = ServiceLocator.Current.GetInstance<PandSSoldView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products & Services Sold");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }
        public void PandSPurchaseView()
        {
            SharedValues.getValue = "PSPurchaseTab";
            var view = ServiceLocator.Current.GetInstance<PandSPurchaseView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products & Services Purchased");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }

        public void ShowPandSDescriptionView()
        {
             
                SharedValues.getValue = "PSDescriptionTab";
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
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Products and Services Details List - Description");
        }

        public void TopPandSView()
        {
            SharedValues.getValue = "TopPSTab";
            var view = ServiceLocator.Current.GetInstance<TopPandSView>();


            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Top Products & Services");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }

        #endregion
        private void setdefaultTab()
        {
            if (SharedValues.getValue == "PSDetailsTab" || SharedValues.getValue== "PSDescriptionTab")
            {
                this.PSDetailsTabTrue = true;
            }
            else if (SharedValues.getValue == "PSHistoryTab")
            {
                this.PSHistoryTabTrue = true;
            }
            else if (SharedValues.getValue == "StockInOutCardTab")
            {
                this.StockInOutCardTabTrue = true;
            }
            else if (SharedValues.getValue == "CountandAdjustStockTab")
            {
                this.CountandAdjustStockTabTrue = true;
            }
            else if (SharedValues.getValue == "PSSoldTab")
            {
                this.PSSoldTabTrue = true;
            }
            else if (SharedValues.getValue == "PSPurchasedTab")
            {
                this.PSPurchasedTabTrue = true;
            }
            else if (SharedValues.getValue == "TopPSTab")
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
