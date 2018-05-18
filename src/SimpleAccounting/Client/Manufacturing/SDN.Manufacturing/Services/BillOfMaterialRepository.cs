using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDN.UI.Entities;
using SDN.Manufacturings.BLInterface;
using SDN.ManufacturingEDM;
using SDN.Manufacturings.BL;

namespace SDN.Manufacturing.Services
{
    /// <summary>
    /// BillOfMaterial Repository class
    /// </summary>
   public class BillOfMaterialRepository : IBillOfMaterialRepository
    {
        /// <summary>
        /// Gets all bill of materials.
        /// </summary>
        /// <returns>
        /// Get All BillOfMaterials
        /// </returns>
        public IEnumerable<BillOfMaterialEntity> GetAllBillOfMaterials()
        {
            IList<BillOfMaterialEntity> result = new List<BillOfMaterialEntity>();
            IBillOfMaterialBL billOfMaterialBL = new BillOfMaterialBL();
            List<BillOfMaterial> billOfMaterialList = billOfMaterialBL.GetAllBillOfMaterial();
            foreach (BillOfMaterial source in billOfMaterialList)
            {
                BillOfMaterialEntity target = new BillOfMaterialEntity();
                target.ProductAssemblyID = source.ProductAssemblyID;
                target.AssemblyID = source.AssemblyID;
                target.ComponentID = source.ComponentID;
                target.Name = source.Name;
                target.PerAssemblyQty = source.PerAssemblyQty;
                target.EndDate = source.EndDate;
                target.ComponentLevel = source.ComponentLevel;
                result.Add(target);
            }
            return result;
        }
    }
}
