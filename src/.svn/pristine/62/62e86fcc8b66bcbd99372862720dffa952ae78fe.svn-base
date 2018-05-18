namespace SDN.SimpleAccounting
{
    using SDN.Common;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.Commands;
    using Navigation.View;

    /// <summary>
    /// SimpleAccountingViewModel class
    /// </summary>
    public class SimpleAccountingViewModel : ViewModelBase
    {
        #region Private Properties
        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        private readonly IRegionManager regionManager;

        private readonly DelegateCommand homeClickCommand = null;
        private string title;
        /// <summary>
        /// The is menu region visible
        /// </summary>
        private bool isMenuRegionVisible;
        private bool isSubMenuRegionVisible;
        #endregion

        #region Public Properties

        public DelegateCommand HomeClickCommand
        {
            get
            {
                return (this.homeClickCommand ?? new DelegateCommand(this.ShowMainView));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is menu region visible.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is menu region visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsMenuRegionVisible
        {
            get
            {
                return this.isMenuRegionVisible;
            }
            set
            {
                this.isMenuRegionVisible = value;
                this.OnPropertyChanged("IsMenuRegionVisible");
            }
        }
        public bool IsSubMenuRegionVisible
        {
            get
            {
                return this.isSubMenuRegionVisible;
            }
            set
            {
                this.isSubMenuRegionVisible = value;
                this.OnPropertyChanged("IsSubMenuRegionVisible");
            }
        }
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                this.OnPropertyChanged("Title");
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleAccountingViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public SimpleAccountingViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.IsMenuRegionVisible = false;
            this.IsSubMenuRegionVisible = false;
            this.Title = "Simple Accounting Software";       
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<TabVisibilityEvent>().Subscribe(MenuRegionVisible);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Subscribe(SubMenuRegionVisible);
            eventAggregator.GetEvent<TitleChangedEvent>().Subscribe(TitleChanged);
        }
        #endregion

        #region Private Methods
        private void MenuRegionVisible(bool isVisible)
        {
            this.IsMenuRegionVisible = isVisible;
            this.OnPropertyChanged("IsMenuRegionVisible");
        }
        private void SubMenuRegionVisible(bool isVisible)
        {
            this.IsSubMenuRegionVisible = isVisible;
            this.OnPropertyChanged("IsSubMenuRegionVisible");
        }
        private void TitleChanged(string title)
        {
            this.Title = title;
            this.OnPropertyChanged("Title");
        }
        private void ShowMainView()
        {
            var view = ServiceLocator.Current.GetInstance<MainView>();

            IRegion region1 = this.regionManager.Regions[RegionNames.MainRegion];
            region1.Add(view);
            if (region1 != null)
            {
                region1.Activate(view);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Home");
        }
        #endregion
    }
}
