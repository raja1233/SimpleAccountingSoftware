
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.DAL
{
    using ProductEDM;
    using Common;
    using SDN.Products.DALInterface;
    using UI.Entities.Product;

    public class CountAndAdjustStockDAL: ICountAndAdjustStockDAL
    { 

       public int SaveCountAndAdjustStock(CountAndAdjustStockForm casForm)
        {
            try
            {
                using (SDNProductDBEntities entities = new SDNProductDBEntities())
                {
                    foreach (var item in casForm.CountAndAdjustStockDetails)
                    {
                        StockCount obj = new StockCount();
                        obj.Stock_count_no = casForm.CountAndAdjustStock.StockCountNo;
                        obj.StockDate = casForm.CountAndAdjustStock.StockDate;
                        obj.StockType = casForm.CountAndAdjustStock.StockType;

                        //saving details entity
                        obj.PSID = item.PSID;
                        obj.PandS_Code = item.PandSCode;
                        obj.PandS_Name = item.PandSName;
                        obj.SysQty = item.SystemQty;
                        obj.CountQty = item.CountQty;
                        obj.Difference = item.Difference;
                        obj.Average_Cost = Convert.ToDecimal(item.AvgCost);
                        obj.Amount = item.Amount;
                        obj.Adjusted_Amount = item.AdjustedAmount;
                        obj.UpdatedBy = 0;
                        obj.UpdatedDate = DateTime.Now;

                        entities.StockCounts.Add(obj);
                        entities.SaveChanges();

                        ProductsAndService ps = entities.ProductsAndServices.SingleOrDefault(e => e.ID == item.PSID);
                        if (ps != null)
                        {
                            if (casForm.CountAndAdjustStock.StockType == Convert.ToByte(Stock_Type.StockDamaged))
                            {
                                ps.PandS_Qty_in_stock = ps.PandS_Qty_in_stock - Convert.ToInt32(Math.Abs(Convert.ToInt32(item.CountQty)));
                                entities.SaveChanges();
                            }
                            else
                            {
                                ps.PandS_Qty_in_stock = ps.PandS_Qty_in_stock + item.CountQty;
                                entities.SaveChanges();
                            }
                        }
                    }

                 }
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            return 1;
        }
        public int UpdateCountAndAdjustStock(CountAndAdjustStockForm casForm)
        {
            try
            {
                using (SDNProductDBEntities entities = new SDNProductDBEntities())
                {
                    
                    var data = entities.StockCounts.Where(e => e.Stock_count_no == casForm.CountAndAdjustStock.StockCountNo).ToList();
                    if(data!=null)
                    {
                        foreach (var d in data)
                        {
                            ProductsAndService psOld = entities.ProductsAndServices.SingleOrDefault(e => e.ID == d.PSID);
                            if (psOld != null)
                            {
                                if (d.StockType == Convert.ToByte(Stock_Type.StockDamaged))
                                {
                                    psOld.PandS_Qty_in_stock = psOld.PandS_Qty_in_stock + Convert.ToInt32(Math.Abs(Convert.ToInt32(d.CountQty)));
                                    entities.SaveChanges();
                                }
                                else
                                {
                                    psOld.PandS_Qty_in_stock = psOld.PandS_Qty_in_stock - d.CountQty;
                                    entities.SaveChanges();
                                }
                            }

                            var item = casForm.CountAndAdjustStockDetails.SingleOrDefault(e => e.PSID == d.PSID);
                            if(item!=null)
                            {
                                //saving details entity
                                d.PandS_Code = item.PandSCode;
                                d.PandS_Name = item.PandSName;
                                d.SysQty = item.SystemQty;
                                d.CountQty = item.CountQty;
                                d.Difference = item.Difference;
                                d.Average_Cost = Convert.ToDecimal(item.AvgCost);
                                d.Amount = item.Amount;
                                d.Adjusted_Amount = item.AdjustedAmount;
                                d.UpdatedBy = 0;
                                d.UpdatedDate = DateTime.Now;
                                entities.SaveChanges();
                            }

                            ProductsAndService ps = entities.ProductsAndServices.SingleOrDefault(e => e.ID == d.PSID);
                            if (ps != null)
                            {
                                if (casForm.CountAndAdjustStock.StockType == Convert.ToByte(Stock_Type.StockDamaged))
                                {
                                    ps.PandS_Qty_in_stock = ps.PandS_Qty_in_stock - Convert.ToInt32(Math.Abs(Convert.ToInt32(d.CountQty)));
                                    entities.SaveChanges();
                                }
                                else
                                {
                                    ps.PandS_Qty_in_stock = ps.PandS_Qty_in_stock + d.CountQty;
                                    entities.SaveChanges();
                                }
                            }

                        }
                    }

                   
                    
                }
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            return 1;
        }
        public CountAndAdjustStockForm GetCountAndAdjustStock(string stockCountNo)
        {

            CountAndAdjustStockForm casform = new CountAndAdjustStockForm();
            try
            {
              
                using (SDNProductDBEntities entities = new SDNProductDBEntities())
                {
                    var pq = (from pqs in entities.StockCounts
                              where pqs.Stock_count_no == stockCountNo
                              select new CountAndAdjustStockEntity
                              {
                                  StockCountNo = pqs.Stock_count_no,
                                  StockDate = pqs.StockDate,
                                  Type = pqs.StockType
                              }).FirstOrDefault();

                    if (pq != null)
                    {
                
                        casform.CountAndAdjustStock = pq;
                    }


                    var pqd = (from pqs in entities.StockCounts
                               where pqs.Stock_count_no == stockCountNo
                               select new CountAndAdjustStockDetailsEntity
                               {
                                   PSID = pqs.PSID,
                                   PandSCode = pqs.PandS_Code,
                                   PandSName = pqs.PandS_Name,
                                   SystemQty = pqs.SysQty,
                                   CountQty = pqs.CountQty,
                                   Difference = pqs.Difference,
                                   AverageCost = pqs.Average_Cost,
                                   Amount=pqs.Amount
                               }).ToList<CountAndAdjustStockDetailsEntity>();

                    if (pqd != null)
                    {
                        casform.CountAndAdjustStockDetails = pqd;
                    }

                    return casform;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public string GetLatestStockCountNo()
        {
            string sNo = string.Empty;
            try
            {
                using (SDNProductDBEntities entities = new SDNProductDBEntities())
                {
                    var pq = (from pqs in entities.StockCounts
                              orderby pqs.UpdatedDate descending
                              select new
                              {
                                  pqs.ID,
                                  pqs.Stock_count_no,
                                  pqs.UpdatedDate
                              }

                             ).ToList();
                    if (pq.Count > 0)
                    {
                        sNo = pq.Take(1).SingleOrDefault().Stock_count_no;
                        if (sNo != null)
                        {
                            string[] str = sNo.Split('-');
                            if (str != null)
                            {
                                sNo = Convert.ToString(Convert.ToInt64(str[1]) + 1);
                            }

                        }
                    }
                    else
                    {
                        sNo = Convert.ToString(1);
                    }
                }
                return sNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
