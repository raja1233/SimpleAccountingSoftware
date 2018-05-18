using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.Settings.DAL;
using SDN.Settings.DALInterface;
using SDN.SettingsEDM;
using SDN.UI.Entities;

namespace SDN.Settings.BLInterface
{
    public interface ICategoryBL
    {
        List<UI.Entities.CategoryModel> GetAllCategories();
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
