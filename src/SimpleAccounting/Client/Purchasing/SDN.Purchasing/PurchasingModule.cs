namespace SDN.Purchasing
{
    using SDN.Common;
    using SDN.Purchasing.View;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Services;

    /// <summary>
    /// Purchasing Module class
    /// </summary>
    public class PurchasingModule : IModule
    {
        #region Private Properties
        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// The container
        /// </summary>
        private readonly IUnityContainer container;
        #endregion Private Properties

        #region Constructor
      
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchasingModule"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="container">The container.</param>
        public PurchasingModule(RegionManager regionManager, UnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }
      
        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            //types of dependencies need to be registered with the container.
            this.container.RegisterType<IPurchaseQuotationRepository, PurchaseQuotationRepository>(new ContainerControlledLifetimeManager());

            // Resolving Instances with Unity
            this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion,
                 () => this.container.Resolve<PurchaseQuotationListView>());

            //Resolving Instances with Unity
            this.regionManager.RegisterViewWithRegion(RegionNames.MenuBarRegion,
                 () => this.container.Resolve<PurchaseTabView>());
        }

        #endregion Public Methods
    }
}
