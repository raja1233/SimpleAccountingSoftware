using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Common.CloseRequest
{
    public class CloseViewRequest
    {
        public CloseViewRequest()
        {
           

        }
        public CloseViewRequest(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;

        }
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private readonly DelegateCommand receiveMoneyClickCommand = null;

        public DelegateCommand ReceiveMoneyClickCommand
        {
            get
            {
                return (this.receiveMoneyClickCommand ?? new DelegateCommand(this.ReceiveMoneyView));
            }
        }
        public void ReceiveMoneyView()
        {
            var y = regionManager.Regions[RegionNames.MainRegion].Views;
            var view = y.Reverse().Skip(1).First();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Receive Money List");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }
        public void CloseRequest(string Filename, object FullName)
        {
            try
            {
                if (!string.IsNullOrEmpty(Filename))
                {
                    switch (Filename)
                    {
                        case "CashBankStatement":
                            //var y = regionManager.Regions[RegionNames.MainRegion].Views;
                            //var view = y.Reverse().Skip(1).First();

                            var region = this.regionManager.Regions[RegionNames.MainRegion];
                            region.Add(FullName);
                            if (region != null)
                            {
                                region.Activate(FullName);
                            }
                            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Receive Money List");
                            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
                            break;
                    }
                }
                else
                {

                }
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
