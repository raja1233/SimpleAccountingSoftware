﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.SqlServer.Management.Smo;
using SDN.Common;
using SDN.Navigation.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Data.Sql;
using Microsoft.Win32;
using Microsoft.SqlServer.Management.Smo.Wmi;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;

namespace SDN.Navigation.ViewModel 
{
    public class OpenCompanyFileViewModel : ViewModelBase
    {
        #region private properties
        private readonly IRegionManager regionManager;
        private bool isOpenCompanyFileTrue;
        private bool isNewCompanyFileTrue;
        private bool isExitTrue;
       
       

        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region public properties
        public bool IsOpenCompanyFileTrue
        {
            get
            {
                return this.isOpenCompanyFileTrue;
            }
            set
            {
                this.isOpenCompanyFileTrue = value;
                this.OnPropertyChanged("IsOpenCompanyFileTrue");
            }
        }
        public bool IsNewCompanyFileTrue
        {
            get
            {
                return this.isNewCompanyFileTrue;
            }
            set
            {
                this.isNewCompanyFileTrue = value;
                this.OnPropertyChanged("IsNewCompanyFileTrue");
            }
        }
        public bool IsExitTrue
        {
            get
            {
                return this.isExitTrue;
            }
            set
            {
                this.isExitTrue = value;
                this.OnPropertyChanged("sExitTrue");
            }
        }
        #endregion
        #region Contructor
        public OpenCompanyFileViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            SelectDBCommand = new DelegateCommand(SelectDatabase);
            CreateCompanyCommand = new DelegateCommand(NewCompany);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("");
            eventAggregator.GetEvent<HeaderVisibilityChangeEvent>().Publish(false);
            eventAggregator.GetEvent<BlankHeaderVisibilityChangeEvent>().Publish(true);
            eventAggregator.GetEvent<CompanynameChangedEvent>().Publish(" ");
            eventAggregator.GetEvent<FooterVisibilityChangeEvent>().Publish(false);
        }
        #endregion
        #region relay commands
        public ICommand CreateCompanyCommand { get; set; }
        public ICommand SelectDBCommand { get; set; }

        #endregion
        #region Button Commands
        
        public void SelectDatabase()
        {
            
            try
            {
                var view = ServiceLocator.Current.GetInstance<OpenCompanyFileDBNameView>();
                IRegion region1 = this.regionManager.Regions[RegionNames.MainRegion];
                region1.Add(view);
                if (region1 != null)
                {
                    region1.Activate(view);
                }
                eventAggregator.GetEvent<TabVisibilityEvent>().Publish(false);
                eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            catch (Exception e)
            {

                throw e;
               
            }
                   
               
        }
        public void NewCompany()
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["SASEntitiesEDM"].ConnectionString;
            var view = ServiceLocator.Current.GetInstance<NewCompanyFileView>();
            IRegion region1 = this.regionManager.Regions[RegionNames.MainRegion];
            region1.Add(view);
            if (region1 != null)
            {
                region1.Activate(view);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
        }
    }
    #endregion
    #region public Methods

    #endregion
    #region Private Methods

    #endregion
    #region Background work
    #endregion

}
