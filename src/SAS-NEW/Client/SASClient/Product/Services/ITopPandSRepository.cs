
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Product.Services
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.ProductandServices;
    public interface ITopPandSRepository
    {
        List<TopPandSEntity> GetPandSList(string JsonData);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        OptionsEntity GetOptionDetails();
        IEnumerable<TaxModel> GetTaxes();
        List<YearEntity> GetYearRange();
    }
}
