using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDN.Settings.DALInterface
{
     
    using SDN.UI.Entities;

    public interface ICategoriesDAL
    {
         List<UI.Entities.CategoryModel> GetCategoryList();
        List<CategoryModel> GetCategory(string catCode);
        List<ContentModel> GetPSCategoryList();
    }

    public interface ICategoryContentDAL
    {
        List<ContentModel> GetCategoryContentList(int catID);
        string GetPSCategoryContentList(string tcCode);
        string GetNumberFormat();
    }

    public interface IContentOperationDAL
    {
        List<ContentModel> GetCategoryDetails(int ID);

        void DeleteCategoryContent(int contentID);
        void SaveCategoryContent(ContentModel content);

        void DeletePSCategoryContent(ContentModel content);
        void SavePSCategoryContent(ContentModel content);

        void UpdateCategoryContent(ContentModel content);

        bool IsContentExists(ContentModel content);

        void SaveTaxName(string taxName);

    }
}
