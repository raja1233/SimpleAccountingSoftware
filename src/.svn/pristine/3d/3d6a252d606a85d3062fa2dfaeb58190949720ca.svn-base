namespace SDN.Product
{
    using SDN.Common;
    using SDN.Product.View;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
   using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using SDN.Product.Services;
    /// <summary>
    /// Product Module class
    /// </summary>
    public class ProductModule : IModule
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
     /// Product Module
     /// </summary>
     /// <param name="container"></param>
     /// <param name="regionManage"></param>
        public ProductModule(IUnityContainer container, IRegionManager regionManage)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        #endregion 

        #region Public Method
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        { //types of dependencies need to be registered with the container.
            this.container.RegisterType<IPandSDetailsRepository, PandSDetailsRepository>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IPandSDescriptionListRepository, PandSDescriptionListRepository>(new ContainerControlledLifetimeManager());

            this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion,
                () => ServiceLocator.Current.GetInstance<PandSDetailsView>());
            this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion,
                () => ServiceLocator.Current.GetInstance<PandSDescriptionListView>());

            this.regionManager.RegisterViewWithRegion(RegionNames.MenuBarRegion,
               () => ServiceLocator.Current.GetInstance<ProductTabView>());

            this.regionManager.RegisterViewWithRegion(RegionNames.SubMenuBarRegion,
               () => ServiceLocator.Current.GetInstance<PandSSubTabView>());
        }
        #endregion
    }
}
