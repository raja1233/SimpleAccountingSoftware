using System.Collections.Generic;
using SDN.UI.Entities;
using SASDAL;
namespace SDN.Settings.BLInterface
{
    public interface ICategoryBL
    {
        List<CategoryModel> GetAllCategories();
        List<CategoryModel> GetCategory(string CategoryCode);
        List<ContentModel> GetPSCategoryList();
    }

    public interface ICategoryContentBL
    {
        List<ContentModel> GetCategoryContent(int catID);
       string GetPSCategoryContentList(string tcCode);
        string GetNumberFormat();
    }

    public interface IContentOperationBL
    {
        List<ContentModel> GetCategoryDetails(int ID);
        void DeleteCategoryContent(int contentID);
        void SaveCategoryContent(ContentModel content);

        void UpdateCategoryContent(ContentModel content);

        void DeletePSCategoryContent(ContentModel content);
        void SavePSCategoryContent(ContentModel content);

    //    void UpdatePSCategoryContent(ContentModel content);
        //bool IsPSContentExists(ContentModel content);

        string  ValidateCategoryContent(ContentModel model);
        bool IsContentExists(ContentModel content);

         void SaveTaxName(string taxName);
    }

   
}
