namespace SDN.Sales.DAL
{
    using System.Collections.Generic;

    using System.Linq;
    using SDN.Sales.DALInterface;
    using SDN.Sales.EDM;
    using System.Data.Entity.Core.Objects;
  
    using UI.Entities;

    /// <summary>
    /// ContactDAL class 
    /// </summary>
    //public class ContactDAL : IContactDAL
    //{
    //    /// <summary>
    //    /// Gets all contact.
    //    /// </summary>
    //    /// <returns>Get All Contact</returns>
    //    public List<Contact> GetAllContact()
    //    {
    //        using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
    //        {
    //            //returns entities from conceptual model
    //            //ObjectQuery<Contact> contacts = entities.Contacts;

    //            ////objects are maintained in a detached state and are not tracked in the ObjectStateManager;
    //            //contacts.MergeOption = MergeOption.NoTracking;

    //            ////queries against a specific data source where in the type of the data is known
    //            //IQueryable<Contact> query = from contact in contacts select contact;

    //            //materialized the result
    //            List<Contact> result = entities.Contacts.ToList();// query.ToList();
    //            return result;
    //        }
    //    }
    //}

    ///// <summary>
    ///// StoreDAL class
    ///// </summary>
    //public class StoreDAL : IStoreDAL
    //{
    //    /// <summary>
    //    /// Gets all store.
    //    /// </summary>
    //    /// <returns>Get All Store</returns>
    //    public List<Store> GetAllStore()
    //    {
    //        using (SDNSalesDBEntities entites = new SDNSalesDBEntities())
    //        {
    //            //returns entities from the conceptual model
    //            //ObjectQuery<Store> stores = entites.Stores;

    //            ////objects are maintained in a detached state and are not tracked in the ObjectStateManager;
    //            //stores.MergeOption = MergeOption.NoTracking;

    //            ////queries against a specific data source where in the type of the data is known
    //            //IQueryable<Store> query = from store in stores select store;

    //            //Materialized result
    //            List<Store> result = entites.Stores.ToList(); //query.ToList();
    //            return result;
    //        }
    //    }
    //}

    /// <summary>
    /// CustomerDAL class 
    /// </summary>
    public class CustomerDAL : ICustomerDAL
    {
        /// <summary>
        /// Gets all customer.
        /// </summary>
        /// <returns>Get All Customer</returns>
        public List<Customer> GetAllCustomer()
        {
            using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
            {
                //returns entities from conceptual model
                //ObjectQuery<Customer> customers = entities.Customers;

                ////objects are maintained in a detached state and are not tracked in the ObjectStateManager;
                //customers.MergeOption = MergeOption.NoTracking;

                ////queries against a specific data source where in the type of the data is known
                //IQueryable<Customer> query = from cust in customers select cust;

                //Materialized result
                List<Customer> customerList = entities.Customers.ToList(); //query.ToList();
                return customerList;
            }
        }

        public int CreateCustomer(Customer entity,List<ShippingAddress> shippingAddress)
        {
            using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
            {
                entities.Customers.Add(entity);
                foreach (var address in shippingAddress)
                {
                    entities.ShippingAddresses.Add(address);
                }
                return entities.SaveChanges();
            }
        }

        public List<CatagoryType> GetCustomerType()
        {
            using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
            {
                return this.GetCategoryType("CT");
            }
        }

        public List<CatagoryType> GetCategoryType(string cat_Code)
        {
            using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
            {

                var customerType = entities.CategoriesContents.Join(entities.Categories,
                    cc => cc.Cat_Id,
                    c => c.ID,
                    ((cc, c) => new { CategoriesContent = cc, Category = c }))
                    .Where(x => x.CategoriesContent.IsDeleted == false && x.Category.Cat_Code == cat_Code)
                    .Select((x) => new CatagoryType() { ID = x.CategoriesContent.ID, Cat_Contents = x.CategoriesContent.Cat_Contents })
                    .ToList();

                //query.ToList();

                return customerType;

            }
        }
    }

    ///// <summary>
    ///// CountryRegionDAL class 
    ///// </summary>
    //public class CountryRegionDAL : ICountryRegionDAL
    //{
    //    /// <summary>
    //    /// Gets the country region.
    //    /// </summary>
    //    /// <returns>Get Country Region</returns>
    //    public List<Country> GetCountryRegion()
    //    {
    //        using (SDNSalesDBEntities entities = new SDNSalesDBEntities())
    //        {
    //            ////returns Country entities from the conceptual model
    //            //ObjectQuery<Country> regions = entities.Countries;

    //            ////objects are maintained in a detached state and are not tracked in the ObjectStateManager;
    //            //regions.MergeOption = MergeOption.NoTracking;

    //            ////queries against a specific data source where in the type of the data is known
    //            //IQueryable<Country> query = from region in regions select region;

    //            //Materialized Country result
    //            List<Country> result = entities.Countries.ToList(); //query.ToList();
    //            return result;
    //        }
    //    }
    //}
}
