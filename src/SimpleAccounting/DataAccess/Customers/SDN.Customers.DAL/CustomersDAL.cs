 

namespace SDN.Customers.DAL
{
    using System.Collections.Generic;
    using System.Linq;
    using SDN.Customers.DALInterface;
    using SDN.Customers.EDM;

    using SDN.UI.Entities;
    using System.Data.Entity;
    using System;
    using System.Globalization;

    /// <summary>
    /// CustomerDAL class 
    /// </summary>
    public class CustomersDAL : ICustomersDAL
    {
        /// <summary>
        /// Gets all customer.
        /// </summary>
        /// <returns>Get All Customer</returns>
        public List<Customer> GetAllCustomer()
        {
            using (SDNCustomersDBEntities entities = new SDNCustomersDBEntities())
            {

                List<Customer> customerList = entities.Customers.Where(x=>x.IsDeleted!= true).ToList(); //query.ToList();
                return customerList;
            }
        }

        public int CreateCustomer(Customer entity)
        {
            using (SDNCustomersDBEntities entities = new SDNCustomersDBEntities())
            {
                if (entities.Customers.AsNoTracking().FirstOrDefault(x => x.ID == entity.ID) == null)
                {
                    entities.Customers.Add(entity);
                }
                else
                {
                    entities.Entry(entity).State = EntityState.Modified;
                }                 
                return entities.SaveChanges();
            }
        }

        public List<CatagoryType> GetCustomerType()
        {
            using (SDNCustomersDBEntities entities = new SDNCustomersDBEntities())
            {
                return this.GetCategoryType("CT");
            }
        }

        public List<CatagoryType> GetCategoryType(string cat_Code)
        {
            using (SDNCustomersDBEntities entities = new SDNCustomersDBEntities())
            {

                var customerType = entities.CategoriesContents.Join(entities.Categories,
                    cc => cc.Cat_Id,
                    c => c.ID,
                    ((cc, c) => new { CategoriesContent = cc, Category = c }))
                    .Where(x => x.CategoriesContent.IsDeleted == false && x.Category.Cat_Code == cat_Code)
                    .Select((x) => new CatagoryType()
                    {
                        ID = x.CategoriesContent.ID,
                        Cat_Contents = x.CategoriesContent.Cat_Contents,
                        Content_Limit = x.CategoriesContent.Content_Limit,
                        DisplayDays = x.CategoriesContent.Content_Limit.ToString() + " Days",
                        DisplayDiscount = x.CategoriesContent.Content_Limit.ToString() + " %",
                        SetDefault =x.CategoriesContent.Set_Default
                    }).OrderByDescending(y=>y.SetDefault)
                    .ToList();


                return customerType;

            }
        }

        public List<ShippingAddress> GetShippingAddress(int customerId)
        {
            using (SDNCustomersDBEntities entities = new SDNCustomersDBEntities())
            {
                var addresses = entities.ShippingAddresses.Where(x => x.EntityId == customerId && x.EntityType.Equals("Customer"));

                return addresses.ToList();
            }
        }

        public int GetCustomersCount(string isInActive)
        {
            int customerCount = 0;
            customerCount = CustomersListByStatus(isInActive).Count();

            return customerCount;
        }
        private List<Customer> CustomersListByStatus(string isInActive)
        {
            string activeVal = "A";
            if (isInActive.ToString() != string.Empty)
            {
                activeVal = isInActive;
            }
            List<Customer> resultCust = new List<Customer>();
            using (SDNCustomersDBEntities entities = new SDNCustomersDBEntities())
            {
                if (activeVal == "A")
                {
                    resultCust = entities.Customers.Where(x => x.IsDeleted != true).ToList();
                    
                }
                else
                {
                    resultCust = entities.Customers.Where(x => x.IsDeleted != true && x.Cus_Inactive== activeVal).ToList();                    

                }


            }
            return resultCust;
        }

        public bool CanDeleteCustomer(int custId)
        {
            bool allowDelete = true;
            using (SDNCustomersDBEntities entities = new SDNCustomersDBEntities())
            {
                var SQ = entities.SalesQuotations.Where(x => x.IsDeleted != true && x.Cus_Id== custId).FirstOrDefault();
                var SO = entities.SalesOrders.Where(x => x.IsDeleted != true && x.Cus_Id == custId).FirstOrDefault();
                var SI = entities.SalesInvoices.Where(x => x.IsDeleted != true && x.Cus_Id == custId).FirstOrDefault();
                if (SQ != null)
                {
                    allowDelete = false;
                }
                else if(SO!=null)
                {
                    allowDelete = false;
                }
                else if (SI != null)
                {
                    allowDelete = false;
                }
            }
            return allowDelete;
        }

        public bool DeleteCustomer(int custId)
        {
            bool result = false;
            try
            {
                using (SDNCustomersDBEntities entities = new SDNCustomersDBEntities())
                {

                    var obj = entities.Customers.Where(x => x.ID == custId).FirstOrDefault();
                    entities.Customers.Remove(obj);
                    entities.SaveChanges();

                    
                }
                result = true;
            }
            catch 
            {
                result = false;
            }
            return result;
        }

        public bool RefreshCustomer(int custId)
        {
            bool result = false;
            try
            {
                using (SDNCustomersDBEntities entities = new SDNCustomersDBEntities())
                {

                    var obj = entities.Customers.Where(x => x.IsRefreshed==true).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.IsRefreshed = false;
                        entities.SaveChanges();
                    }
                    var obj2 = entities.Customers.Where(x => x.ID == custId).FirstOrDefault();
                    if (obj2 != null)
                    {
                        obj2.IsRefreshed = true;
                        obj2.RefreshedDate = System.DateTime.UtcNow;
                        entities.SaveChanges();
                    }

                }
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public List<string> GetAutoFillData(string EntityType)
        {
            List<string> lstResult = new List<string>();
            if (EntityType != string.Empty)
            {
             
                using (SDNCustomersDBEntities entities = new SDNCustomersDBEntities())
                {
                    if (EntityType.ToLower() == "country")
                    {
                        lstResult = entities.Customers.Select(x => x.Cus_Bill_to_country).Distinct().ToList();
                    }
                    else if (EntityType.ToLower() == "state")
                    {
                        lstResult = entities.Customers.Select(x => x.Cus_Bill_to_state).Distinct().ToList();

                    }
                    else if (EntityType.ToLower() == "city")
                    {
                        lstResult = entities.Customers.Select(x => x.Cus_Bill_to_city).Distinct().ToList();

                    }
                    else if (EntityType.ToLower() == "postalcode")
                    {
                        lstResult = entities.Customers.Select(x => x.Cus_Bill_to_post_code).Distinct().ToList();

                    }

                }
            }
            return lstResult;
        }
    }


}
