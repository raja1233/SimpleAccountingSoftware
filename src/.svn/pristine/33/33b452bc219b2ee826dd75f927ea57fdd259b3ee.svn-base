
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Settings.ViewModels
{
    using Common;
    using SDN.UI.Entities;
    using System.Collections.ObjectModel;
    using SDN.Settings.Services;
    using System.Windows;
    using System.Windows.Input;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.Events;
    using SASClient.CloseRequest;
    using Microsoft.Practices.Prism.Commands;

    public class TaxCodesAndRatesViewModel:ViewModelBase
    {
        #region "private members"
         ObservableCollection<TaxModel> tax;
         List<string> lstTaxName;
         private object selectedTax;     
        ITaxCodesAndRatesRepository taxCodesAndRatesRepository = new TaxCodesAndRatesRepository();
        private readonly IEventAggregator eventAggregator;
        private readonly IRegionManager regionManager;
        private string selectedTaxName;
        private List<string> _Errors;
        private TaxModel taxM = new TaxModel();
        string taxErrors = string.Empty;
        private int comboboxSelectedItem;
        StackList listitem = new StackList();
        #endregion

        #region "Constructors"

        public TaxCodesAndRatesViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;
            //instatntiate the list of strings to display static list if tax names in combobox
            lstTaxName = new List<string>();
            lstTaxName.Add("VAT");
            lstTaxName.Add("GST");
            lstTaxName.Add("ST");
            
           // taxM.ErrorsChanged += (s, e) => Errors = FlattenErrors();

            //TaxErrors = new List<string>();
            TaxSelectChangeCommand = new RelayCommand(DoSelectChange);
            NewCommand = new RelayCommand(GetNewTax);
            DeleteCommand = new RelayCommand(DeleteTax, CanDelete);
            SaveCommand = new RelayCommand(SaveTax);
            CancelCommand = new RelayCommand(DoCancel);
            SaveRowCommand = new RelayCommand(SaveTax,CanSave);
            SelectedTax = null;
            CloseCommand = new DelegateCommand(Close);
            int minHeight = 300;
            int headerRows = 260;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows -40;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.POGridHeight = minHeight;

            var tax = new ObservableCollection<TaxModel>(taxCodesAndRatesRepository.GetAllTaxes());
            if(tax!=null)
            {
                Tax = tax;
                SelectedTaxName = tax.FirstOrDefault().TaxName;
               // SelectedTax = tax.Where(e => e.IsDefault == true).SingleOrDefault();
            }
            
        }
        /// This property is used to bind taxes data source to data grid 
        /// </summary>
        public ObservableCollection<TaxModel> Tax
        {
            get
            {
                return tax;
            }
            set
            {
                tax = value;
                OnPropertyChanged("Tax");
            }
        }

        /// <summary>
        /// This property is used to bind Selected tax from data grid to textBoxes
        /// </summary>
        public object SelectedTax
        {
            get
            {
                return selectedTax;
            }
            set
            {
                selectedTax = value;
                OnPropertyChanged("SelectedTax");
            }
        }

        /// <summary>
        /// This property is used to bind the selected tax
        /// </summary>
        public int SelectedIndex
        {
            get;set;
        }

        public List<string> RowNumbers
        {
            get;set;
        }

        public int ComboBoxSelectedIndex
        {
            get { return comboboxSelectedItem; }
            set { comboboxSelectedItem = value;
                OnPropertyChanged("ComboBoxSelectedIndex");
            }
        }

        /// <summary>
        /// This property is used to bind list of string to tax name dropdown
        /// </summary>
        public List<string> TaxNameList
        {
           get
            {
                return lstTaxName;
            }
            set
            {
                lstTaxName = value;
                OnPropertyChanged("TaxNameList");
            }
        }

        /// <summary>
        /// This property is used to get selected tax Name from combobox
        /// </summary>
        public string SelectedTaxName
        {
            get
            {
                return selectedTaxName;
            }
            set
            {
                selectedTaxName = value;
                OnPropertyChanged("SelectedTaxName");
            }
        }

        public string TaxErrors
        {
           get
            {
                return taxErrors;
            }
            set
            {
                taxErrors = value;
                OnPropertyChanged("TaxErrors");
            }
        }

        /// <summary>
        /// This property is used to display errors
        /// </summary>
        public List<string> Errors
        {
            get { return _Errors; }
            set { SetProperty(ref _Errors, value); }
        }

        #endregion

        #region "Command"
        public ICommand CloseCommand { get; set; }
        public RelayCommand TaxSelectChangeCommand { get; set; }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand NewCommand { get; set; }
        
        public RelayCommand SaveRowCommand { get; set; }

        #endregion

        #region "Command Delegates

        /// <summary>
        /// This is used to do select change and display data from grid
        /// </summary>
        /// <param name="param"></param>
        void DoSelectChange(object param)
        {
            var tax = SelectedTax as TaxModel;
            TaxErrors = string.Empty;
            //if (tax != null)
            //{
            //    SelectedTaxName = tax.TaxName;
            //}
           
        }
        private void Close()
        {
            try
            {
                List<string> listview = (List<string>)Application.Current.Resources["views"];
                var secondlast = listview.AsEnumerable().Reverse().Skip(1).First();
                CloseView close = new CloseView(regionManager, eventAggregator);
                close.CloseViewRequest(secondlast, true);
                listview.RemoveAt(listview.Count - 1);
            }
            catch (Exception)
            {
                List<string> listview = (List<string>)Application.Current.Resources["views"];
                CloseView close = new CloseView(regionManager, eventAggregator);
                close.CloseViewRequest("MainView", true);
                listview.RemoveAt(listview.Count - 1);
            }
            //List<string> calledlist = stack.x();
        }
        //bool CanExecute(object param)
        //{
        //    var tax = SelectedTax as TaxModel;
        //    if (tax.TaxDescription == "GST Free")
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        /// <summary>
        /// This method is used to get new record
        /// </summary>
        /// <param name="param"></param>
        void GetNewTax(object param)
        {
            var tax = new TaxModel();
            SelectedTax = tax;
            SelectedIndex = -1;
            
            TaxErrors = string.Empty;
        }

        /// <summary>
        /// This method is used to delete the tax
        /// </summary>
        /// <param name="param"></param>
        void DeleteTax(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            ITaxOperationRepository taxRepository = new TaxOperationRepository();
            ITaxCodesAndRatesRepository tax = new TaxCodesAndRatesRepository();
            var taxModel = SelectedTax as TaxModel;

            if (taxModel != null)
            {
                if (taxModel.Predefined == false || taxModel.Predefined==null)
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to delete tax?\n"+ "@ Simple Accounting Software Pte Ltd", "Delete Tax", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)

                    {
                     var Check=   tax.IsTaxDeleted(taxModel.TaxID);
                        if (Check.Equals("1") && Check != null)
                        {
                            TaxErrors = "# GST Code cannot be deleted because it is used in transaction.";

                        }else
                        {
                            taxRepository.DeleteTax(taxModel.TaxID);
                            SelectedTax = new TaxModel();
                            Tax = new ObservableCollection<TaxModel>(tax.GetAllTaxes());

                        }
                     
                    }
                }
                else
                {
                    TaxErrors = "# GST Free cannot be deleted.";
                }
            }
            Mouse.OverrideCursor = null;
        }

        bool CanDelete(object param)
        {
            var tax = SelectedTax as TaxModel;
            if (tax != null)
            {
                if (SelectedIndex != -1 )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// This is used to save and edit tax
        /// </summary>
        /// <param name="param"></param>
        void SaveTax(object param)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            var tax = SelectedTax as TaxModel;
            if (tax != null)
            {
                SaveTax();
            }
            SaveTaxName();
            Mouse.OverrideCursor = null;
        }

        bool CanSave(object param)
        {
            //return taxM.HasErrors == false;
            //MessageBox.Show(Errors.Count.ToString());
            var tax = SelectedTax as TaxModel;
            if (tax != null)
            {
                if (tax.TaxCode != null && tax.TaxDescription != null && Convert.ToString(tax.TaxRate) != null
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This is to cancel the operation
        /// </summary>
        /// <param name="param"></param>
        void DoCancel(object param)
        {
            ITaxCodesAndRatesRepository tax = new TaxCodesAndRatesRepository();
            SelectedTax = new TaxModel() ;
            Tax = new ObservableCollection<TaxModel>(tax.GetAllTaxes());
            TaxErrors = string.Empty;
        }

        #endregion

        #region "Private methods"

        //private List<string> FlattenErrors()
        //{
        //    List<string> errors = new List<string>();
        //    Dictionary<string, List<string>> allErrors = taxM.GetAllErrors();
        //    foreach (string propertyName in allErrors.Keys)
        //    {
        //        foreach (var errorString in allErrors[propertyName])
        //        {
        //            errors.Add(errorString);
        //        }
        //    }
        //    return errors;
        //}


        private void SaveTax()
        {
            ITaxOperationRepository taxRepository = new TaxOperationRepository();
            ITaxCodesAndRatesRepository tax = new TaxCodesAndRatesRepository();
            ICompanyDetails details = new CompanyDetails();

            var taxModel = SelectedTax as TaxModel;
            if (SelectedTaxName != null)
            {
                taxModel.TaxName = SelectedTaxName;
            }

            if (taxModel != null)
            {
                TaxErrors = ValidateTaxCodesAndRates(taxModel);
                if (TaxErrors == string.Empty)
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to save changes?", "Save Tax", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        CompanyDetailsEntities compEntities = details.GetCompanyDetails();

                        if (compEntities.Comp_Reg_No == null)
                        {
                            if (taxModel.Predefined == false)
                            {
                                if (taxModel.IsDefault == true)
                                {
                                    MessageBox.Show("Your Company is not registered to collect GST/VAT.\n"+ "@ Simple Accounting Software Pte Ltd", "Warning Message", MessageBoxButton.OK);
                                }
                            }
                        }
                        else
                        {
                            if (compEntities.Comp_GST_Dereg_Date != null)
                            {
                                if (Convert.ToDateTime(compEntities.Comp_GST_Dereg_Date).Date > DateTime.Now.Date)
                                {
                                    if (taxModel.Predefined == false)
                                    {
                                        if (taxModel.IsDefault == true)
                                        {
                                            MessageBox.Show("Your Company is not registered to collect GST/VAT.\n"+ "@ Simple Accounting Software Pte Ltd", "Warning Message", MessageBoxButton.OK);
                                        }
                                    }
                                }

                            }
                        }

                        if (taxModel.Predefined == true)
                        {
                            if (taxModel.TaxRate != 0 || taxModel.IsInActive == "Y")
                            {
                                TaxErrors = "# GST Free cannot be made inactive. Description and Code can be edited but not rate.";
                                Mouse.OverrideCursor = null;
                                return;
                                
                            }
                        }

                        if (taxRepository.IsCodeAndRateExists(taxModel))
                        {
                            TaxErrors = "Tax Code should be unique";
                            Mouse.OverrideCursor = null;
                            return;
                        }
                        else
                        {
                            if (SelectedIndex == -1)
                            {
                                taxRepository.SaveTax(taxModel);
                            }
                            else
                            {
                                taxRepository.UpdateTax(taxModel);
                            }
                        }

                        //MessageBox.Show("Record Saved successfully", "Save Content", MessageBoxButton.OK);
                        Tax = new ObservableCollection<TaxModel>(tax.GetAllTaxes());
                        SelectedTax = null;
                        TaxErrors = string.Empty;
                    }
                }
            }
        }

        private void SaveTaxName()
        {
            if(!String.IsNullOrEmpty(SelectedTaxName))
            {
                ITaxOperationRepository taxRepository = new TaxOperationRepository();
                taxRepository.SaveTaxName(SelectedTaxName);

            }
        }

        public string ValidateTaxCodesAndRates(TaxModel taxModel)
        {
            StringBuilder msg = new StringBuilder();
            if (string.IsNullOrWhiteSpace(taxModel.TaxDescription)|| taxModel.TaxDescription=="")
            {
                msg.Append("Tax Description is Required.\n");
            }

            if (string.IsNullOrWhiteSpace(taxModel.TaxCode)|| taxModel.TaxCode=="")
            {
                msg.Append("Tax Code is Required.\n");
            }

            if (Convert.ToString(taxModel.TaxRate) == string.Empty)
            {
                msg.Append("Tax Rate is Required.\n");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(taxModel.TaxRate.ToString(), @"^\d+([.]\d{1,2})?%?$"))
            {
                msg.Append("Enter valid Tax Rate.\n");
            }

            if(!(Convert.ToDecimal(taxModel.TaxRate) >= 0 && Convert.ToDecimal(taxModel.TaxRate) <= 100))
            {
                msg.Append("Tax Rate should be between 0 to 100.\n");
            }

             return msg.ToString();  
        }

        #endregion

        #region "Properties"
        private int _POGridHeight;
        public int POGridHeight
        {
            get
            {
                return _POGridHeight;
            }
            set
            {
                _POGridHeight = value;
                OnPropertyChanged("POGridHeight");
            }
        }

        #endregion 

    }
}
