using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities;

namespace SDN.Settings.Services
{
    public interface ICategoryRepository
    {
        string GetCurrencyFormat();

        IEnumerable<CategoryModel> GetAllCategories();
        IEnumerable<CategoryModel> GetCategory(string catCode);

        IEnumerable<ContentModel> GetCategoryContent(int ID);
        string GetPSCategoryContentList(string tcCode);

        IEnumerable<ContentModel> GetCategoryDetails(int ID);

        void SaveCategoryContent(ContentModel content);

        void DeleteCategoryContent(int contentID);

        void UpdateCategoryContent(ContentModel content);
        void DeletePSCategoryContent(ContentModel content);
        void SavePSCategoryContent(ContentModel content);
      //  void UpdatePSCategoryContent(ContentModel content);
        //bool IsPSContentExists(ContentModel content);
        string ValidateCategoryContent(ContentModel model);

         bool IsContentExists(ContentModel content);

        List<ContentModel> GetPSCategoryList();

    }
}
