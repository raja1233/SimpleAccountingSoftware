using SDN.UI.Entities.HomeScreen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.HomeScreen
{
    public class TodoUnpaidDetailDAL : ITodoUnpaidDetailDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        public List<TodoUnpaidDetailEntity> GetAllData(int? InvType)
        {
            List<TodoUnpaidDetailEntity> PaymentList = entities.Database.SqlQuery<TodoUnpaidDetailEntity>("USP_TodoListUnpaidInvDetail @InvType",
                new SqlParameter("InvType", Convert.ToInt32(InvType))).ToList();
            return PaymentList;
            //return null;
        }
        public List<TodoUnpaidDetailEntity> GetSummaryData()
        {
            List<TodoUnpaidDetailEntity> PaymentList = entities.Database.SqlQuery<TodoUnpaidDetailEntity>("USP_ToDoUnpaidInvoiceSummary").ToList();
            return PaymentList;
            //return null;
        }
        public bool SavePromisedDate(List<TodoUnpaidDetailEntity> TodoInvList, string DateFormat)
        {
            try
            {
                ToDoList todoinv;
                foreach (var item in TodoInvList)
                {
                    if (item.PromisedDateStr != null)
                    {
                        todoinv = entities.ToDoLists.Where(e => e.InvoiceNo == item.InvoiceNo).SingleOrDefault();
                        if (todoinv != null)
                        {
                            todoinv.AmountDue = item.AmountDue;
                            todoinv.CreditDays = item.CreditDueDays;
                            todoinv.InvoiceDate = item.InvoiceDate;
                            todoinv.InvoiceNo = item.InvoiceNo;
                            todoinv.Name = item.Name;
                            todoinv.OverdueDays = item.OverDueDays;
                            todoinv.PaymentDueDate = item.PaymentDueDate;
                            //todoinv.PromisedDate =Convert.ToDateTime(item.PromisedDateStr);
                            todoinv.PromisedDate = Convert.ToDateTime(DateTime.ParseExact(item.PromisedDateStr, DateFormat, CultureInfo.InvariantCulture)
                              .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                            todoinv.Type = item.Type;
                            //entities.ToDoLists.Add(todoinv);
                            entities.SaveChanges();
                        }
                        else
                        {
                            todoinv = new ToDoList();
                            todoinv.AmountDue = item.AmountDue;
                            todoinv.CreditDays = item.CreditDueDays;
                            todoinv.InvoiceDate = item.InvoiceDate;
                            todoinv.InvoiceNo = item.InvoiceNo;
                            todoinv.Name = item.Name;
                            todoinv.OverdueDays = item.OverDueDays;
                            todoinv.PaymentDueDate = item.PaymentDueDate;
                            //todoinv.PromisedDate =Convert.ToDateTime(item.PromisedDateStr);
                            todoinv.PromisedDate = Convert.ToDateTime(DateTime.ParseExact(item.PromisedDateStr, DateFormat, CultureInfo.InvariantCulture)
                              .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                            todoinv.Type = item.Type;
                            entities.ToDoLists.Add(todoinv);
                            entities.SaveChanges();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // return true;
        }
    }
}
