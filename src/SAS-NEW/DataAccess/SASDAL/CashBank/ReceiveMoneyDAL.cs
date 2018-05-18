﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.CashBank
{
    using SDN.Common;
    using SDN.UI.Entities;
    public class ReceiveMoneyDAL: IReceiveMoneyDAL
    {
        public List<AccountsEntity> GetAccountDetails()
        {
            List<AccountsEntity> lstAccnts = new List<AccountsEntity>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    lstAccnts = entities.Database.SqlQuery<AccountsEntity>("USP_GetAccountName").ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
           return lstAccnts;
         }

        public int SaveReceiveMoney(ReceiveMoneyEntity receiveMoney)
        {
            int autoId = 0;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    ReceiveMoney cbt = new ReceiveMoney();
                    cbt.LinkedAccountID = receiveMoney.SelectedLinkedAcntID;
                    cbt.CashBankAccountID = receiveMoney.SelectedCashBankAcntID;
                    cbt.IsCheque = receiveMoney.IsCheque;
                    cbt.CashChequeNo = receiveMoney.CashChequeNo;
                    cbt.CashChequeDate = receiveMoney.CashChequeDate;
                    cbt.Remarks = receiveMoney.Remarks;
                    cbt.TaxID = receiveMoney.SelectedTaxID;
                    cbt.TotalBeforeTax = receiveMoney.TotalBeforeTax;
                    cbt.TotalTax = receiveMoney.TotalTax;
                    cbt.TotalAfterTax = receiveMoney.TotalAfterTax;
                    cbt.Remarks = receiveMoney.Remarks;
                    cbt.CreatedBy = 1;
                    cbt.CreatedDate = DateTime.Now;
                    entities.ReceiveMoneys.Add(cbt);
                    entities.SaveChanges();
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return autoId;
        }
        public int UpdateReceiveMoney(ReceiveMoneyEntity receiveMoney)
        {
            int autoId = 0;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    ReceiveMoney cbt = entities.ReceiveMoneys.SingleOrDefault(e => e.CashChequeNo == receiveMoney.CashChequeNo);
                    if (cbt != null)
                    {
                        //cbt.ID = receiveMoney.ID;
                        cbt.LinkedAccountID = receiveMoney.SelectedLinkedAcntID;
                        cbt.CashBankAccountID = receiveMoney.SelectedCashBankAcntID;
                        cbt.IsCheque = receiveMoney.IsCheque;
                        cbt.CashChequeNo = receiveMoney.CashChequeNo;
                        cbt.CashChequeDate = receiveMoney.CashChequeDate;
                        cbt.Remarks = receiveMoney.Remarks;
                        cbt.TaxID = receiveMoney.SelectedTaxID;
                        cbt.TotalBeforeTax = receiveMoney.TotalBeforeTax;
                        cbt.TotalTax = receiveMoney.TotalTax;
                        cbt.TotalAfterTax = receiveMoney.TotalAfterTax;
                        cbt.Remarks = receiveMoney.Remarks;
                        cbt.UpdatedBy = 1;
                        cbt.UpdatedDate = DateTime.Now;

                        entities.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return autoId;
        }

        public ReceiveMoneyEntity GetReceiveMoneyDetails(string cashChequeNo)
        {
            ReceiveMoneyEntity receiveMoney = new ReceiveMoneyEntity();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    ReceiveMoney cbt = entities.ReceiveMoneys.SingleOrDefault(e => e.CashChequeNo == cashChequeNo);
                    if (cbt != null)
                    {
                        receiveMoney.ID = cbt.ID;
                        receiveMoney.SelectedLinkedAcntID=cbt.LinkedAccountID;
                        receiveMoney.SelectedCashBankAcntID=cbt.CashBankAccountID ;
                        receiveMoney.IsCheque=cbt.IsCheque;
                        receiveMoney.CashChequeNo=cbt.CashChequeNo;
                        receiveMoney.CashChequeDate=cbt.CashChequeDate ;
                        receiveMoney.Remarks=cbt.Remarks ;
                        receiveMoney.SelectedTaxID=cbt.TaxID ;
                        receiveMoney.TotalBeforeTax=cbt.TotalBeforeTax ;
                        receiveMoney.TotalTax=cbt.TotalTax;
                        receiveMoney.TotalAfterTax=cbt.TotalAfterTax ;
                        receiveMoney.Remarks= cbt.Remarks;

                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return receiveMoney;
        }

       public bool IsChequeNoPresent(string cashChequeNo)
        {
            try
            {
                    using (SASEntitiesEDM entities = new SASEntitiesEDM())
                    {
                        var po = entities.ReceiveMoneys.Where(e => e.CashChequeNo == cashChequeNo
                      ).ToList();
                        if (po.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetLastCashNo()
        {
            string st = Convert.ToString(Convert.ToByte(CashBankTransactionType.ReceiveMoney));
            string cNo = string.Empty;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var pq = (from pqs in entities.ReceiveMoneys
                              where pqs.IsCheque == false 
                              orderby pqs.CreatedDate descending
                              select new
                              {
                                  pqs.UpdatedDate,
                                  pqs.CashChequeNo,
                                  pqs.ID,
                                  pqs.IsCheque
                                  
                              }

                               ).ToList();
                    if (pq.Count > 0)
                    {
                        cNo = pq.Take(1).SingleOrDefault().CashChequeNo;
                        if (cNo != null)
                        {
                            string[] str = cNo.Split('-');
                            if (str != null)
                            {
                                cNo = Convert.ToString(Convert.ToInt64(str[1]) + 1);
                            }

                        }
                    }
                    else
                    {
                        cNo = Convert.ToString(1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cNo;
        }
    }
}