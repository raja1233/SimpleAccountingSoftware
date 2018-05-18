using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Settings.ViewModels
{
    using SDN.Common;
    using SDN.UI.Entities;
    using System.Collections.ObjectModel;
    using SDN.Settings.Services;
    using System.Windows.Data;
    using System.Windows;
    using System.ComponentModel;
    using System.Collections;
    using System.Globalization;
    using System.Windows.Input;
    using SASClient.CloseRequest;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Commands;

    public class CategoryViewModel : ViewModelBase
    {
        #region Data members
        ICategoryRepository catRepository = new CategoryRepository();
        ObservableCollection<CategoryModel> _category;
        ObservableCollection<ContentModel> _Content;
        ObservableCollection<ContentModel> _pscategory;
        private int _CategoryHeight;
        string _psContent;
        private object _SelectedCategory;
        private object _selectContent;
        private ContentModel _selectedCategoryContent;
        StackList listitem = new StackList();
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private object _SelectedPSCategory;

        //private object _isChecked;
        BindingGroup _UpdateBindingGroup;

        public int SelectedIndex { get; set; }
        public int SelectedPSIndex { get; set; }

        #endregion

        #region Properties

        public ObservableCollection<CategoryModel> Category
        {
            get
            {
                return _category = new ObservableCollection<CategoryModel>(catRepository.GetAllCategories());
            }
        }

        public ObservableCollection<ContentModel> PSCategory
        {
            get
            {
                return _pscategory = new ObservableCollection<ContentModel>(catRepository.GetPSCategoryList());
            }
        }

        public ObservableCollection<ContentModel> SelectedContent
        {
            get
            {

                return _Content;
            }
            set
            {
                _Content = value;
                OnPropertyChanged("SelectedContent");
            }
        }


        public string SelectedPSContent
        {
            get
            {

                return _psContent;
            }
            set
            {
                _psContent = value;
                OnPropertyChanged("SelectedPSContent");
            }
        }

        public int CategoryHeight
        {
            get
            {

                return _CategoryHeight;
            }
            set
            {
                _CategoryHeight = value;
                OnPropertyChanged("CategoryHeight");
            }
        }


        public ContentModel SelectedCategoryContent
        {
            get
            {
                return _selectedCategoryContent;
            }
            set
            {
                _selectedCategoryContent = value;
                OnPropertyChanged("SelectedCategoryContent");
            }
        }
   
        public object SelectContent
        {
            get
            {
               
                return _selectContent;
            }
            set
            {
              
                _selectContent = value;
                OnPropertyChanged("SelectContent");
            }
        }
        

        public object SelectedCategory
        {
            get
            {
                return _SelectedCategory;

            }
            set
            {
                if (_SelectedCategory != value)
                {
                    _SelectedCategory = value;

                    OnPropertyChanged("SelectedCategory");
                }
            }
        }

        public object SelectedPSCategory
        {
            get
            {
                return _SelectedPSCategory;

            }
            set
            {
                if (_SelectedPSCategory != value)
                {
                    _SelectedPSCategory = value;

                    OnPropertyChanged("SelectedPSCategory");
                    
                }
            }
        }
        private string error;
        public string Error
        {
            get
            {
                return error;

            }
            set
            {
                error = value;
                OnPropertyChanged("Error");

            }
        }

        
        public BindingGroup UpdateBindingGroup
        {
            get
            {
                return _UpdateBindingGroup;
            }
            set
            {
                if (_UpdateBindingGroup != value)
                {
                    _UpdateBindingGroup = value;
                    OnPropertyChanged("UpdateBindingGroup");
                }
            }
        }

        public int SelectedID { get; set; }

        #endregion

        #region Constructors
        //creating a constructor to instantiate relay comamnd objects
        public CategoryViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            Mouse.OverrideCursor = Cursors.Wait;
            //  dbDataManager = new CategoryContentDataManager();
            UpdateBindingGroup = new System.Windows.Data.BindingGroup { Name = "CatContent" };
            SelectChangedCommand = new RelayCommand(DoSelectedChange);
            SelectPSChangedCommand=new RelayCommand(DoPSSelectChange);
            NewRowCommand = new RelayCommand(GetNewContent, CanNew);
            SaveCommand = new RelayCommand(SaveContent,CanSave);
            DeleteCommand = new RelayCommand(DeleteContent,CanDelete);
            CheckCommand = new RelayCommand(DoChecked);
            CancelCommand = new RelayCommand(DoCancel);
            SelectContentChangedCommand = new RelayCommand(DoSelectChange);
            SaveRowCommand = new RelayCommand(SaveContent,CanSave);
            CloseCommand = new DelegateCommand(Close);
            IEnumerable<CategoryModel> lstCategory = catRepository.GetCategory("CCLD".Trim());
            if(lstCategory!=null)
            {
                SelectedID = lstCategory.FirstOrDefault().ID;
                SelectedContent = new  ObservableCollection<ContentModel>(catRepository.GetCategoryContent(SelectedID));
            }

            int minHeight = 300;
            int headerRows = 380;//180+40+30+10;
            var height = System.Windows.SystemParameters.PrimaryScreenHeight - headerRows -50;
            bool validHeight = int.TryParse(height.ToString(), out minHeight);
            this.CategoryHeight = minHeight;


            Mouse.OverrideCursor = null;
        }
        #endregion

        #region Commands
        public ICommand CloseCommand { get; set; }
        public RelayCommand SelectChangedCommand { get; set; }
        public RelayCommand SelectPSChangedCommand { get; set; }
        public RelayCommand NewRowCommand { get; set; }
        public RelayCommand CheckCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand CheckBoxCommand { get; set; }

        public RelayCommand SelectContentChangedCommand { get; set; }

        public RelayCommand SaveRowCommand { get; set; }

        #endregion

        #region Command Delegates

        /// <summary>
        /// This method is used to load content on selected category
        /// </summary>
        /// <param name="param"></param>
        void DoSelectedChange(object param)
        {
            ICategoryRepository catRepository = new CategoryRepository();
            var category = SelectedCategory as CategoryModel;
            //SelectedPSCategory = null;
            SelectedPSContent = string.Empty;
            SelectContent = null;
            SelectedCategoryContent = null;
            Error = string.Empty;
            //PSError = string.Empty;
            if (category != null)
            {
                var catContent =
                    new ObservableCollection<ContentModel>(catRepository.GetCategoryContent(category.ID));
                if(catContent!=null)
                {
                    SelectedContent = catContent;
                }
                SelectedPSCategory = null;
            }
           
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
        void DoPSSelectChange(object param)
        {
            ICategoryRepository catRepository = new CategoryRepository();
            var category = SelectedPSCategory as ContentModel;
            //SelectedCategory = null;
            SelectedCategoryContent = null;
            SelectedContent = null;
            Error = string.Empty;
           // PSError = string.Empty;
            if (category != null)
            {
                var catContent =
                    catRepository.GetPSCategoryContentList(category.CategoryCode);
                if(!string.IsNullOrEmpty(catContent))
                {
                    SelectedPSContent = catContent;
                }
                else
                {
                    SelectedPSContent = string.Empty;
                }
                SelectedCategory = null;
            }
           
        }

        void DoSelectChange(object param)
        {
            ICategoryRepository catRepository = new CategoryRepository();
           
            var content = SelectContent as ContentModel;

            SelectedCategoryContent = new ContentModel();
            if (content != null)
            {
                SelectedCategoryContent.CategoryName = content.CategoryName;
                SelectedCategoryContent.ContentType = content.ContentType;
                SelectedCategoryContent.ContentName = content.ContentName;
                SelectedCategoryContent.ContentID = content.ContentID;
                SelectedCategoryContent.CategoryID = content.CategoryID;
                SelectedCategoryContent.CategoryCode = content.CategoryCode;
                SelectedCategoryContent.IsSelected = content.IsSelected;
                SelectedCategoryContent.Predefined = content.Predefined;

                if (content.CategoryCode.ToUpper() == "CCLD".ToUpper() || content.CategoryCode.ToUpper()== "CD".ToUpper())
                {
                    string[] str = content.ContentName.Split(' ');
                    // model.ContentName = str[0];
                    foreach (string s in str)
                    {
                        SelectedCategoryContent.ContentName = s;
                        break;
                    }
                }
                if (content.CategoryCode.ToUpper() == "CCLA".ToUpper())
                {
                    string format = catRepository.GetCurrencyFormat();
                    if(format == string.Empty || format == null)
                    {
                        format = "en-IN";
                    }

                    var culture = CultureInfo.GetCultureInfo(format);
                    var numberFormat = (NumberFormatInfo)culture.NumberFormat.Clone();
                    // Force the currency symbol regardless of culture
                    string currency = string.Empty;
                     SelectedCategoryContent.ContentName= content.ContentName.Replace(numberFormat.CurrencySymbol, "");
                    string[] str = SelectedCategoryContent.ContentName.Split(',');
                    foreach (var t in str)
                    {
                        currency += t;
                    }
                    SelectedCategoryContent.ContentName = string.Empty;
                    SelectedCategoryContent.ContentName = currency.Trim();
                }
            }

            Error = string.Empty;
        }
        
        void DoCancel(object param)
        {
            var category = SelectedCategory as CategoryModel;

            SelectedContent =
                new ObservableCollection<ContentModel>(catRepository.GetCategoryContent(category.ID));

            UpdateBindingGroup.CancelEdit();
            //if (SelectedIndex == -1)    //This only closes if new - just to show you how CancelEdit returns old values to bindings
            SelectedCategoryContent = null;
                SelectContent  = null;
            Error = string.Empty;
        }

        void GetNewContent(object param)
        {
            var cat = SelectedCategory as CategoryModel;
            var selectContent = SelectedCategoryContent as ContentModel;
            if (cat == null)
            {
                Error="Please select Category";
            }
            else
            {
              GetNewContent(cat.ID);
            }
        }

        bool CanNew(object param)
        {
            var cat = SelectedCategory as CategoryModel;
            if (cat != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void SaveContent(object param)
        {

            //creating an object of repository
            ICategoryRepository catRepository = new CategoryRepository();

            if (SelectedPSCategory != null)
            {
                if (string.IsNullOrEmpty(SelectedPSContent))
                {
                    Error = "Please enter content to save";
                    return;
                }
                else
                {
                    Error = string.Empty;
                    MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Content", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        var cat = SelectedPSCategory as ContentModel;
                        if (cat != null)
                        {
                            var content = new ContentModel();
                            content.CategoryID = cat.CategoryID;
                            content.CategoryCode = cat.CategoryCode;
                            content.ContentName = SelectedPSContent;
                            catRepository.SavePSCategoryContent(content);

                           // PSError = string.Empty;
                        }
                    }
                }
            }
            else
            {
                if (SelectedCategory == null)
                {
                    Error = "Please select Category";
                }
                else
                {
                    // UpdateBindingGroup.CommitEdit();
                    var content = SelectedCategoryContent as ContentModel;
                    if (content == null || content.ContentName == string.Empty || content.ContentName == null)
                    {
                        Error = "Please enter content to save";
                    }
                    else
                    {
                        //Commented as client's mail on 31 march 2017
                        //if (content.Predefined == true)
                        //{
                        //    if (content.ContentName != "0")
                        //    {
                        //        Error = "Cannot edit Predefined Contents";
                        //        return;
                        //     }
                        // }

                        string msg = catRepository.ValidateCategoryContent(content);
                        if (msg != string.Empty)
                        {
                            Error = msg;
                        }
                        else
                        {
                            Error = string.Empty;
                            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Save Content", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.Yes)
                            {
                                if (!catRepository.IsContentExists(content))
                                {
                                    Error = string.Empty;

                                    var catContent = SelectContent as ContentModel;
                                    //if (catContent != null)
                                    //{
                                    //    SelectedCategoryContent.IsSelected = catContent.IsSelected;
                                    //}

                                    if (SelectedIndex == -1)
                                    {
                                        catRepository.SaveCategoryContent(content);
                                    }
                                    else
                                    {
                                        catRepository.UpdateCategoryContent(content);
                                    }
                                    OnPropertyChanged("SelectContent"); // Update the list from the data source

                                    // MessageBox.Show("Record Saved Successfully");                           
                                    // System.Windows.MessageBox.Show("Record Saved successfully", "Save Content", MessageBoxButton.OK);
                                }
                                else
                                {
                                    Error = "Content should be unique";
                                    return;
                                }
                            }
                            SelectContent = null;
                            SelectedCategoryContent = null;
                            SelectedContent =
                           new ObservableCollection<ContentModel>(catRepository.GetCategoryContent(content.CategoryID));
                        }

                    }

                }
            }
         
        }

        public bool CanSave(object param)
        {

            if (SelectedCategoryContent != null)
            {
                var selectContent = SelectedCategoryContent as ContentModel;
                if (selectContent.ContentName != null)
                    return true;
                else
                    return false;
            }
            else if (SelectedPSCategory != null)
            {
                if (!string.IsNullOrEmpty(SelectedPSContent))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }

        public bool CanDelete(object param)
        {
            var selectContent = SelectedCategoryContent as ContentModel;
            if (SelectedCategoryContent != null)
            {
                if (selectContent.ContentName != null || selectContent.Predefined==false)
                    return true;
                else
                    return false;
            }
            else if (SelectedPSCategory != null)
            {
                if (!string.IsNullOrEmpty(SelectedPSContent))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }

        void DeleteContent(object param)
        {
            ICategoryRepository catRepository = new CategoryRepository();
            var selectContent = SelectedCategoryContent as ContentModel;
            if (selectContent != null)
            {
                if (selectContent.ContentID == 0)
                {
                    //System.Windows.MessageBox.Show("Please Save Content");
                    Error = "Please select Category Content";
                }
                else
                {
                    Error = string.Empty;
                    if (selectContent.Predefined == false || selectContent.Predefined == null)
                    {
                        System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to delete content?\n"+ "@ Simple Accounting Software Pte Ltd", "Delete Content", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                        {
                            catRepository.DeleteCategoryContent(selectContent.ContentID);
                            SelectedContent =
                         new ObservableCollection<ContentModel>(catRepository.GetCategoryContent(selectContent.CategoryID));
                            SelectedCategoryContent = null;
                            Error = string.Empty;
                        }
                    }
                    else
                    {
                        Error = "Cannot delete predefined Contents";
                    }
                }
            }
            else if (SelectedPSCategory != null)
            {
                if(!string.IsNullOrEmpty(SelectedPSContent))
                {
                    System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to delete content?\n"+ "@ Simple Accounting Software Pte Ltd", "Delete Content", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        var cat = SelectedPSCategory as ContentModel;
                        var content = new ContentModel();
                        content.CategoryID = cat.CategoryID;
                        content.ContentName = SelectedPSContent;
                        content.CategoryCode = cat.CategoryCode;
                            catRepository.DeletePSCategoryContent(content);
                            SelectedPSContent = string.Empty;
                           // PSError = string.Empty;
                       
                    }
                }
            }
        }

        void DoChecked(object param)
        {
           
        }

        #endregion

        #region "Private methods"

        /// <summary>
        /// This method is used to create 
        /// </summary>
        /// <param name="param"></param>
        private void GetNewContent(int catID)
        {
           // SelectContent = null; // Unselects last selection. Essential, as assignment below won't clear other control's SelectedItems
            SelectedCategoryContent = null;
            Error = string.Empty;
            var content = new ContentModel();
            var selectCategory = catRepository.GetCategoryDetails(catID);
            content.CategoryID = selectCategory.SingleOrDefault().CategoryID;
            content.CategoryName = selectCategory.SingleOrDefault().CategoryName;
            content.ContentType = selectCategory.SingleOrDefault().ContentType;
            content.CategoryCode = selectCategory.SingleOrDefault().CategoryCode;
            // SelectContent = content;
            content.IsSelected = false;
             SelectedCategoryContent = content;
            SelectedIndex = -1;
        }

        #endregion

          }
}
