﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using SASClient.CloseRequest;
using SASClient.File.Views;
using SDN.Common;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SASClient.File.ViewModel
{
    public class FileTabViewModel : FileTabEntity
    {
        #region Private Properties
        /// <summary>
        /// The region manager
        /// </summary>
        /// 
        private readonly IRegionManager regionManager;
        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// The File details click command
        /// </summary>
        private readonly DelegateCommand FileDetailsClickCommand = null;
        StackList listitem = new StackList();
        /// <summary>
        /// The File history click command
        /// </summary>
        private readonly DelegateCommand FileHistoryClickCommand = null;

        /// <summary>
        /// The File statement click command
        /// </summary>
        private readonly DelegateCommand FileStatementClickCommand = null;

        /// <summary>
        /// The P & S Sold to File click command
        /// </summary>
        private readonly DelegateCommand pandsSoldtoFileClickCommand = null;

        /// <summary>
        /// The P & S Sold to File click command
        /// </summary>
        private readonly DelegateCommand exportDataClickCommand = null;
        private readonly DelegateCommand backupDataClickCommand = null;
        private readonly DelegateCommand restoreDataClickCommand = null;
        private readonly DelegateCommand importDataClickCommand = null;
        private readonly DelegateCommand openCompanyFileClickCommand = null;


        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the File click command.
        /// </summary>
        /// <value>
        /// The File click command.
        /// </value>
        public DelegateCommand ExportDataClickCommand
        {
            get
            {
                return (this.exportDataClickCommand ?? new DelegateCommand(this.ExportDataView));

            }
        }
        public DelegateCommand OpenCompanyFileClickCommand
        {
            get
            {
                return (this.openCompanyFileClickCommand ?? new DelegateCommand(this.OpenCompanyFileView));

            }
        }
        public DelegateCommand BackupDataClickCommand
        {
            get
            {
                return (this.backupDataClickCommand ?? new DelegateCommand(this.BackupDataView));

            }
        }
        public DelegateCommand RestoreDataClickCommand
        {
            get
            {
                   return (this.restoreDataClickCommand ?? new DelegateCommand(this.RestoreDataView));

            }
        }
        public DelegateCommand ImportDataClickCommand
        {
            get
            {
                return (this.importDataClickCommand ?? new DelegateCommand(this.ImportDataView));

            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FileTabViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public FileTabViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.setdefaultTab();
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Shows the File view.
        /// </summary>
        private void ExportDataView()
        {
            SharedValues.ScreenCheckName = "Export Data";
            SharedValues.ViewName = "Export Transaction Data";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "ExportDataTab";
            var tabview = ServiceLocator.Current.GetInstance<ExportDataView>();

            var tabregion = this.regionManager.Regions[RegionNames.MainRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var view2 = ServiceLocator.Current.GetInstance<FileTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }
            var SubTabView = ServiceLocator.Current.GetInstance<FileSubTabView>();
            var subMenuRegion = regionManager.Regions[RegionNames.SubMenuBarRegion];

            subMenuRegion.Add(SubTabView);

            if (subMenuRegion != null)
            {
                subMenuRegion.Activate(SubTabView);
            }

            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Export Data");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        private void BackupDataView()
        {
            SharedValues.ScreenCheckName = "Backup Data";
            SharedValues.ViewName = "Backup Data";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "BackupDataTab";
            var view = ServiceLocator.Current.GetInstance<BackupDataView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            var view2 = ServiceLocator.Current.GetInstance<FileTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Backup Data");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        private void RestoreDataView()
        {
            SharedValues.ScreenCheckName = "Restore Data";
            SharedValues.ViewName = "Restore Data";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "RestoreDataTab";
            var view = ServiceLocator.Current.GetInstance<RestoreDataView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            var view2 = ServiceLocator.Current.GetInstance<FileTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Restore Data ");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        private void ImportDataView()
        {
            SharedValues.ScreenCheckName = "Import Data";
            SharedValues.ViewName = "Import Data";
            var accessitem = listitem.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "ImportDataTab";
            var view = ServiceLocator.Current.GetInstance<ImportDataView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            var view2 = ServiceLocator.Current.GetInstance<FileTabView>();

            IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

            region2.Add(view2);
            if (region2 != null)
            {
                region2.Activate(view2);
            }
            //eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Import Data ");
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }
        private void OpenCompanyFileView()
        {

            //SharedValues.ViewName = "OpenCompanyFile";
            // SharedValues.getValue = "ExportDataTab";
      
            IEnumerable<object> viewlist = this.regionManager.Regions[RegionNames.MainRegion].Views;
       
          
            var view = viewlist.ElementAt(0);
        
            IRegion regiona = this.regionManager.Regions[RegionNames.MainRegion];
            //regiona.Add(l);
            if (regiona != null)
            {
                regiona.Activate(view);
               
            }
            eventAggregator.GetEvent<HeaderVisibilityChangeEvent>().Publish(false);
            eventAggregator.GetEvent<BlankHeaderVisibilityChangeEvent>().Publish(true);
            eventAggregator.GetEvent<FooterVisibilityChangeEvent>().Publish(false);
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(false);
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(false);


        }
        #endregion

        private void setdefaultTab()
        {
            if (SharedValues.getValue == "CompanyFileTab")
            {
                this.CompanyFileTabTrue = true;
            }
            else if (SharedValues.getValue == "ImportDataTab")
            {
                this.ImportDataTabTrue = true;
            }
            else if (SharedValues.getValue == "ExportDataTab")
            {
                this.ExportDataTabTrue = true;
            }
            else if (SharedValues.getValue == "BackupDataTab")
            {
                this.BackupDataTabTrue = true;
            }
            else if (SharedValues.getValue == "RestoreDataTab")
            {
                this.RestoreDataTabTrue = true;
            }
            else
            {
                this.CompanyFileTabTrue = true;
            }
        }
    }
}
