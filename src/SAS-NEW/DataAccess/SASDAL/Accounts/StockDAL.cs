using SDN.UI.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Accounts
{
    public class StockDAL : IStockDAL
    {
        SASEntitiesEDM entity = new SASEntitiesEDM();
        public List<StockEntity> getStockList()
        {
            List<StockEntity> list = new List<StockEntity>();
            try
            {
                list = entity.Database.SqlQuery<StockEntity>("USP_UnpaidStock").ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public string IsChequeNoPresent()
        {
            var InvoiceNumber = string.Empty;
            var _InvoiceNumber = string.Empty;
            try
            {
                InvoiceNumber = (from x in entity.UnpaidPurchaseInvoices orderby x.CreatedDate descending select x.UnpaidPI_No).FirstOrDefault();
                _InvoiceNumber = InvoiceNumber.TrimEnd();

            }
            catch (Exception e)
            {
                throw e;
            }
            return _InvoiceNumber;
        }

        public int SaveStockData(StockModel JForm)
        {
            //int autoId = 0;
            // UnpaidSalesInvoice obj = new UnpaidSalesInvoice();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {

                    Stock obj1;
                    if (JForm.StockDetailsData != null)
                    {
                        foreach (StockEntity JEntity in JForm.StockDetailsData)
                        {
                            //save entity value
                            obj1 = new Stock();
                            obj1.Product_ID =JEntity.ID;
                            obj1.Quantity_In_Stock = JEntity.QtyInStock;
                            obj1.Average_Cost = JEntity.AverageCost;
                            obj1.Amount = JEntity.Amount;
                            obj1.CreatedDate = DateTime.Now;

                            if (entities.Stocks.AsNoTracking().FirstOrDefault(x => x.ID == JEntity.ID) == null)
                            {
                                entities.Stocks.Add(obj1);
                                entities.SaveChanges();

                            }
                            else
                            {
                                entities.Entry(obj1).State = EntityState.Modified;
                                entities.SaveChanges();
                            }
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
