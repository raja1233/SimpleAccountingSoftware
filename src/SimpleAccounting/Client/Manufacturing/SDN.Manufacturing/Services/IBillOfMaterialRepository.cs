namespace SDN.Manufacturing.Services
{
    using System.Collections.Generic;
    using SDN.UI.Entities;

    /// <summary>
    /// BillOfMaterial Repository interface
    /// </summary>
    public interface IBillOfMaterialRepository 
    {
        /// <summary>
        /// Gets all bill of materials.
        /// </summary>
        /// <returns>Get All BillOfMaterials</returns>
        IEnumerable<BillOfMaterialEntity> GetAllBillOfMaterials();
    }
}
