using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using SASClient.CloseRequest;
using SASClient.File.Views;
using SDN.Common;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SASClient.File.ViewModel
{
    public class FileSubTabViewModel : FileTabEntity
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
        /// The File details click command
        /// </summary>
        private readonly DelegateCommand FileDetailsClickCommand = null;

        /// <summary>
        /// The File history click command
        /// </summary>
        private readonly DelegateCommand FileHistoryClickCommand = null;
        StackList itemlist = new StackList();
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
        private readonly DelegateCommand masterClickCommand = null;
        private readonly DelegateCommand transactionClickCommand = null;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the File click command.
        /// </summary>
        /// <value>
        /// The File click command.
        /// </value>
        //public DelegateCommand MasterClickCommand
        //{
        //    get
        //    {
        //        return (this.masterClickCommand ?? new DelegateCommand(this.MasterView));

        //    }
        //}
        public DelegateCommand TransactionClickCommand
        {
            get
            {
                return (this.transactionClickCommand ?? new DelegateCommand(this.TransactionView));

            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSubTabViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public FileSubTabViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
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
        //private void MasterView()
        //{
        //    SharedValues.ScreenCheckName = "Export Data";
        //    SharedValues.ViewName = "Export Master Data";
        //    var accessitem = itemlist.AddToList();
        //    if (accessitem == true)
        //    {
        //        SharedValues.getValue = "ExportDataMasterTabTrue";
        //    var view = ServiceLocator.Current.GetInstance<ExportDataMasterView>();

        //    var region = this.regionManager.Regions[RegionNames.MainRegion];
        //    region.Add(view);
        //    if (region != null)
        //    {
        //        region.Activate(view);
        //    }
        //    eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
        //    eventAggregator.GetEvent<TitleChangedEvent>().Publish("Exprot Data");
        //    }
        //    else
        //    {
        //        MessageBox.Show("This screen is not accessible for current user");
        //    }
        //}
        private void TransactionView()
        {
            SharedValues.ViewName = "Export Data";
            SharedValues.ViewName = "Export Transaction Data";
            var accessitem = itemlist.AddToList();
            if (accessitem == true)
            {
                SharedValues.getValue = "ExportDataTransactionTabTrue";
            var view = ServiceLocator.Current.GetInstance<ExportDataView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
            eventAggregator.GetEvent<SubTabVisibilityEvent>().Publish(true);
            eventAggregator.GetEvent<TitleChangedEvent>().Publish("Exprot Data");
            }
            else
            {
                MessageBox.Show("You do not have access to this screen. Please contact your Administrator.\n"+"@ Simple Accounting Software Pte Ltd");
            }
        }


        private void setdefaultTab()
        {
            if (SharedValues.getValue == "ExportDataTransactionTabTrue")
            {
                this.ExportDataTabTrue = true;
                this.ExportDataTransactionTabTrue = true; 
            }
            if (SharedValues.getValue == "ExportDataMasterTabTrue")
            {
                this.ExportDataTabTrue = true;
                this.ExportDataMasterTabTrue = true;
            }
        }

            #endregion


        }
    }
