
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Settings
{
    using SDN.Common;
    using SDN.Settings.Views;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

   public  class SettingsModule : IModule
    {
        
        #region Private Properties
            /// <summary>
            /// The region manager
            /// </summary>
        private readonly IRegionManager regionManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductModule"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public SettingsModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #endregion 

        #region Public Method
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion,
                () => ServiceLocator.Current.GetInstance<SettingsView>());

            //this.regionManager.RegisterViewWithRegion(RegionNames.MenuBarRegion,
            //   () => ServiceLocator.Current.GetInstance<ProductTabView>());
        }
        #endregion
    }

}
