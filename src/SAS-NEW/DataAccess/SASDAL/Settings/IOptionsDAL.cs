using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Settings.DALInterface
{
   public interface IOptionsDAL
    {
        OptionsEntity GetOptionsDetails();
        bool AddEditOptions(OptionsEntity optionsEntity);
       List<AccountsEntity> GetAccountDetails();
        int GetYearStart();
    }
  
}
