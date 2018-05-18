
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Product.Services
{
    using SDN.UI.Entities.ProductandServices;
    using UI.Entities;

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
