using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDN.UI.Entities;

namespace SDN.Sales.Services
{
    /// <summary>
    /// Location Repository interface
    /// </summary>
   public interface ILocationRepository
    {
        /// <summary>
        /// Gets all locations.
        /// </summary>
        /// <returns>Get All Locations</returns>
       IEnumerable<LocationEntity> GetAllLocations();
    }
}
