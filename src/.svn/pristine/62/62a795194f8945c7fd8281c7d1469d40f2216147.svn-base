using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Accounts
{
    public class UndeliveredPurchaseOrdersDepositsDAL : IUndeliveredPurchaseOrdersDepositsDAL
    {
        SASEntitiesEDM entity = new SASEntitiesEDM();
        public List<UndeliveredPurchaseOrdersDepositsEntity> getSupplierList()
        {
            List<UndeliveredPurchaseOrdersDepositsEntity> list = new List<UndeliveredPurchaseOrdersDepositsEntity>();
            try
            {
                list = entity.Database.SqlQuery<UndeliveredPurchaseOrdersDepositsEntity>("USP_FETCHSUPPLIERRECORD").ToList();
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
        //        InvoiceNumber = (from x in entity.UndeliveredPurchaseOrdersWithDeposits orderby x.CreatedDate descending select x.UPurchaseOrder_No).FirstOrDefault();
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

                OrderNumber = (from x in entity.UndeliveredPurchaseOrdersWithDeposits select x.UPurchaseOrder_No.TrimEnd()).ToList();
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

        public int SaveUndeliveredPurchaseOrdersDepositsData(UndeliveredPurchaseOrdersDepositsModel JForm)
        {
            //int autoId = 0;
            // UnpaidSalesInvoice obj = new UnpaidSalesInvoice();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {

                    UndeliveredPurchaseOrdersWithDeposit obj1;
                    if (JForm.UndeliveredPurchaseOrdersDepositsDetailsData != null)
                    {
                        foreach (UndeliveredPurchaseOrdersDepositsEntity JEntity in JForm.UndeliveredPurchaseOrdersDepositsDetailsData)
                        {
                            //save entity value
                            obj1 = new UndeliveredPurchaseOrdersWithDeposit();
                            obj1.S_ID = JEntity.ID;
                            obj1.UPurchaseOrder_No = JEntity.OrderNo;
                            obj1.UPurchaseOrder_Date = JEntity.OrderDateTime;
                            obj1.UPurchaseOrder_Amount = JEntity.UndeliveredAmount;
                            obj1.UPurchaseOrderDeposit_Amount = JEntity.DepositAmount;
                            obj1.CreatedDate = DateTime.Now;
                            obj1.IsDeleted = false;
                            if (obj1 != null)
                            {
                                entities.UndeliveredPurchaseOrdersWithDeposits.Add(obj1);
                                entities.SaveChanges();
                            }
                            //if (entities.UndeliveredPurchaseOrdersWithDeposits.AsNoTracking().FirstOrDefault(x => x.ID == JEntity.ID) == null)
                            //{
                            //    entities.UndeliveredPurchaseOrdersWithDeposits.Add(obj1);
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
                return 0;
                throw e;
            }
        }
    }
}
