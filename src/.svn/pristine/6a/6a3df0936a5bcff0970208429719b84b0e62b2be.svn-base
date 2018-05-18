
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    using SDN.UI.Entities;
    public interface ITopSuppliersRepository
    {
        List<TopSuppliersEntity> GetPandSList(string jsonData);
        bool SaveSearchJson(string jsonSearch, int ScreenId, string ScreenName);
        string GetLastSelectionData(int ScreenId);
        string GetDateFormat();
        List<YearEntity> GetYearRange();
        IEnumerable<TaxModel> GetTaxes();
        OptionsEntity GetOptionDetails();
    }
}
