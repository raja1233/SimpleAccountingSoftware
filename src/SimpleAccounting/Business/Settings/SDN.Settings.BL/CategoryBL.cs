using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDN.Settings.BL
{
    using SDN.Settings.BLInterface;
    using SDN.SettingsEDM;
    using SDN.Settings.DALInterface;
    using SDN.Settings.DAL;
    using SDN.UI.Entities;
    using System.Globalization;
    
    public class CategoryBL : ICategoryBL
    {
        public List<CategoryModel> GetCategory(string CategoryCode)
        {
            ICategoriesDAL CatDAL = new CategoriesDAL();
            List<UI.Entities.CategoryModel> result = CatDAL.GetCategory(CategoryCode);
            return result;
        }

        public List<ContentModel> GetPSCategoryList()
        {
            ICategoriesDAL CatDAL = new CategoriesDAL();
            List<UI.Entities.ContentModel> result = CatDAL.GetPSCategoryList();
            return result;
        }

        /// <summary>
        /// This method is used to get all categories
        /// </summary>
        /// <returns></returns>
        List<UI.Entities.CategoryModel> ICategoryBL.GetAllCategories()
        {
            ICategoriesDAL CatDAL = new CategoriesDAL();
            List<UI.Entities.CategoryModel> result = CatDAL.GetCategoryList();
            return result;
        }
    }

    public class DummyProvider : IFormatProvider
    {
        public object GetFormat(Type formatType)
        {
            return "N2";
        }
    }

    public class CategoryContentBL : ICategoryContentBL
    {
        DummyProvider dummy = new DummyProvider();
        
        /// <summary>
        /// This method is used to get category contents associated with category
        /// </summary>
        /// <param name="catID"></param>
        /// <returns></returns>
        public List<ContentModel> GetCategoryContent(int catID)
        {
            ICategoryContentDAL conDAL = new CategoryContentsDAL();
            List<ContentModel> result = conDAL.GetCategoryContentList(catID);
            string format = conDAL.GetNumberFormat();
            if(format==string.Empty || format==null)
            {
                format = "en-IN";
            }

            foreach (var item in result)
            {
                if (item.CategoryCode.Trim() == "CCLD")
                {
                    item.ContentName = item.ContentName + " " + item.ContentType;
                }

                if (item.CategoryCode.Trim() == "CD")
                {
                    item.ContentName = item.ContentName + " " + "%";
                }
                if(item.CategoryCode.Trim() == "CCLA")
                {
                    long abc = Convert.ToInt64(item.ContentName);
                    //  item.ContentName = abc.ToString("C", new CultureInfo("en-IN"));
                    item.ContentName = abc.ToString("C", new CultureInfo(format));
                    var culture = CultureInfo.GetCultureInfo(format);
                    var numberFormat = (NumberFormatInfo)culture.NumberFormat.Clone();
                    // Force the currency symbol regardless of culture

                    item.ContentName = item.ContentName.Replace(numberFormat.CurrencySymbol, "");
                    string[] str= item.ContentName.Split('.');
                    item.ContentName = str[0];
                }
            }
            return result;
        }

        public string GetNumberFormat()
        {
            ICategoryContentDAL conDAL = new CategoryContentsDAL();
           return conDAL.GetNumberFormat();
        }

        public string GetPSCategoryContentList(string tcCode)
        {
            ICategoryContentDAL conDAL = new CategoryContentsDAL();
            string result = conDAL.GetPSCategoryContentList(tcCode);
            return result;
        }
    }
    
    public class CategoryContentOperationsBL : IContentOperationBL
    {
        IContentOperationDAL conDAL = new ContentOperationDAL();

       /// <summary>
       /// This method is used to delete catgorycontent
       /// </summary>
       /// <param name="contentID"></param>
        public void DeleteCategoryContent(int contentID)
        {
            conDAL.DeleteCategoryContent(contentID);
        }

        /// <summary>
        /// This method is used to get category contents with selected category
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<ContentModel> GetCategoryDetails(int ID)
        {
            return conDAL.GetCategoryDetails(ID);
        }

        public bool IsContentExists(ContentModel content)
        {
            IContentOperationDAL conDAL = new ContentOperationDAL();
            bool isExists= conDAL.IsContentExists(content);
            return isExists;
        }

        /// <summary>
        /// This method is used to save category content for selected category
        /// </summary>
        /// <param name="content"></param>
        public void SaveCategoryContent(ContentModel content)
        {
            if (content.CategoryCode.ToUpper() == "CCLD".ToUpper()
                || content.CategoryCode.ToUpper()=="CCLA".ToUpper()
                || content.CategoryCode.ToUpper()== "CD".ToUpper())
             {
               
                content.Limit =Convert.ToDecimal(content.ContentName);
            }
                conDAL.SaveCategoryContent(content);
        }
        
        //public bool IsPSContentExists(ContentModel content)
        //{
        //    return conDAL.IsPSContentExists(content);
        //}
        public void DeletePSCategoryContent(ContentModel content)
        {
            conDAL.DeletePSCategoryContent(content);
        }

        public void SavePSCategoryContent(ContentModel content)
        {
            conDAL.SavePSCategoryContent(content);
        }
        
        public void SaveTaxName(string taxName)
        {
            conDAL.SaveTaxName(taxName);
        }

        /// <summary>
        /// This method is used to update category content for selected category
        /// </summary>
        /// <param name="content"></param>
        public void UpdateCategoryContent(ContentModel content)
        {
            if (content.CategoryCode.ToUpper() == "CCLD".ToUpper()
                || content.CategoryCode.ToUpper() == "CCLA".ToUpper()
                || content.CategoryCode.ToUpper() == "CD".ToUpper())
            {

                content.Limit = Convert.ToDecimal(content.ContentName);
            }
            conDAL.UpdateCategoryContent(content);
        }

       
        /// <summary>
        /// This method is used to validate saving data for category and contents
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string  ValidateCategoryContent(ContentModel model)
        {
            string msg = string.Empty;

            if(model.ContentName.Trim()==string.Empty)
            {
                return msg="Please enter Content Name";
            }
            else
            {

                if (model.CategoryCode.ToUpper() == "CCLA".ToUpper())
                {
                    //string[] str = model.ContentName.Split(',');
                    //foreach(var t in str)
                    //{
                    //    model.ContentName = model.ContentName + t;
                    //}

                    if (System.Text.RegularExpressions.Regex.IsMatch(model.ContentName.Trim(), @"[^0-9]"))
                    {
                        return msg = "Please enter amount in numbers only";
                    }

                    if (model.ContentName.Trim().Length > 13)
                    {
                        return msg = "Please enter valid Amount";
                    }

                }
                if (model.CategoryCode.ToUpper() == "CCLD".ToUpper())
                {
                    if (model.CategoryCode.ToUpper() == "CCLD".ToUpper())
                    {
                        string[] str = model.ContentName.Split(' ');
                       // model.ContentName = str[0];
                        foreach (string s in str)
                        {
                            model.ContentName = s;
                            break;
                        }
                    }

                    if (System.Text.RegularExpressions.Regex.IsMatch(model.ContentName.Trim(), @"[^0-9]"))
                    {
                        return msg = "Please enter valid days";
                    }

                    if(model.ContentName.Trim().Length > 10) 
                    {
                        return msg = "Please enter valid days";
                    }

                }
                 if (model.CategoryCode.ToUpper() == "CD".ToUpper())
                {
                    string[] str = model.ContentName.Split(' ');
                    model.ContentName = str[0];
                    foreach (string s in str)
                    {
                        model.ContentName = s;
                        break;
                    }

                    if (System.Text.RegularExpressions.Regex.IsMatch(model.ContentName.Trim(), @"[^0-9]"))
                    {
                        return msg = "Please enter valid percentage";
                    }
                    else if (model.ContentName.Trim().Length > 3)
                    {
                        return msg = "Please enter valid percentage";
                    }
                    else if (!(Convert.ToDecimal(model.ContentName.Trim()) >= 0 && Convert.ToDecimal(model.ContentName.Trim()) <= 100))
                    {
                        return msg = "Please enter percent in the range of 0 to 100";
                    }
                    
                }
                // if(model.CategoryCode.ToUpper()== "PSC01".ToUpper() || model.CategoryCode.ToUpper() == "PSC02".ToUpper()
                //    || model.CategoryCode.ToUpper()== "CT".ToUpper())
                //{
                //    if (!System.Text.RegularExpressions.Regex.IsMatch(model.ContentName.Trim(), @"^[a-zA-Z0-9\s,]*$"))
                //    {
                //        return msg = "Content Should be alphanumeric";
                //    }
                //}

                 if(model.CategoryCode.ToUpper() == "SM".ToUpper() || model.CategoryCode.ToUpper() == "STC".ToUpper() ||
                    model.CategoryCode.ToUpper() == "PTC".ToUpper() || model.CategoryCode.ToUpper() == "DCNR".ToUpper())
                {
                    if (model.ContentName.Trim().Length > 200)
                    {
                        return msg = "Content Should be of 200 Characters only";
                    }
                }
                 if (model.CategoryCode.ToUpper() == "CT".ToUpper() || model.CategoryCode.ToUpper() == "PSC01".ToUpper()
                    || model.CategoryCode.ToUpper() == "PSC02".ToUpper())
                {
                    if (model.ContentName.Trim().Length > 10)
                    {
                        return msg = "Content Should be of 10 Characters only";
                    }

                }
               
                return msg;
            } 
             

        }
    }
}
