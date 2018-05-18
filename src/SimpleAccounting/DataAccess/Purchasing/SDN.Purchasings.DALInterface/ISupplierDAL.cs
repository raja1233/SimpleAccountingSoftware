

namespace SDN.Purchasings.DALInterface
{
    using SDN.UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface ISupplierDAL
    {
         
        bool CreateSupplier(SupplierDetailEntity entity);
      
        int GetSupplierCount(string isInActive);
        bool CanDeleteSupplier(int supId);
        bool DeleteSupplier(int supId);
        bool RefreshSupplier(int supId);
        List<string> GetAutoFillData(string EntityType);
        SupplierDetailEntity GetSupplierById(int supId);
    }


    
}

