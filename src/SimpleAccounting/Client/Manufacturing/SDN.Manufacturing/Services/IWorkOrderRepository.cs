using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDN.UI.Entities;

namespace SDN.Manufacturing.Services
{
    /// <summary>
    /// WorkOrder Repository class
    /// </summary>
    public interface IWorkOrderRepository
    {
        /// <summary>
        /// Gets all work orders.
        /// </summary>
        /// <returns>Get All WorkOrders</returns>
        IEnumerable<WorkOrderEntity> GetAllWorkOrders();
    }
}
