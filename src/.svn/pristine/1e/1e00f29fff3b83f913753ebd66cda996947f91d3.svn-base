namespace SDN.Manufacturings.DAL
{
    using System.Collections.Generic;

    using System.Linq;
    using SDN.ManufacturingEDM;
    using SDN.Manufacturings.DALInterface;
    using System.Data.Entity.Core.Objects;

    /// <summary>
    /// BillOfMaterialDAL class 
    /// </summary>
    public class BillOfMaterialDAL : IBillOfMaterialDAL
    {
        /// <summary>
        /// Gets all bill of material.
        /// </summary>
        /// <returns>Get All BillOfMaterial</returns>
        public List<BillOfMaterial> GetAllBillOfMaterial()
        {
            using (SDNManufacturingDBEntities entites = new SDNManufacturingDBEntities())
            {
                //ObjectQuery<BillOfMaterial> billOfMaterials = entites.BillOfMaterials;

                //billOfMaterials.MergeOption = MergeOption.NoTracking;

                //IQueryable<BillOfMaterial> query = from bill in billOfMaterials select bill;

                List<BillOfMaterial> result = entites.BillOfMaterials.ToList();// query.ToList();

                return result;
            }
        }
    }

    /// <summary>
    /// ProductInventoryDAL class 
    /// </summary>
    public class ProductInventoryDAL : IProductInventoryDAL
    {
        /// <summary>
        /// Gets all product inventory.
        /// </summary>
        /// <returns>Get All ProductInventory</returns>
        public List<ProductInventory> GetAllProductInventory()
        {
            using (SDNManufacturingDBEntities entites = new SDNManufacturingDBEntities())
            {
                //ObjectQuery<ProductInventory> productInventories = entites.ProductInventories;

                //productInventories.MergeOption = MergeOption.NoTracking;

                //IQueryable<ProductInventory> query = from inventory in productInventories select inventory;

                List<ProductInventory> result = entites.ProductInventories.ToList();// query.ToList();

                return result;
            }
        }
    }


    /// <summary>
    /// WorkOrderDAL class 
    /// </summary>
    public class WorkOrderDAL : IWorkOrderDAL
    {
        /// <summary>
        /// Gets all work order.
        /// </summary>
        /// <returns>Get All WorkOrder</returns>
        public List<WorkOrder> GetAllWorkOrder()
        {
            using (SDNManufacturingDBEntities entites = new SDNManufacturingDBEntities())
            {
                //ObjectQuery<WorkOrder> workOrders = entites.WorkOrders;

                //workOrders.MergeOption = MergeOption.NoTracking;

                //IQueryable<WorkOrder> query = from orders in workOrders select orders;

                List<WorkOrder> result = entites.WorkOrders.ToList();//query.ToList();

                return result;
            }
        }
    }
 
}
