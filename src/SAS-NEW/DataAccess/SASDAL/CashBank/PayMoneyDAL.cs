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
    public class PayMoneyDAL : IPayMoneyDAL
    {
        public List<AccountsEntity> GetAccountDetails()
        {
            List<AccountsEntity> lstAccnts = new List<AccountsEntity>();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    lstAccnts = entities.Database.SqlQuery<AccountsEntity>("USP_GetPayMoneyAccountName").ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAccnts;
        }

        public int SavePayMoney(PayMoneyEntity receiveMoney)
        {
            int autoId = 0;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    PayMoney cbt = new PayMoney();
                    cbt.LinkedAccountID = receiveMoney.SelectedLinkedAcntID;
                    cbt.CashBankAccountID = receiveMoney.SelectedCashBankAcntID;
                    cbt.IsCheque = receiveMoney.IsCheque;
                    cbt.CashChequeNo = receiveMoney.CashChequeNo;
                    cbt.CashChequeDate =receiveMoney.CashChequeDate;
                    cbt.Remarks = receiveMoney.Remarks;
                    cbt.TaxID = receiveMoney.SelectedTaxID;
                    cbt.TotalBeforeTax = receiveMoney.TotalBeforeTax;
                    cbt.TotalTax = receiveMoney.TotalTax;
                    cbt.TotalAfterTax = receiveMoney.TotalAfterTax;
                    cbt.Remarks = receiveMoney.Remarks;
                    cbt.CreatedBy = 1;
                    cbt.CreatedDate = DateTime.Now;
                    entities.PayMoneys.Add(cbt);
                    entities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return autoId;
        }
        public int UpdatePayMoney(PayMoneyEntity receiveMoney)
        {
            int autoId = 0;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    PayMoney cbt = entities.PayMoneys.SingleOrDefault(e => e.CashChequeNo == receiveMoney.CashChequeNo);
                    if (cbt != null)
                    {
                        //cbt.ID = receiveMoney.ID;
                        cbt.LinkedAccountID = receiveMoney.SelectedLinkedAcntID;
                        cbt.CashBankAccountID = receiveMoney.SelectedCashBankAcntID;
                        cbt.IsCheque = receiveMoney.IsCheque;
                        cbt.CashChequeNo = receiveMoney.CashChequeNo;
                        cbt.CashChequeDate = Convert.ToDateTime(receiveMoney.CashChequeDateStr);
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

        public PayMoneyEntity GetPayMoneyDetails(string cashChequeNo)
        {
            PayMoneyEntity receiveMoney = new PayMoneyEntity();
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    PayMoney cbt = entities.PayMoneys.Where(e => e.CashChequeNo == cashChequeNo).SingleOrDefault();
                    if (cbt != null)
                    {
                        receiveMoney.ID = cbt.ID;
                        receiveMoney.SelectedLinkedAcntID = cbt.LinkedAccountID;
                        receiveMoney.SelectedCashBankAcntID = cbt.CashBankAccountID;
                        receiveMoney.IsCheque = cbt.IsCheque;
                        receiveMoney.CashChequeNo = cbt.CashChequeNo;
                        receiveMoney.CashChequeDate = cbt.CashChequeDate;
                        receiveMoney.Remarks = cbt.Remarks;
                        receiveMoney.SelectedTaxID = cbt.TaxID;
                        receiveMoney.TotalBeforeTax = cbt.TotalBeforeTax;
                        receiveMoney.TotalTax = cbt.TotalTax;
                        receiveMoney.TotalAfterTax = cbt.TotalAfterTax;
                        receiveMoney.Remarks = cbt.Remarks;

                    }
                }
            }
            catch (Exception ex)
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
                    var po = entities.PayMoneys.Where(e => e.CashChequeNo == cashChequeNo
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
            string st = Convert.ToString(Convert.ToByte(CashBankTransactionType.PayMoney));
            string cNo = string.Empty;
            try
            {
                using (SASEntitiesEDM entities = new SASEntitiesEDM())
                {
                    var pq = (from pqs in entities.PayMoneys
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
