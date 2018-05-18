using SDN.UI.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.Purchasing
{
    public class SuppliersUnPaidInvoicesDAL: ISuppliersUnpaidInvoicesDAL
    {
        public List<SuppliersUnpaidInvoicesEntity> GetSuppliersList(string statementDate)
        {
            List<SuppliersUnpaidInvoicesEntity> supList = new List<SuppliersUnpaidInvoicesEntity>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    supList = entities.Database.SqlQuery<SuppliersUnpaidInvoicesEntity>("PRC_GetUnPaidInvoices_Suppliers @StatementDate",
                        new SqlParameter("StatementDate", statementDate)).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return supList;
        }
        public SuppliersStatementEntity GetAllUnPaidInvoice(int supplierID, string statementDate)
        {
            SuppliersStatementEntity entity = new SuppliersStatementEntity();
            List<SuppliersBalanceEntity> lstbalances = new List<SuppliersBalanceEntity>(); 
            List<SuppliersInvoiceDetailsEntity> lstInvoices = new List<SuppliersInvoiceDetailsEntity>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                     lstInvoices = entities.Database.SqlQuery<SuppliersInvoiceDetailsEntity>("USP_SuppliersStatementUnPaidInvoice @ID,@SDate",
                    new SqlParameter("ID", supplierID),
                    new SqlParameter("SDate", statementDate)).ToList();

                    lstbalances = entities.Database.SqlQuery<SuppliersBalanceEntity>("USP_GetStatementUnpaidInvoice_Summary @ID,@SDate,@Type",
                    new SqlParameter("ID", supplierID),
                    new SqlParameter("SDate", statementDate),
                    new SqlParameter("Type","S")).ToList();

                    entity.LstBalances= lstbalances;
                    entity.LstInvoices = lstInvoices;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }
        //public List<SuppliersBalanceAndUnPaidInvoicesEntity> GetAllUnPaidInvoice(int supplierID, string statementDate)
        //{

        //    List<SuppliersBalanceAndUnPaidInvoicesEntity> lstInvoices = new List<SuppliersBalanceAndUnPaidInvoicesEntity>();
        //    try
        //    {
        //        SASEntitiesEDM entities = new SASEntitiesEDM();
        //        using (var connection = entities.Database.Connection)
        //        {

        //            connection.Open();
        //            var command = connection.CreateCommand();
        //            command.CommandText = ("EXEC [dbo].[USP_SuppliersStatementUnPaidInvoice] @ID, @SDate");
        //            command.Parameters.Add("@value2", statementDate);
        //            command.Parameters.AddWithValue("@value2", statementDate);





        //            lstInvoices = entities.Database.SqlQuery<SuppliersBalanceAndUnPaidInvoicesEntity>("USP_SuppliersStatementUnPaidInvoice @ID,@SDate",
        //            new SqlParameter("ID", supplierID),
        //            new SqlParameter("SDate", statementDate)).ToList();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstInvoices;
        //}
    }
}
