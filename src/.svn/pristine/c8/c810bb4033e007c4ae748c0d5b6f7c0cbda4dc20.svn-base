
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace SDN.SimpleAccounting
{
    using MahApps.Metro;
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //// get the current app style (theme and accent) from the application
            //// you can then use the current theme and custom accent instead set a new theme
            //Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            //// now set the Green accent and dark theme
            //ThemeManager.ChangeAppStyle(Application.Current,
            //                            ThemeManager.GetAccent("White"),
            //                            ThemeManager.GetAppTheme("BaseLight")); // or appStyle.Item1

            // add custom accent and theme resource dictionaries to the ThemeManager
            // you should replace MahAppsMetroThemesSample with your application name
            // and correct place where your custom accent lives
            //ThemeManager.AddAccent("CustomStyle", new Uri("pack://application:,,,/MahApps.Metro;component/Styles/Accents/CustomStyle.xaml"));

            ThemeManager.AddAppTheme("CustomStyle", new Uri("pack://application:,,,/SDN.SimpleAccounting;component/Resources/CustomStyle.xaml"));

            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("CustomStyle"));

            base.OnStartup(e);
            SDNBootStrapper strapper = new SDNBootStrapper();
            strapper.Run();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
            : base()
        {
            this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;
            System.Windows.FrameworkCompatibilityPreferences.KeepTextBoxDisplaySynchronizedWithTextProperty = false;
        }

        /// <summary>
        /// Called when [dispatcher unhandled exception].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Threading.DispatcherUnhandledExceptionEventArgs"/> instance containing the event data.</param>
        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string errorMessage = string.Format("An unhandled exception occurred: {0}", e.Exception.Message);
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }

    }
}
