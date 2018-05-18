using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using SDN.Purchasing.ViewModel;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SDN.Purchasing.View
{
    /// <summary>
    /// Interaction logic for SupplierDetailView.xaml
    /// </summary>
    public partial class SupplierDetailView : UserControl
    {
        string suppid = "";
        private SupplierDetailViewModel _supVewModel;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private List<Country> dataSource = new List<Country>();
        private List<State> dataSourceState = new List<State>();
        private List<City> dataSourceCity = new List<City>();
        private List<Country> dataSourceShiping = new List<Country>();
        private List<State> dataSourceStateShiping = new List<State>();
        private List<City> dataSourceCityShiping = new List<City>();
        private List<PostalCode> dataSourcePostalCode = new List<PostalCode>();

        public SupplierDetailView(SupplierDetailViewModel model)
        {
            InitializeComponent();
            DataContext = model;
            
            _supVewModel = new SupplierDetailViewModel(regionManager, eventAggregator);
            dataSource = _supVewModel.AutoFillCountry();
            dataSourceState = _supVewModel.AutoFillState();
            dataSourceCity = _supVewModel.AutoFillCity();
            dataSourcePostalCode = _supVewModel.AutoFillPostalCode();
            dataSourceShiping.AddRange(dataSource);
            dataSourceStateShiping.AddRange(dataSourceState);
            dataSourceCityShiping.AddRange(dataSourceCity);
        }
   
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void FaxValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9 -]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void PhoneValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9 -]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        protected void autoBillingCountry_PatternChanged(object sender, SDN.Common.AutoComplete.AutoCompleteArgs args)
        {
            //check
            if (string.IsNullOrEmpty(args.Pattern))
                args.CancelBinding = true;
            else
            {
                args.DataSource = this.GetCountries(args.Pattern);

            }
        }

        /// <summary>
        /// occurs when the user stops typing after a delayed timespan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void autoBillingState_PatternChanged(object sender, SDN.Common.AutoComplete.AutoCompleteArgs args)
        {
            //check
            if (string.IsNullOrEmpty(args.Pattern))
                args.CancelBinding = true;
            else
            {
                args.DataSource = this.GetStates(args.Pattern);

            }
        }

        /// <summary>
        /// occurs when the user stops typing after a delayed timespan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void autoBillingCity_PatternChanged(object sender, SDN.Common.AutoComplete.AutoCompleteArgs args)
        {
            //check
            if (string.IsNullOrEmpty(args.Pattern))
                args.CancelBinding = true;
            else
            {
                args.DataSource = this.GetCities(args.Pattern);

            }
        }
        /// <summary>
        /// occurs when the user stops typing after a delayed timespan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void autoBillingPostalCode_PatternChanged(object sender, SDN.Common.AutoComplete.AutoCompleteArgs args)
        {
            //check
            if (string.IsNullOrEmpty(args.Pattern))
                args.CancelBinding = true;
            else
            {
                args.DataSource = this.GetPostalCode(args.Pattern);

            }
        }


        /// <summary>
        /// occurs when the user stops typing after a delayed timespan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void autoShippingCountry_PatternChanged(object sender, SDN.Common.AutoComplete.AutoCompleteArgs args)
        {
            //check
            if (string.IsNullOrEmpty(args.Pattern))
                args.CancelBinding = true;
            else
            {
                args.DataSource = this.GetCountries(args.Pattern);

            }
        }
        /// <summary>
        /// occurs when the user stops typing after a delayed timespan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void autoShippingState_PatternChanged(object sender, SDN.Common.AutoComplete.AutoCompleteArgs args)
        {
            //check
            if (string.IsNullOrEmpty(args.Pattern))
                args.CancelBinding = true;
            else
            {
                args.DataSource = this.GetStates(args.Pattern);

            }
        }
        /// <summary>
        /// occurs when the user stops typing after a delayed timespan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void autoShippingCity_PatternChanged(object sender, SDN.Common.AutoComplete.AutoCompleteArgs args)
        {
            //check
            if (string.IsNullOrEmpty(args.Pattern))
                args.CancelBinding = true;
            else
            {
                args.DataSource = this.GetCities(args.Pattern);

            }
        }
        /// <summary>
        /// Get a list of cities that follow a pattern
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<Country> GetCountries(string Pattern)
        {

            Country Default = new Country { CountryID = 0, Name = Pattern };

            var countryObj = new ObservableCollection<Country>(
                this.dataSource.
                Where((country, match) => country.Name.ToLower().StartsWith(Pattern.ToLower())));
            if (countryObj == null)
            {
                return new ObservableCollection<Country>(
                this.dataSource.
                Where((country, match) => Pattern.StartsWith(Pattern.ToLower())));
            }
            return countryObj;
        }
        /// <summary>
        /// Get the list of states that follow the pattern
        /// </summary>
        /// <param name="Pattern"></param>
        /// <returns></returns>
        private ObservableCollection<State> GetStates(string Pattern)
        {

            State Default = new State { StateID = 0, Name = Pattern };

            var stateObj = new ObservableCollection<State>(
                this.dataSourceState.
                Where((state, match) => state.Name.ToLower().StartsWith(Pattern.ToLower())));
            if (stateObj == null)
            {
                return new ObservableCollection<State>(
                this.dataSourceState.
                Where((state, match) => Pattern.StartsWith(Pattern.ToLower())));
            }
            return stateObj;
        }
        /// <summary>
        /// Get a list of cities that follow a pattern
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<City> GetCities(string Pattern)
        {

            City Default = new City { CityID = 0, Name = Pattern };

            var cityObj = new ObservableCollection<City>(
                this.dataSourceCity.
                Where((city, match) => city.Name.ToLower().StartsWith(Pattern.ToLower())));
            if (cityObj == null)
            {
                return new ObservableCollection<City>(
                this.dataSourceCity.
                Where((city, match) => Pattern.StartsWith(Pattern.ToLower())));
            }
            return cityObj;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pattern"></param>
        /// <returns></returns>
        private ObservableCollection<PostalCode> GetPostalCode(string Pattern)
        {

            PostalCode Default = new PostalCode { PostalCodeID = 0, Name = Pattern };

            var postalCodeObj = new ObservableCollection<PostalCode>(
                this.dataSourcePostalCode.
                Where((postalcode, match) => postalcode.Name.ToLower().StartsWith(Pattern.ToLower())));
            if (postalCodeObj == null)
            {
                return new ObservableCollection<PostalCode>(
                this.dataSourcePostalCode.
                Where((postalcode, match) => Pattern.StartsWith(Pattern.ToLower())));
            }
            return postalCodeObj;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtSupplierName.Focus();
        }
    }
}
