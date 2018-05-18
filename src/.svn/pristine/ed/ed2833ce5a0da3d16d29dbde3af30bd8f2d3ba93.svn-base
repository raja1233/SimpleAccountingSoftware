using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.Settings;
using SDN.UI.Entities;
using SDN.Settings.BLInterface;
using SDN.Settings.BL;
using categories = SDN.UI.Entities;

namespace SDN.Settings.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        /// <summary>
        /// This method is used to delete Category content
        /// </summary>
        /// <param name="contentID"></param>
        public void DeleteCategoryContent(int contentID)
        {
            IContentOperationBL catBL = new CategoryContentOperationsBL();
            catBL.DeleteCategoryContent(contentID);
        }

        /// <summary>
        /// This method is used to save all the contents against this category
        /// </summary>
        /// <param name="content"></param>
        public void SaveCategoryContent(ContentModel content)
        {
            IContentOperationBL catBL = new CategoryContentOperationsBL();
            catBL.SaveCategoryContent(content);
        }

        /// <summary>
        /// This method is used to update category content
        /// </summary>
        /// <param name="content"></param>
        public void UpdateCategoryContent(ContentModel content)
        {
            IContentOperationBL catBL = new CategoryContentOperationsBL();
            catBL.UpdateCategoryContent(content);
        }

        /// <summary>
        /// This method is used to get all categories
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContentModel> GetCategoryContent(int CategoryID)
        {
          //  IList<ContentModel> result = new List<ContentModel>();
            ICategoryContentBL catBL = new CategoryContentBL();
            List<ContentModel> conList = catBL.GetCategoryContent(CategoryID);
         
            return conList;
        }

        public bool IsContentExists(ContentModel content)
        {
            IContentOperationBL conBL = new CategoryContentOperationsBL();
            bool isExists = conBL.IsContentExists(content);
            return isExists;
        }

        /// <summary>
        /// This method is used to get all categories
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryModel> GetAllCategories()
        {
            //IList<CategoryModel> result = new List<CategoryModel>();
            ICategoryBL catBL = new CategoryBL();
            List<categories.CategoryModel> catList = catBL.GetAllCategories();
          
            return catList;
        }

       public List<ContentModel> GetPSCategoryList()
        {
            ICategoryBL catBL = new CategoryBL();
            List<categories.ContentModel> catList = catBL.GetPSCategoryList();
            return catList;
        }

        public  IEnumerable<CategoryModel> GetCategory(string catCode)
        {
            ICategoryBL catBL = new CategoryBL();
            List<categories.CategoryModel> catList = catBL.GetCategory(catCode);

            return catList;
        }

        /// <summary>
        /// This method is used to validate all the category contents with associated category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string ValidateCategoryContent(ContentModel model)
        {
            IContentOperationBL catBL = new CategoryContentOperationsBL();
            string isValidate = catBL.ValidateCategoryContent(model);
            return isValidate;
        }

        /// <summary>
        /// This method is used to get category details
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IEnumerable<ContentModel> GetCategoryDetails(int ID)
        {
            IContentOperationBL catBL = new CategoryContentOperationsBL();
            return catBL.GetCategoryDetails(ID);
        }

        public string GetCurrencyFormat()
        {
            ICategoryContentBL catBL = new CategoryContentBL();
             return   catBL.GetNumberFormat();
        }

        /// <summary>
        /// This method is used to get all the Purchase and Sales Categories
        /// </summary>
        /// <param name="psCatID"></param>
        /// <returns></returns>
        public string GetPSCategoryContentList(string tcCode)
        {
            ICategoryContentBL catBL = new CategoryContentBL();
            return catBL.GetPSCategoryContentList(tcCode);
        }

        /// <summary>
        /// This methos is used to save Purchase and Sales Categories content
        /// </summary>
        /// <param name="content"></param>
        public void SavePSCategoryContent(ContentModel content)
        {
            IContentOperationBL catBL = new CategoryContentOperationsBL();
             catBL.SavePSCategoryContent(content);
        }

        /// <summary>
        /// This method is used to delete Purchase and Sales Categories content
        /// </summary>
        /// <param name="content"></param>
        public void DeletePSCategoryContent(ContentModel content)
        {
            IContentOperationBL catBL = new CategoryContentOperationsBL();
            catBL.DeletePSCategoryContent(content);
        }

        ///// <summary>
        ///// This methos is used to check whether Purchase and Sales Categories content available
        ///// </summary>
        ///// <param name="content"></param>
        ///// <returns></returns>
        //public bool IsPSContentExists(ContentModel content)
        //{
        //    IContentOperationBL catBL = new CategoryContentOperationsBL();
        //    return catBL.IsPSContentExists(content);
        //}
    }
}
