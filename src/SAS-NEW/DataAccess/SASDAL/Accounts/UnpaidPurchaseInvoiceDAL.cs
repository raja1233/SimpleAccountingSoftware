using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Accounts
{
    public class UnpaidPurchaseInvoiceDAL : IUnpaidPurchaseInvoiceDAL
    {
        SASEntitiesEDM entity = new SASEntitiesEDM();
        public List<UnpaidPurchaseInvoiceEntity> getSupplierList()
        {
            List<UnpaidPurchaseInvoiceEntity> list = new List<UnpaidPurchaseInvoiceEntity>();
            try
            {
                list = entity.Database.SqlQuery<UnpaidPurchaseInvoiceEntity>("USP_FETCHSUPPLIERRECORD").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        //public string IsChequeNoPresent()
        //{
        //    var status =  "";
        //    var InvoiceNumber = string.Empty;
        //    var _InvoiceNumber = string.Empty;
        //    try
        //    {
        //        InvoiceNumber = (from x in entity.UnpaidPurchaseInvoices orderby x.CreatedDate descending select x.UnpaidPI_No).FirstOrDefault();
        //        if (InvoiceNumber != null)
        //        {
        //            _InvoiceNumber = InvoiceNumber.TrimEnd();
        //            status = _InvoiceNumber;
        //        }
        //        else
        //        {
        //            status = null;
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    return _InvoiceNumber;
        //}
        public List<string> IsChequeNoPresent()
        {
            List<string> InvoiceNumberList = null;
            List<string> InvoiceNumber = new List<string>();
            
            try
            {

                InvoiceNumber = (from x in entity.UnpaidPurchaseInvoices select x.UnpaidPI_No.TrimEnd()).ToList();
                if(InvoiceNumber.Count != 0)
                {
                    InvoiceNumberList = InvoiceNumber;
                }
                else
                {
                    InvoiceNumberList = null;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return InvoiceNumberList;
        }
        public int SaveUnpaidPurchaseInvoiceData(UnpaidPurchaseInvoiceModel JForm)
        {
            //int autoId = 0;
            // UnpaidSalesInvoice obj = new UnpaidSalesInvoice();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {

                    UnpaidPurchaseInvoice obj1;
                    if (JForm.UnpaidPurchaseInvoiceDetailsData != null)
                    {
                        foreach (UnpaidPurchaseInvoiceEntity JEntity in JForm.UnpaidPurchaseInvoiceDetailsData)
                        {
                            //save entity value
                            obj1 = new UnpaidPurchaseInvoice();
                            obj1.S_ID = JEntity.ID;
                            obj1.UnpaidPI_No = JEntity.InvoiceNo;
                            obj1.UnpaidPI_Date = JEntity.InvoiceDateTime;
                            obj1.UnpaidPI_Amount = JEntity.UnpaidAmount;
                            obj1.CreatedDate = DateTime.Now;
                            obj1.IsDeleted = false;
                            if(obj1!=null)
                            {
                                entities.UnpaidPurchaseInvoices.Add(obj1);
                                entities.SaveChanges();
                            }
                            //if (entities.UnpaidPurchaseInvoices.AsNoTracking().FirstOrDefault(x => x.ID == JEntity.ID) == null)
                            //{
                            //    entities.UnpaidPurchaseInvoices.Add(obj1);
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
            //    return 0;
                throw e;
            }
        }
    }
}
