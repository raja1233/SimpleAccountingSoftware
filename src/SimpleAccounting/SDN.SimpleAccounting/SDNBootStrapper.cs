using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using SDN.Manufacturing;
using SDN.Purchasing;
//using SDN.Sales.BL;
//using SDN.Sales.BLInterface;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace SDN.SimpleAccounting
{
    /// <summary>
    /// Boot Strapper class responsible for initialization of an Application
    /// </summary>
    public class SDNBootStrapper : UnityBootstrapper
    {
        /// <summary>
        /// Creates the SimpleAccounting.
        /// </summary>
        /// <returns></returns>
        protected override System.Windows.DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<SimpleAccounting>();
        }

        /// <summary>
        /// Initializes the SimpleAccounting.
        /// </summary>
        protected override void InitializeShell()
        {
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures the module catalog.
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
           /*
            * The ModuleCatalog class holds information about th  modules that can be used by the applicaiton.
            * ModuleInfo class tha records the name, type, and location, among the attributes on of the module.
            */

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(SDN.Navigation.NavigationModule));

            Type moduleCType = typeof(SDN.Sales.SalesModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleCType.Name,
                ModuleType = moduleCType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });

            Type moduleCType2 = typeof(SDN.Purchasing.PurchasingModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleCType2.Name,
                ModuleType = moduleCType2.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });

            Type moduleCType3 = typeof(SDN.Manufacturing.ManufacturingModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleCType3.Name,
                ModuleType = moduleCType3.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });

            Type moduleCType4 = typeof(SDN.Settings.SettingsModule
                );
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleCType4.Name,
                ModuleType = moduleCType4.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });
        }

        /// <summary>
        /// A container to Configures and injecting the required dependencies and services.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }
    }
}
