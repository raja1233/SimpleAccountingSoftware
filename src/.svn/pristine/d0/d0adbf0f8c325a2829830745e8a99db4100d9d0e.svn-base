namespace SDN.Settings.BL
{
    using SDN.Settings.BLInterface;
    using SDN.Settings.DAL;
    using SDN.Settings.DALInterface;
    using SDN.UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OptionsBL:IOptionsBL
    {
        public OptionsEntity GetOptionsDetails()
        {
            IOptionsDAL OptionsDetails = new OptionsDAL();
            var optionDAL = OptionsDetails.GetOptionsDetails();
            return optionDAL;
        }

        public bool AddEditOptions(OptionsEntity optionsEntity)
        {
            IOptionsDAL OptionsDetails = new OptionsDAL();
            bool result = OptionsDetails.AddEditOptions(optionsEntity);
            return result;
        }
        public List<AccountsEntity> GetAccountDetails()
        {
            IOptionsDAL OptionsDetails = new OptionsDAL();
            var optionDAL = OptionsDetails.GetAccountDetails();
            return optionDAL;
        }
    }
}
