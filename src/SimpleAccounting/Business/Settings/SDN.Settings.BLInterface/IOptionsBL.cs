namespace SDN.Settings.BLInterface
{
    using SDN.UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IOptionsBL
    {
        OptionsEntity GetOptionsDetails();
        bool AddEditOptions(OptionsEntity optionEntity);
       List<AccountsEntity> GetAccountDetails();
    }
}
