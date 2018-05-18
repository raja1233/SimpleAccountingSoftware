using SDN.UI.Entities.CashandBank;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SASClient.Converters
{
    public class AccountTypeVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            List<AccountsDetailsListEntity> accountDetails = new List<AccountsDetailsListEntity>(values[0] as IEnumerable<AccountsDetailsListEntity>);
            AccountsDetailsListEntity selectedAccountDetail = values[1] as AccountsDetailsListEntity;

            accountDetails.RemoveAll(x => x.AccountType != selectedAccountDetail.AccountType);

            if (accountDetails != null && accountDetails.Any() && selectedAccountDetail.ID == accountDetails.Min(x => x.ID))
                return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
