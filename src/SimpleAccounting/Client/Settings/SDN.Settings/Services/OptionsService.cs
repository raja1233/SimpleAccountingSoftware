namespace SDN.Settings.Services
{
    using SDN.Settings.BL;
    using SDN.Settings.BLInterface;
    using SDN.UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class OptionsService:IOptionsService
    {
        public OptionsEntity GetOptionsDetails()
        {
            IOptionsBL optionsBL = new OptionsBL();
            OptionsEntity result = optionsBL.GetOptionsDetails();
            return result;
        }
        /// <summary>
        /// To add or edit options table
        /// </summary>
        /// <param name="optionEntity"></param>
        /// <returns></returns>
        public bool AddEditOptions(OptionsEntity optionEntity)
        {
            IOptionsBL optionsBL = new OptionsBL();
            bool result = optionsBL.AddEditOptions(optionEntity);
            return result;
        }

        public List<AccountsEntity> GetAccountDetails()
        {
            IOptionsBL optionsBL = new OptionsBL();
           List<AccountsEntity> result = optionsBL.GetAccountDetails();
            return result;
        }
    }
}
