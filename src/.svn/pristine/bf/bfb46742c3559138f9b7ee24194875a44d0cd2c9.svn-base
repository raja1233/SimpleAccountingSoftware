using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDN.UI.Entities.Accounts;
using System.Data.Entity;

namespace SASDAL.Accounts
{
    public class UnpaidSalesInvoiceDAL : IUnpaidSalesInvoiceDAL
    {
        SASEntitiesEDM entity = new SASEntitiesEDM();
        public List<UnpaidSalesInvoiceEntity> getCustomerList()
        {
            List<UnpaidSalesInvoiceEntity> list = new List<UnpaidSalesInvoiceEntity>();
            try
            {
                list = entity.Database.SqlQuery<UnpaidSalesInvoiceEntity>("USP_FETCHCUSTOMERRECORD").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        //public string  IsChequeNoPresent()
        //{
        //    var status =  "";
        //    var InvoiceNumber = string.Empty;
        //    var _InvoiceNumber = string.Empty;
        //    try
        //    {

        //        InvoiceNumber = (from x in entity.UnpaidSalesInvoices orderby x.CreatedDate descending select x.UnpaidSI_No).FirstOrDefault();
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
        //    return status;

        //}
        public List<string> IsChequeNoPresent()
        {
            List<string> InvoiceNumberList = null;
            List<string> InvoiceNumber = new List<string>();

            try
            {

                InvoiceNumber = (from x in entity.UnpaidSalesInvoices select x.UnpaidSI_No.TrimEnd()).ToList();
                if (InvoiceNumber.Count != 0)
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

        public int SaveUnpaidSalesInvoiceData(UnpaidSalesInvoiceModel JForm)
        {
            //int autoId = 0;
           // UnpaidSalesInvoice obj = new UnpaidSalesInvoice();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    
                        UnpaidSalesInvoice obj1;
                        if (JForm.UnpaidSalesInvoiceDetailsData != null)
                        {
                            foreach (UnpaidSalesInvoiceEntity JEntity in JForm.UnpaidSalesInvoiceDetailsData)
                            {
                                //save entity value
                                obj1 = new UnpaidSalesInvoice();
                                obj1.C_ID = JEntity.ID;
                                obj1.UnpaidSI_No = JEntity.InvoiceNo;
                                obj1.UnpaidSI_Date = JEntity.InvoiceDateTime;
                                obj1.UnpaidSI_Amount = JEntity.UnpaidAmount;
                                obj1.CreatedDate = DateTime.Now;
                                obj1.IsDeleted = false;
                                if (obj1 != null)
                                {
                                    entities.UnpaidSalesInvoices.Add(obj1);
                                    entities.SaveChanges();
                                }
                            //    if (entities.UnpaidSalesInvoices.AsNoTracking().FirstOrDefault(x => x.ID == JEntity.ID) == null)
                            //    {
                            //        entities.UnpaidSalesInvoices.Add(obj1);
                            //        entities.SaveChanges();

                            //    }
                            //    else
                            //    {
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
                //return 0;
                throw e;
            }
        }
    }
}
