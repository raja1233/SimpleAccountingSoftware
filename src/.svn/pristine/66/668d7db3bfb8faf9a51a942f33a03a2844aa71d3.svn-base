

namespace SDN.Purchasings.DAL
{
    using System;
    using Purchasings.DAL;
    using SDN.Purchasings.DALInterface;
    using UI.Entities;

    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using Common;
    using SASDAL;

    public class PurchaseOrderDAL : IPurchaseOrderDAL
    {
        /// <summary>
        /// This method is used to add or edit purchase order
        /// </summary>
        /// <param name="orderData"></param>
        /// <returns></returns>
        public int AddUpdateOrder(PurchaseOrderForm orderData)
        {
            int autoId = 0;
            //Add purchase order
            PurchaseOrder obj = new PurchaseOrder();
            obj.ID = orderData.Order.ID;
            obj.Sup_Id = orderData.Order.SupplierID;
            //obj.PO_Conv_to_PO = orderData.Order.PO_Conv_to_PO;
            obj.PO_Conv_to_PI = orderData.Order.PO_Conv_to_PI;
            //obj.PO_Date = orderData.Order.OrderDate;
            obj.PO_Date =orderData.Order.OrderDate;
            obj.PO_GST_Amt = Convert.ToDecimal(orderData.Order.TotalTax);
            obj.PO_No = orderData.Order.OrderNo;
            obj.PO_TandC = orderData.Order.TermsAndConditions;
            obj.PO_Tot_aft_Tax = Convert.ToDecimal(orderData.Order.TotalAfterTax);
            obj.PO_Tot_bef_Tax = Convert.ToDecimal(orderData.Order.TotalBeforeTax);
            obj.PO_Status = Convert.ToByte(PO_Status.unDeposited);
            obj.PO_Del_Date = orderData.Order.DeliveryDate;
            obj.Exc_Inc_GST = orderData.Order.ExcIncGST;
            obj.IsDeleted = false;

            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    if (entities.PurchaseOrders.AsNoTracking().FirstOrDefault(x => x.ID == orderData.Order.ID) == null)
                    {
                        //obj.CreatedBy = orderData.POModel.CreatedBy;
                        obj.CreatedDate = DateTime.Now;
                        entities.PurchaseOrders.Add(obj);
                        entities.SaveChanges();
                        autoId = obj.ID;
                    }
                    else
                    {
                        // obj.ModifiedBy = orderData.POModel.ModifiedBy;
                        obj.ModifiedDate = DateTime.Now;
                        entities.Entry(obj).State = EntityState.Modified;
                        autoId = entities.SaveChanges();
                    }
                    if (autoId > 0)
                    {
                        PurchaseOrderDetail PODetails;
                        if (orderData.OrderDetails != null)
                        {
                            foreach (PurchaseOrderDetailEntity PODetailEntity in orderData.OrderDetails)
                            {
                                PODetails = new PurchaseOrderDetail();
                                PODetails.PO_ID = autoId;
                                PODetails.PO_No = PODetailEntity.PONo;
                                PODetails.PandS_Code = PODetailEntity.PandSCode;
                                PODetails.PandS_Name = PODetailEntity.PandSName;
                                PODetails.PO_Amount = PODetailEntity.POAmount;
                                PODetails.PO_Discount = PODetailEntity.PODiscount;
                                PODetails.PO_No = PODetailEntity.PONo;
                                PODetails.PO_Price = Convert.ToDecimal(PODetailEntity.POPrice);
                                PODetails.PO_Qty = PODetailEntity.POQty;
                                PODetails.GST_Code = PODetailEntity.GSTCode;
                                PODetails.GST_Rate = PODetailEntity.GSTRate;

                                if (entities.PurchaseOrderDetails.AsNoTracking().FirstOrDefault(x => x.ID == PODetailEntity.ID) == null)
                                {
                                    entities.PurchaseOrderDetails.Add(PODetails);
                                    entities.SaveChanges();

                                }
                                else
                                {
                                    entities.Entry(PODetails).State = EntityState.Modified;
                                    entities.SaveChanges();
                                }
                                int PSId = Convert.ToInt32(PODetailEntity.PONo);
                                if (PSId != 0)
                                {
                                    ProductsAndService ps = entities.ProductsAndServices.SingleOrDefault(e => e.ID == PSId);
                                    if (ps != null)
                                    {
                                        ps.PandS_Qty_on_PO = ps.PandS_Qty_on_PO + PODetailEntity.POQty;
                                        entities.SaveChanges();
                                    }
                                }
                            }
                          
                        }
                    }
                }
                return autoId;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int UpdationOrder(PurchaseOrderForm orderData)
        {
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    PurchaseOrder obj = entities.PurchaseOrders.Where(e => e.PO_No == orderData.Order.OrderNo
                    ).SingleOrDefault();
                    if (obj != null)
                    {
                        //obj.ID = orderData.Order.ID;
                        obj.Sup_Id = orderData.Order.SupplierID;
                        // obj.PO_Conv_to_PO = orderData.Order.PO_Conv_to_PO;
                        // obj.PO_Conv_to_PI = orderData.Order.PO_Conv_to_PI;
                        obj.PO_Date =orderData.Order.OrderDate;
                        obj.PO_GST_Amt = Convert.ToDecimal(orderData.Order.TotalTax);
                        obj.PO_No = orderData.Order.OrderNo;
                        obj.PO_TandC = orderData.Order.TermsAndConditions;
                        obj.PO_Tot_aft_Tax = Convert.ToDecimal(orderData.Order.TotalAfterTax);
                        obj.PO_Tot_bef_Tax = Convert.ToDecimal(orderData.Order.TotalBeforeTax);
                        //obj.PO_Valid_for = orderData.Order.ValidForDays;
                        obj.PO_Del_Date = orderData.Order.DeliveryDate;
                        obj.Exc_Inc_GST = orderData.Order.ExcIncGST;
                        obj.ModifiedDate = DateTime.Now;
                        entities.SaveChanges();
                    }

                    var objPurchase = entities.PurchaseOrderDetails.Where
                        (e => e.PO_ID == obj.ID).ToList();
                    if (objPurchase != null)
                    {
                        foreach (var item in objPurchase)
                        {
                            int PSId = Convert.ToInt32(item.PO_No);
                            if (PSId != 0)
                            {
                                ProductsAndService ps = entities.ProductsAndServices.SingleOrDefault(e => e.ID == PSId);
                                if (ps != null)
                                {
                                    ps.PandS_Qty_on_PO = ps.PandS_Qty_on_PO - item.PO_Qty;
                                    entities.SaveChanges();
                                }
                            }
                            entities.PurchaseOrderDetails.Remove(item);
                            entities.SaveChanges();
                        }
                    }
                    PurchaseOrderDetail PODetails;
                    if (orderData.OrderDetails != null)
                    {
                        foreach (PurchaseOrderDetailEntity PODetailEntity in orderData.OrderDetails)
                        {
                            PODetails = new PurchaseOrderDetail();
                            PODetails.PO_ID = obj.ID;
                            PODetails.PO_No = PODetailEntity.PONo;
                            PODetails.PandS_Code = PODetailEntity.PandSCode;
                            PODetails.PandS_Name = PODetailEntity.PandSName;
                            PODetails.PO_Amount = PODetailEntity.POAmount;
                            PODetails.PO_Discount = PODetailEntity.PODiscount;
                            PODetails.PO_No = PODetailEntity.PONo;
                            PODetails.PO_Price = Convert.ToDecimal(PODetailEntity.POPrice);
                            PODetails.PO_Qty = PODetailEntity.POQty;
                            PODetails.GST_Code = PODetailEntity.GSTCode;
                            PODetails.GST_Rate = PODetailEntity.GSTRate;

                            entities.PurchaseOrderDetails.Add(PODetails);
                            entities.SaveChanges();

                            int PSId = Convert.ToInt32(PODetailEntity.PONo);
                            if (PSId != 0)
                            {
                                ProductsAndService ps = entities.ProductsAndServices.SingleOrDefault(e => e.ID == PSId);
                                if (ps != null)
                                {
                                    ps.PandS_Qty_on_PO = ps.PandS_Qty_on_PO + PODetailEntity.POQty;
                                    entities.SaveChanges();
                                }
                            }
                        }
                    }
                    return obj.ID;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CanDeleteOrder(int pqID)
        {
            byte deposited = Convert.ToByte(PO_Status.Collected);
            byte refunded = Convert.ToByte(PO_Status.Refunded);
            bool allowDelete = true;
            using (SASEntitiesEDM entities = new SASEntitiesEDM())
            {
                var PO_PI = entities.PurchaseOrders.Where(x => (x.PO_Conv_to_PI == true) && x.ID == pqID).FirstOrDefault();
                var PO = entities.PurchaseOrders.Where(x => (x.PO_Status == deposited || x.PO_Status == refunded) && x.ID==pqID ).FirstOrDefault();
                if (PO_PI != null || PO!=null)
                {
                    allowDelete = false;
                }

            }
            return allowDelete;
        }

        public bool DeleteQuotatoin(int pqID)
        {
            bool result = false;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var detailList = entities.PurchaseOrderDetails.Where(x => x.PO_ID == pqID).ToList();
                    if (detailList != null)
                    {
                        foreach (PurchaseOrderDetail pqdetail in detailList)
                        {
                            int PSId = Convert.ToInt32(pqdetail.PO_No);
                            if (PSId != 0)
                            {
                                ProductsAndService ps = entities.ProductsAndServices.SingleOrDefault(e => e.ID == PSId);
                                if (ps != null)
                                {
                                    ps.PandS_Qty_on_PO = ps.PandS_Qty_on_PO - pqdetail.PO_Qty;
                                    entities.SaveChanges();
                                }
                            }

                            pqdetail.PO_Qty = 0;
                            pqdetail.PO_Price = 0;
                            pqdetail.PO_Discount = 0;
                            pqdetail.PO_Amount = 0;
                            pqdetail.GST_Rate = 0;
                            entities.SaveChanges();
                        }

                    }
                    var obj = entities.PurchaseOrders.Where(x => x.ID == pqID).FirstOrDefault();
                    //entities.PurchaseOrders.Remove(obj);
                    if (obj != null)
                    {
                        obj.PO_Status = Convert.ToByte(PO_Status.Cancelled);
                        obj.PO_Tot_bef_Tax = 0;
                        obj.PO_Tot_aft_Tax = 0;
                        obj.PO_GST_Amt = 0;
                        obj.IsDeleted = true;
                        obj.ModifiedDate = DateTime.Now;
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

        public int GetLastInvoiceNo()
        {
            int qno = 0;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var pq = (from pqs in entities.PurchaseInvoices
                              orderby pqs.ID descending
                              select new
                              {
                                  pqs.ID,
                                  pqs.CreatedDate
                              }

                             );
                    if (pq != null)
                    {
                        qno = pq.Take(1).SingleOrDefault().ID;
                    }
                    else
                    {
                        qno = 0;
                    }
                }
                return qno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method is used to get category content 
        /// </summary>
        /// <returns></returns>
        public string GetCategoryContent(string catType)
        {
            string tandCContent = string.Empty;
            using (SASEntitiesEDM objProdEntities = new SASEntitiesEDM())
            {
                try
                {
                    var tandC = (from content in objProdEntities.TermsAndConditions
                                 where content.Cat_Code == catType
                                 select new ContentModel
                                 {
                                     ContentName = content.Cat_Content,
                                     ContentID = content.ID
                                 });
                    if (tandC != null)
                    {
                        tandCContent = tandC.SingleOrDefault().ContentName;
                    }
                    return tandCContent;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }



        public int GetLastOrderNo()
        {
            int qno = 0;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var pq = (from pqs in entities.PurchaseOrders
                              orderby pqs.ID descending
                              select new
                              {
                                  pqs.ID,
                                  pqs.CreatedDate
                              }

                             );
                    int Count = Convert.ToInt32(pq.Count());
                    if (Count>0)
                    {
                        qno = pq.Take(1).SingleOrDefault().ID;
                    }
                    else
                    {
                        qno = 0;
                    }
                }
                return qno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// This method is used to get latest quitation no
        ///// </summary>
        ///// <returns></returns>
        //public int GetLastOrderNo()
        //{
        //    int qno = 0;
        //    try
        //    {
        //        using (SASEntitiesEDM entities = new SASEntitiesEDM())
        //        {
        //            var pq = (from pqs in entities.PurchaseOrders
        //                      orderby pqs.ID descending
        //                      select new
        //                      {
        //                          pqs.ID,
        //                          pqs.CreatedDate
        //                      }

        //                     );
        //            if (pq != null)
        //            {
        //                qno = pq.Take(1).SingleOrDefault().ID;
        //            }
        //            else
        //            {
        //                qno = 0;
        //            }
        //        }
        //        return qno;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// This method is used to get all purchase orders
        /// </summary>
        /// <returns></returns>
        public List<PurchaseOrderEntity> GetAllPurchaseOrders()
        {
            // List<PurchaseOrderModel> lstPOF = new List<PurchaseOrderForm>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var lstPOs = (from pq in entities.PurchaseOrders
                                  where (pq.IsDeleted == false || pq.IsDeleted == null)

                                  select new PurchaseOrderEntity
                                  {
                                      SupplierID = pq.Sup_Id,
                                      OrderNo = pq.PO_No,
                                      OrderDate = pq.PO_Date,
                                      //ValidForDays = pq.PO_Valid_for,,
                                      DeliveryDate = pq.PO_Del_Date,
                                      TotalBeforeTax = pq.PO_Tot_bef_Tax,
                                      TotalTax = pq.PO_GST_Amt,
                                      TotalAfterTax = pq.PO_Tot_aft_Tax,
                                      TermsAndConditions = pq.PO_TandC,
                                     
                                      CreatedBy = pq.CreatedBy,
                                      CreatedDate = pq.CreatedDate

                                  }).ToList<PurchaseOrderEntity>();

                    return lstPOs;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ConvertToPurchaseInvoice(PurchaseOrderForm orderData)
        {
            int autoId = 0;
            
            PurchaseInvoice obj = new PurchaseInvoice();
            // obj.ID = orderData.Order.ID;
            obj.Sup_Id = orderData.Order.SupplierID;
            obj.PI_Date = orderData.Order.OrderDate;

            obj.PI_GST_Amt = Convert.ToDecimal(orderData.Order.TotalTax);
            obj.PI_No = "PI-" + (GetLastInvoiceNo() + 1);
            obj.PI_TandC = orderData.Order.TermsAndConditions;
            obj.PI_Tot_aft_Tax = Convert.ToDecimal(orderData.Order.TotalAfterTax);
            obj.PI_Tot_bef_Tax = Convert.ToDecimal(orderData.Order.TotalBeforeTax);
            obj.PI_Status = 2;
            obj.Exc_Inc_GST = orderData.Order.ExcIncGST;
            obj.IsDeleted = false;

            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    if (entities.PurchaseInvoices.AsNoTracking().FirstOrDefault(x => x.ID == orderData.Order.ID) == null)
                    {
                        //obj.CreatedBy = orderData.POModel.CreatedBy;
                        obj.CreatedDate = DateTime.Now;
                        entities.PurchaseInvoices.Add(obj);
                        entities.SaveChanges();
                        autoId = obj.ID;
                       
                    }
                    else
                    {
                        // obj.ModifiedBy = orderData.POModel.ModifiedBy;
                        obj.ModifiedDate = DateTime.Now;
                        entities.Entry(obj).State = EntityState.Modified;
                        autoId = entities.SaveChanges();
                    }
                    if (autoId > 0)
                    {
                        PurchaseInvoiceDetail PODetails;
                        if (orderData.OrderDetails != null)
                        {
                            foreach (PurchaseOrderDetailEntity PODetailEntity in orderData.OrderDetails)
                            {
                                PODetails = new PurchaseInvoiceDetail();
                                PODetails.PI_ID = autoId;
                                PODetails.PI_No = PODetailEntity.PONo;
                                PODetails.PandS_Code = PODetailEntity.PandSCode;
                                PODetails.PandS_Name = PODetailEntity.PandSName;
                                PODetails.PI_Amount = PODetailEntity.POAmount;
                                PODetails.PI_Discount = PODetailEntity.PODiscount;
                                PODetails.PI_No = PODetailEntity.PONo;
                                PODetails.PI_Price = Convert.ToDecimal(PODetailEntity.POPrice);
                                PODetails.PI_Qty = PODetailEntity.POQty;
                                PODetails.GST_Code = PODetailEntity.GSTCode;
                                PODetails.GST_Rate = PODetailEntity.GSTRate;

                                if (entities.PurchaseInvoiceDetails.AsNoTracking().FirstOrDefault(x => x.ID == PODetailEntity.ID) == null)
                                {
                                    entities.PurchaseInvoiceDetails.Add(PODetails);
                                    entities.SaveChanges();

                                }
                                else
                                {
                                    entities.Entry(PODetails).State = EntityState.Modified;
                                    entities.SaveChanges();
                                }
                                int PSId = Convert.ToInt32(PODetailEntity.PONo);
                                if (PSId != 0)
                                {
                                    ProductsAndService ps = entities.ProductsAndServices.SingleOrDefault(e => e.ID == PSId);
                                    if (ps != null)
                                    {
                                        ps.PandS_Qty_in_stock = ps.PandS_Qty_in_stock + PODetailEntity.POQty;
                                        entities.SaveChanges();
                                    }
                                }
                            }
                        }

                        PurchaseOrder objQ = entities.PurchaseOrders.Where(e => e.PO_No == orderData.Order.OrderNo
                           ).SingleOrDefault();
                        if (objQ != null)
                        {
                            objQ.PO_Conv_to_PI = true;
                            objQ.Conv_to_No = obj.PI_No;
                            objQ.ModifiedDate = DateTime.Now;
                            entities.SaveChanges();
                        }
                    }
                }
                return autoId;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// This method is used to convert the Purchase order to order
        /// </summary>
        /// <param name="orderData"></param>
        /// <returns></returns>
        public int ConvertToPurchaseOrder(PurchaseOrderForm orderData)
        {
            int autoId = 0;
            //Add purchase order          
            PurchaseOrder obj = new PurchaseOrder();
            //obj.ID = orderData.Order.ID;
            obj.Sup_Id = orderData.Order.SupplierID;
            obj.PO_Date = orderData.Order.OrderDate;
            obj.PO_Del_Date = DateTime.Now;
            obj.PO_GST_Amt = Convert.ToDecimal(orderData.Order.TotalTax);
            obj.PO_No = "PO-" + GetLastOrderNo();
            obj.PO_TandC = orderData.Order.TermsAndConditions;
            obj.PO_Tot_aft_Tax = Convert.ToDecimal(orderData.Order.TotalAfterTax);
            obj.PO_Tot_bef_Tax = Convert.ToDecimal(orderData.Order.TotalBeforeTax);

            obj.Exc_Inc_GST = orderData.Order.ExcIncGST;
            obj.IsDeleted = false;

            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    if (entities.PurchaseOrders.AsNoTracking().FirstOrDefault(x => x.ID == orderData.Order.ID) == null)
                    {
                        //obj.CreatedBy = orderData.POModel.CreatedBy;
                        obj.CreatedDate = DateTime.Now;
                        entities.PurchaseOrders.Add(obj);
                        entities.SaveChanges();
                        autoId = obj.ID;
                       
                    }
                    else
                    {
                        // obj.ModifiedBy = orderData.POModel.ModifiedBy;
                        obj.ModifiedDate = DateTime.Now;
                        entities.Entry(obj).State = EntityState.Modified;
                        autoId = entities.SaveChanges();
                    }
                    if (autoId > 0)
                    {
                        PurchaseOrderDetail PODetails;
                        if (orderData.OrderDetails != null)
                        {
                            foreach (PurchaseOrderDetailEntity PODetailEntity in orderData.OrderDetails)
                            {
                                PODetails = new PurchaseOrderDetail();
                                PODetails.PO_ID = autoId;
                                PODetails.PO_No = PODetailEntity.PONo;
                                PODetails.PandS_Code = PODetailEntity.PandSCode;
                                PODetails.PandS_Name = PODetailEntity.PandSName;
                                PODetails.PO_Amount = PODetailEntity.POAmount;
                                PODetails.PO_Discount = PODetailEntity.PODiscount;
                                PODetails.PO_No = PODetailEntity.PONo;
                                PODetails.PO_Price = Convert.ToDecimal(PODetailEntity.POPrice);
                                PODetails.PO_Qty = PODetailEntity.POQty;
                                PODetails.GST_Code = PODetailEntity.GSTCode;
                                PODetails.GST_Rate = PODetailEntity.GSTRate;

                                if (entities.PurchaseOrderDetails.AsNoTracking().FirstOrDefault(x => x.ID == PODetailEntity.ID) == null)
                                {
                                    entities.PurchaseOrderDetails.Add(PODetails);
                                    entities.SaveChanges();

                                }
                                else
                                {
                                    entities.Entry(PODetails).State = EntityState.Modified;
                                    entities.SaveChanges();
                                }

                            }
                        }

                        PurchaseOrder objQ = entities.PurchaseOrders.Where(e => e.PO_No == orderData.Order.OrderNo
                           ).SingleOrDefault();
                        if (objQ != null)
                        {
                            //objQ.PO_Conv_to_PO = true;
                            objQ.ModifiedDate = DateTime.Now;
                            entities.SaveChanges();
                        }
                    }
                }
                return autoId;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method is used to get Purchase Order details
        /// </summary>
        /// <param name="pqId"></param>
        /// <returns></returns>
        public PurchaseOrderForm GetPurchaseOrder(string pqno)
        {
            PurchaseOrderForm pqf = new PurchaseOrderForm();

            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var pq = (from pqs in entities.PurchaseOrders
                              where pqs.PO_No == pqno && (pqs.IsDeleted == false || pqs.IsDeleted == null)
                              select new PurchaseOrderEntity
                              {
                                  ID = pqs.ID,
                                  SupplierID = pqs.Sup_Id,
                                  OrderNo = pqs.PO_No,
                                  OrderDate = pqs.PO_Date,
                                  //ValidForDays = pqs.PO_Valid_for,
                                  
                                  TermsAndConditions = pqs.PO_TandC,
                                  TotalBeforeTax = pqs.PO_Tot_bef_Tax,
                                  TotalTax = pqs.PO_GST_Amt,
                                  TotalAfterTax = pqs.PO_Tot_aft_Tax,
                                  ExcIncGST = pqs.Exc_Inc_GST,
                                  PO_Conv_to_PI = pqs.PO_Conv_to_PI,
                                  DeliveryDate = pqs.PO_Del_Date,
                                  Status=pqs.PO_Status
                                  //PO_Conv_to_PO = pqs.PO_Conv_to_PO
                                  
                              }).SingleOrDefault();

                    if (pq != null)
                    {
                        pqf.Order = pq;
                    }


                    var pqd = (from pqds in entities.PurchaseOrderDetails
                               where pqds.PO_ID == pq.ID
                               select new PurchaseOrderDetailEntity
                               {
                                   ID = pqds.ID,
                                   POID = pqds.PO_ID,
                                   PONo = pqds.PO_No,
                                   PandSCode = pqds.PandS_Code,
                                   PandSName = pqds.PandS_Name,
                                   POQty = pqds.PO_Qty,
                                   Price = pqds.PO_Price,
                                   PODiscount = pqds.PO_Discount,
                                   POAmount = pqds.PO_Amount,
                                   GSTRate = pqds.GST_Rate
                               }).ToList<PurchaseOrderDetailEntity>();

                    if (pqd != null)
                    {

                        pqf.OrderDetails = pqd;
                    }

                    return pqf;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PurchaseOrderForm GetPrintPurchaseOrder(string pino)
        {
            PurchaseOrderForm pif = new PurchaseOrderForm();

            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var pi = (from pis in entities.PurchaseOrders
                              join Sup in entities.Suppliers on pis.Sup_Id equals Sup.ID
                              where pis.PO_No == pino && (pis.IsDeleted == false || pis.IsDeleted == null)
                              select new PurchaseOrderEntity
                              {
                                  ID = pis.ID,
                                  SupplierID = pis.Sup_Id,
                                  SupplierName = Sup.Sup_Name,
                                  SupplierBillAddress1 = Sup.Sup_Bill_to_line1,
                                  SupplierBillAddress2 = Sup.Sup_Bill_to_line2,
                                  SupplierBillAddressCity = Sup.Sup_Bill_to_city,
                                  SupplierBillAddressState = Sup.Sup_Bill_to_state,
                                  SupplierBillAddressCountary = Sup.Sup_Bill_to_country,
                                  SupplierShipPostCode = Sup.Sup_Bill_to_post_code,
                                  SupplierTelephone = Sup.Sup_Telephone,
                                  OrderNo= pis.PO_No,
                                  OrderDate = pis.PO_Date,
                                  DeliveryDate = pis.PO_Del_Date,
                                  PurchaseInvoiceNo = pis.Conv_to_No,
                                  TermsAndConditions = pis.PO_TandC,
                                  TotalBeforeTax = pis.PO_Tot_bef_Tax,
                                  TotalTax = pis.PO_GST_Amt,
                                  TotalAfterTax = pis.PO_Tot_aft_Tax,
                                  ExcIncGST = pis.Exc_Inc_GST
                             

                              }).SingleOrDefault();
                    //var PaymentDueDate1 =pi.InvoiceDate.AddDays(Convert.ToInt32(pi.CreditDays));

                    if (pi != null)
                    {
                        pif.Order = pi;
                    }

                    //for comapany details

                    var company = (from com in entities.CompanyDetails
                                   where (com.IsDeleted == false || com.IsDeleted == null)
                                   select new PurchaseOrderEntity
                                   {
                                       CompanyName = com.Comp_Name,
                                       CompanyRegNumber = com.Comp_Reg_No,
                                       CompanyLogo = com.Comp_Logo,
                                       CompanyGstNumber = com.Comp_GST_Reg_No,
                                       CompanyBillToAddressLine1 = com.Comp_Bill_to_line1,
                                       CompanyBillToAddressLine2 = com.Comp_Bill_to_line2,
                                       CompanyBillToCity = com.Comp_Bill_to_city,
                                       CompanyBillToState = com.Comp_Bill_to_state,
                                       CompanyBillToCountary = com.Comp_Bill_to_country,
                                       CompanyBillToPostCode = com.Comp_Bill_to_post_code,
                                       CompanyShipToAddressLine1 = com.Comp_Ship_to_line1,
                                       CompanyShipToAddressLine2 = com.Comp_Ship_to_line2,
                                       CompanyShipToCity = com.Comp_Ship_to_city,
                                       CompanyShipToState = com.Comp_Ship_to_state,
                                       CompanyShipToCountary = com.Comp_Ship_to_country,
                                       CompanyShipToPostCode = com.Comp_Ship_to_post_code,
                                       CompanyEmail = com.Comp_Email,
                                       CompanyFax = com.Comp_Fax
                                   }).SingleOrDefault();

                    pif.Order.CompanyName = company.CompanyName;
                    pif.Order.CompanyLogo = company.CompanyLogo;
                    pif.Order.CompanyRegNumber = company.CompanyRegNumber;
                    pif.Order.CompanyGstNumber = company.CompanyGstNumber;
                    pif.Order.CompanyBillToAddressLine1 = company.CompanyBillToAddressLine1;
                    pif.Order.CompanyBillToAddressLine2 = company.CompanyBillToAddressLine2;
                    pif.Order.CompanyBillToCity = company.CompanyBillToCity;
                    pif.Order.CompanyBillToState = company.CompanyBillToState;
                    pif.Order.CompanyBillToCountary = company.CompanyBillToCountary;
                    pif.Order.CompanyBillToPostCode = company.CompanyBillToPostCode;
                    pif.Order.CompanyShipToAddressLine1 = company.CompanyShipToAddressLine1;
                    pif.Order.CompanyShipToAddressLine2 = company.CompanyShipToAddressLine2;
                    pif.Order.CompanyShipToCity = company.CompanyShipToCity;
                    pif.Order.CompanyShipToState = company.CompanyShipToState;
                    pif.Order.CompanyShipToCountary = company.CompanyShipToCountary;
                    pif.Order.CompanyShipToPostCode = company.CompanyShipToPostCode;
                    pif.Order.CompanyEmail = company.CompanyEmail;
                    pif.Order.CompanyFax = company.CompanyFax;
                    //end for comapany details

                    //option details
                    var optiondata = (from option in entities.Options
                                      select new PurchaseOrderEntity
                                      {
                                          CurrencyCode = option.Currency_Code
                                      }).SingleOrDefault();
                    pif.Order.CurrencyCode = optiondata.CurrencyCode;
                    //end options details

                    var pid = (from pids in entities.PurchaseOrderDetails
                               where pids.PO_ID == pi.ID
                               select new PurchaseOrderDetailEntity
                               {
                                   ID = pids.ID,
                                   POID = pids.PO_ID,
                                   PONo = pids.PO_No,
                                   PandSCode = pids.PandS_Code,
                                   PandSName = pids.PandS_Name,
                                   POQty = pids.PO_Qty,
                                   Price = pids.PO_Price,
                                   PODiscount = pids.PO_Discount,
                                   POAmount = pids.PO_Amount,
                                   GSTRate = pids.GST_Rate,
                                   GSTCode = pids.GST_Code
                               }).ToList<PurchaseOrderDetailEntity>();

                    if (pid != null)
                    {

                        pif.OrderDetails = pid;
                    }

                    return pif;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
