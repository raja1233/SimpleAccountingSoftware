﻿using SDN.Common;
using SDN.Settings.Views;
using Microsoft.Practices.ServiceLocation;

using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Events;

using SDN.UI.Entities;
using Microsoft.Practices.Prism.Commands;
using SASClient.CloseRequest;
using System.Windows;

namespace SDN.Settings.ViewModel
{
   

    /// <summary>
    /// class SalesTabViewModel
    /// </summary>
    public sealed class SettingsTabViewModel : SettingsTabEntity
    {
        #region Private Properties
        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// The Companydetails click command
        /// </summary>
        private readonly DelegateCommand companydetailsClickCommand = null;
        StackList listitem = new StackList();
        /// <summary>
        /// The categories click command
        /// </summary>
        private readonly DelegateCommand categoriesClickCommand = null;
        /// <summary>
        /// The options click command
        /// </summary>
        private readonly DelegateCommand optionsClickCommand = null;

        /// <summary>
        /// The GST/VAT Codes And Rates Click command
        /// </summary>
        private readonly DelegateCommand taxCodesAndRatesClickCommand = null;
        private readonly DelegateCommand usersSecurityClickCommand = null;
        private readonly DelegateCommand enterTabEventCommand = null;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the Company details click command.
        /// </summary>
        /// <value>
        /// The Companydetails click command.
        /// </value>
        public DelegateCommand CompanyDetailsClickCommand
        {
            get
            {
                return (this.companydetailsClickCommand ?? new DelegateCommand(this.ShowCompanyDetailsView));
            }
        }
        /// <summary>
        /// Categories command
        /// </summary>
        public DelegateCommand CategoriesClickCommand
        {
            get
            {
                return (this.categoriesClickCommand?? new DelegateCommand(this.ShowCategoriesView));
            }
        }

        /// <summary>
        /// GST/VAT Codes and Rates
        /// </summary>
        public DelegateCommand TaxCodesAndRatesClickCommand
        {
            get
            {
                return (this.taxCodesAndRatesClickCommand ?? new DelegateCommand(this.ShowTaxCodesAndRatesView));
            }
        }

        public DelegateCommand UsersSecurityClickCommand
        {
            get
            {
                return (this.usersSecurityClickCommand ?? new DelegateCommand(this.ShowUsersSecurityView));
            }
        }

        public DelegateCommand OptionsClickCommand
        {
            get
            {
                return (this.optionsClickCommand ?? new DelegateCommand(this.ShowOptionsView));
            }
        }
        
        #endregion

        #region Constructor
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsTabViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public SettingsTabViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.setdefaultTab();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsTabViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public SettingsTabViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.setdefaultTab();
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Shows the customer view.
        /// </summary>
        private void ShowCompanyDetailsView()
        {
            SharedValues.ScreenCheckName = "Company Details";
            SharedValues.ViewName = "Company Details";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                var view = ServiceLocator.Current.GetInstance<CompanyDetailsView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Company Details");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }

        }
        private void ShowCategoriesView()
        {
            SharedValues.ScreenCheckName = "Categories";
            SharedValues.ViewName = "Categories";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                var view = ServiceLocator.Current.GetInstance<CategoryView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Categories");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        private void ShowOptionsView()
        {
            SharedValues.ScreenCheckName = "Options";
            SharedValues.ViewName = "Options";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                var view = ServiceLocator.Current.GetInstance<OptionsView>();

        /// <summary>
        /// This method is used to Show View of GST/VAT Codes and Rates
        /// </summary>
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)

            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Options");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }

        }
        private void ShowTaxCodesAndRatesView()
        {
            SharedValues.ScreenCheckName = "GST/VAT Codes & Rates";
            SharedValues.ViewName = "GST/VAT Codes and Rates";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                var view = ServiceLocator.Current.GetInstance<TaxCodesAndRatesView>();
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("GST/VAT Codes and Rates");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        private void ShowUsersSecurityView()
        {


            SharedValues.ScreenCheckName = "Users & Security";
            SharedValues.ViewName = "Users and Security";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                var view = ServiceLocator.Current.GetInstance<UsersSecurityView>();
            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Users Security");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }


        private void setdefaultTab()
        {
            if (SharedValues.getValue == "CompanyDetailsTab")
            {
                this.CompanyDetailsTabTrue = true;
            }
            else if (SharedValues.getValue == "CategoryTab")
            {
                this.CategoryTabTrue = true;
            }
            else if (SharedValues.getValue == "OptionsTab")
            {
                this.OptionsTabTrue = true;
            }
            else if (SharedValues.getValue == "CodesandRatesTab")
            {
                this.CodesandRatesTabTrue = true;
            }
            else if (SharedValues.getValue == "UsersandSecurityTab")
            {
                this.UsersandSecurityTabTrue = true;
            }
            else
            {
                this.CompanyDetailsTabTrue = true;
            }
        }


        #endregion
    }
}
