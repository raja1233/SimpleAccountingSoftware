using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDN.UI.Entities;

namespace SDN.Sales.Services
{
    /// <summary>
    /// Contact Repository interface
    /// </summary>
    public interface IContactRepository
    {
        /// <summary>
        /// Gets all contacts.
        /// </summary>
        /// <returns>Get All Contacts</returns>
        IEnumerable<ContactEntity> GetAllContacts();
    }
}
