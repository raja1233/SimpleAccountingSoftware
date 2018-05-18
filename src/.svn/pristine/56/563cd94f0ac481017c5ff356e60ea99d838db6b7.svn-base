using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using System.Data.Entity;

namespace SASDAL.Accounts
{
    public class UndeliveredSalesOrdersWithDepositsDAL : IUndeliveredSalesOrdersWithDepositsDAL
    {
        SASEntitiesEDM entity = new SASEntitiesEDM();
        public List<UndeliveredSalesOrdersWithDepositsViewEntity> GetCustomerList()
        {
            List<UndeliveredSalesOrdersWithDepositsViewEntity> list = new List<UndeliveredSalesOrdersWithDepositsViewEntity>();
            try
            {
                list = entity.Database.SqlQuery<UndeliveredSalesOrdersWithDepositsViewEntity>("USP_FETCHCUSTOMERRECORD").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        //public string IsChequeNoPresent()
        //{
        //    var InvoiceNumber = string.Empty;
        //    var _InvoiceNumber = string.Empty;
        //    try
        //    {
        //        InvoiceNumber = (from x in entity.UndeliveredSalesOrderWithDeposits orderby x.CreatedDate descending select x.USalesOrder_No).FirstOrDefault();
        //        _InvoiceNumber = InvoiceNumber.TrimEnd();

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    return _InvoiceNumber;
        //}
        public List<string> IsChequeNoPresent()
        {
            List<string> OrderNumberList = null;
            List<string> OrderNumber = new List<string>();

            try
            {

                OrderNumber = (from x in entity.UndeliveredSalesOrderWithDeposits select x.USalesOrder_No.TrimEnd()).ToList();
                if (OrderNumber.Count != 0)
                {
                    OrderNumberList = OrderNumber;
                }
                else
                {
                    OrderNumberList = null;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return OrderNumberList;
        }
        public int SaveUndeliveredSalesOrderData(UndeliveredSalesOrdersWithDepositsModel model)
        {
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {

                    UndeliveredSalesOrderWithDeposit obj1;
                    if (model.UnpaidSalesInvoiceDetailsData != null)
                    {
                        foreach (UndeliveredSalesOrdersWithDepositsViewEntity JEntity in model.UnpaidSalesInvoiceDetailsData)
                        {
                            //save entity value
                            obj1 = new UndeliveredSalesOrderWithDeposit();
                            obj1.C_ID = JEntity.ID;
                            obj1.USalesOrder_No = JEntity.OrderNo;
                            obj1.USalesOrder_Date = JEntity.OrderDateTime;
                            obj1.USalesOrder_Amount = JEntity.UndeliveredAmount;
                            obj1.USalesOrderDeposit_Amount = JEntity.DepositAmount;
                            obj1.CreatedDate = DateTime.Now;
                            obj1.IsDeleted = false;
                            if (obj1 != null)
                            {
                                entities.UndeliveredSalesOrderWithDeposits.Add(obj1);
                                entities.SaveChanges();
                            }
                            //if (entities.UndeliveredSalesOrderWithDeposits.AsNoTracking().FirstOrDefault(x => x.ID == JEntity.ID) == null)
                            //{
                            //    entities.UndeliveredSalesOrderWithDeposits.Add(obj1);
                            //    entities.SaveChanges();

                            //}
                            //else
                            //{
                            //    entities.Entry(obj1).State = EntityState.Modified;
                            //    entities.SaveChanges();
                            //}
                        }
                    }

                    else
                    {

                    }
                }
                return 1;

            }
            catch (Exception e)
            {
               // return 0;
                throw e;
            }  
    }
    }
}
