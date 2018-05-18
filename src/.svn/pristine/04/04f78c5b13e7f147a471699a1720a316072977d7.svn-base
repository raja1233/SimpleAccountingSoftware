namespace SDN.Settings.DAL
{
    using SDN.Settings.DALInterface;
    using SDN.SettingsEDM;
    using SDN.UI.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OptionsDAL : IOptionsDAL
    {
        SDNSettingEntities entites = new SDNSettingEntities();

        public OptionsEntity GetOptionsDetails()
        {
            OptionsEntity result = new OptionsEntity();

            //IEnumerable<Account> accountsource = entites.Accounts.ToList();

            //result.AccountDetails = accountsource;
            Option source = entites.Options.FirstOrDefault();
            if (source != null)
            {

                result.ID = source.ID;
                result.AllowEditDiscount = source.Allow_Edit_Discount;
                if (source.Allow_Edit_Discount == true)
                {
                    result.AllowEditDiscountTrue = true;
                    result.AllowEditDiscountFalse = false;
                }
                else
                {
                    result.AllowEditDiscountTrue = false;
                    result.AllowEditDiscountFalse = true;
                }


                result.AllowEditPSNameDesc = source.Allow_Edit_PS_Name_Desc;
                if (source.Allow_Edit_PS_Name_Desc == true)
                {
                    result.AllowEditPSNameDescTrue = true;
                    result.AllowEditPSNameDescFalse = false;
                }
                else
                {
                    result.AllowEditPSNameDescTrue = false;
                    result.AllowEditPSNameDescFalse = true;
                }
                result.AllowEditPSPrice = source.Allow_Edit_PS_Price;
                if (source.Allow_Edit_PS_Price == true)
                {
                    result.AllowEditPSPriceTrue = true;
                    result.AllowEditPSPriceFalse = false;
                }
                else
                {
                    result.AllowEditPSPriceTrue = false;
                    result.AllowEditPSPriceFalse = true;
                }
                result.AllowToCreateSaleInv = source.Allow_to_Create_Sales_Inv;
                if (source.Allow_to_Create_Sales_Inv == true)
                {
                    result.AllowToCreateSaleInvTrue = true;
                    result.AllowToCreateSaleInvFalse = false;
                }
                else
                {
                    result.AllowToCreateSaleInvTrue = false;
                    result.AllowToCreateSaleInvFalse = true;
                }
                result.CurrencyCode = source.Currency_Code;
                result.CusDetailAllowChgLimit = source.Cus_Detail_Allow_Chg_Limit;
                if (source.Cus_Detail_Allow_Chg_Limit == true)
                {
                    result.CusDetailAllowChgLimitTrue = true;
                    result.CusDetailAllowChgLimitFalse = false;
                }
                else
                {
                    result.CusDetailAllowChgLimitTrue = false;
                    result.CusDetailAllowChgLimitFalse = true;
                }
                result.DateFormat = source.Date_Format;
                result.DecimalPlaces = Convert.ToByte(source.Decimal_Places);
                result.DefCashBankAcc = source.Def_Cash_Bank_Acc;
                result.AccountID = source.Def_Cash_Bank_Acc;
                result.HideDiscColumn = source.Hide_Discount_Column;
                if (source.Hide_Discount_Column == true)
                {
                    result.HideDiscColumnTrue = true;
                    result.HideDiscColumnFalse = false;
                }
                else
                {
                    result.HideDiscColumnTrue = false;
                    result.HideDiscColumnFalse = true;
                }
                result.NametoPrintSalesInv = source.Name_to_Print_Sales_Invoice;
                result.CurrencyName = source.Number_Format;
                result.PrintPSName = source.Print_PS_Name;
                if (source.Print_PS_Name == true)
                {
                    result.PrintPSNameTrue = true;
                    result.PrintPSNameFalse = false;
                }
                else
                {
                    result.PrintPSNameTrue = false;
                    result.PrintPSNameFalse = true;
                }
                result.PrintPSNameDesc = source.Print_PS_Name_Desc;
                if (source.Print_PS_Name_Desc == true)
                {
                    result.PrintPSNameDescTrue = true;
                    result.PrintPSNameDescFalse = false;
                }
                else
                {
                    result.PrintPSNameDescTrue = false;
                    result.PrintPSNameDescFalse = true;
                }
                result.PSDetailAllowChgAct = source.PS_Detail_Allow_Chg_Act;
                if (source.PS_Detail_Allow_Chg_Act == true)
                {
                    result.PSDetailAllowChgActTrue = true;
                    result.PSDetailAllowChgActFalse = false;
                }
                else
                {
                    result.PSDetailAllowChgActTrue = false;
                    result.PSDetailAllowChgActFalse = true;
                }
                result.PSQtyJumNextLine = source.PS_Qty_Jump_Next_Line;
                if (source.PS_Qty_Jump_Next_Line == true)
                {
                    result.PSQtyJumNextLineTrue = true;
                    result.PSQtyJumNextLineFalse = false;
                }
                else
                {
                    result.PSQtyJumNextLineTrue = false;
                    result.PSQtyJumNextLineFalse = true;
                }
                result.ShowAccountBal = source.Show_Account_Balance;
                if (source.Show_Account_Balance == true)
                {
                    result.ShowAccountBalTrue = true;
                    result.ShowAccountBalFalse = false;
                }
                else
                {
                    result.ShowAccountBalTrue = false;
                    result.ShowAccountBalFalse = true;
                }
                result.ShowAmountIncGST = source.Show_Amount_Inc_GST;
                if (source.Show_Amount_Inc_GST == true)
                {
                    result.ShowAmountIncGSTTrue = true;
                    result.ShowAmountIncGSTFalse = false;
                }
                else
                {
                    result.ShowAmountIncGSTTrue = false;
                    result.ShowAmountIncGSTFalse = true;
                }
                result.ShowPSName = source.Show_PS_Name;
                if (source.Show_PS_Name == true)
                {
                    result.ShowPSNameTrue = true;
                    result.ShowPSNameFalse = false;
                }
                else
                {
                    result.ShowPSNameTrue = false;
                    result.ShowPSNameFalse = true;
                }
                result.ShowPSNameDesc = source.Show_PS_Name_Desc;
                if (source.Show_PS_Name_Desc == true)
                {
                    result.ShowPSNameDescTrue = true;
                    result.ShowPSNameDescFalse = false;
                }
                else
                {
                    result.ShowPSNameDescTrue = false;
                    result.ShowPSNameDescFalse = true;
                }

                result.PrintDelSalesInv = source.Print_Del_Sales_Inv;
                if (source.Print_Del_Sales_Inv == true)
                {
                    result.PrintDelSalesInvTrue = true;
                    result.PrintDelSalesInvFalse = false;
                }
                else
                {
                    result.PrintDelSalesInvTrue = false;
                    result.PrintDelSalesInvFalse = true;
                }

                result.StartingSalesInvNo = source.Starting_Sales_Inv_No;
                var TaxInfo = entites.TaxCodesAndRates.Where(x => x.IsDeleted != true).FirstOrDefault();
                if (TaxInfo != null)
                {
                    result.Tax_Name = TaxInfo.Tax_Name;
                }
                else
                {
                    result.Tax_Name = "GST Free";
                }

            }

            //else 
            //{
            //    //result.ID = source.ID;
            //    result.AllowEditDiscount = source.Allow_Edit_Discount;
            //    if (source.Allow_Edit_Discount == true)
            //    {
            //        result.AllowEditDiscountTrue = true;
            //        result.AllowEditDiscountFalse = false;
            //    }
            //    else
            //    {
            //        result.AllowEditDiscountTrue = false;
            //        result.AllowEditDiscountFalse = true;
            //    }


            //    result.AllowEditPSNameDesc = source.Allow_Edit_PS_Name_Desc;
            //    if (source.Allow_Edit_PS_Name_Desc == true)
            //    {
            //        result.AllowEditPSNameDescTrue = true;
            //        result.AllowEditPSNameDescFalse = false;
            //    }
            //    else
            //    {
            //        result.AllowEditPSNameDescTrue = false;
            //        result.AllowEditPSNameDescFalse = true;
            //    }
            //    result.AllowEditPSPrice = source.Allow_Edit_PS_Price;
            //    if (source.Allow_Edit_PS_Price == true)
            //    {
            //        result.AllowEditPSPriceTrue = true;
            //        result.AllowEditPSPriceFalse = false;
            //    }
            //    else
            //    {
            //        result.AllowEditPSPriceTrue = false;
            //        result.AllowEditPSPriceFalse = true;
            //    }
            //    result.AllowToCreateSaleInv = source.Allow_to_Create_Sales_Inv;
            //    if (source.Allow_to_Create_Sales_Inv == true)
            //    {
            //        result.AllowToCreateSaleInvTrue = true;
            //        result.AllowToCreateSaleInvFalse = false;
            //    }
            //    else
            //    {
            //        result.AllowToCreateSaleInvTrue = false;
            //        result.AllowToCreateSaleInvFalse = true;
            //    }
            //    result.CurrencyCode = source.Currency_Code;
            //    result.CusDetailAllowChgLimit = source.Cus_Detail_Allow_Chg_Limit;
            //    if (source.Cus_Detail_Allow_Chg_Limit == true)
            //    {
            //        result.CusDetailAllowChgLimitTrue = true;
            //        result.CusDetailAllowChgLimitFalse = false;
            //    }
            //    else
            //    {
            //        result.CusDetailAllowChgLimitTrue = false;
            //        result.CusDetailAllowChgLimitFalse = true;
            //    }
            //    result.DateFormat = source.Date_Format;
            //    result.DecimalPlaces = Convert.ToByte(source.Decimal_Places);
            //    result.DefCashBankAcc = source.Def_Cash_Bank_Acc;
            //    result.AccountID = source.Def_Cash_Bank_Acc;
            //    result.HideDiscColumn = source.Hide_Discount_Column;
            //    if (source.Hide_Discount_Column == true)
            //    {
            //        result.HideDiscColumnTrue = true;
            //        result.HideDiscColumnFalse = false;
            //    }
            //    else
            //    {
            //        result.HideDiscColumnTrue = false;
            //        result.HideDiscColumnFalse = true;
            //    }
            //    result.NametoPrintSalesInv = source.Name_to_Print_Sales_Invoice;
            //    result.CurrencyName = source.Number_Format;
            //    result.PrintPSName = source.Print_PS_Name;
            //    if (source.Print_PS_Name == true)
            //    {
            //        result.PrintPSNameTrue = true;
            //        result.PrintPSNameFalse = false;
            //    }
            //    else
            //    {
            //        result.PrintPSNameTrue = false;
            //        result.PrintPSNameFalse = true;
            //    }
            //    result.PrintPSNameDesc = source.Print_PS_Name_Desc;
            //    if (source.Print_PS_Name_Desc == true)
            //    {
            //        result.PrintPSNameDescTrue = true;
            //        result.PrintPSNameDescFalse = false;
            //    }
            //    else
            //    {
            //        result.PrintPSNameDescTrue = false;
            //        result.PrintPSNameDescFalse = true;
            //    }
            //    result.PSDetailAllowChgAct = source.PS_Detail_Allow_Chg_Act;
            //    if (source.PS_Detail_Allow_Chg_Act == true)
            //    {
            //        result.PSDetailAllowChgActTrue = true;
            //        result.PSDetailAllowChgActFalse = false;
            //    }
            //    else
            //    {
            //        result.PSDetailAllowChgActTrue = false;
            //        result.PSDetailAllowChgActFalse = true;
            //    }
            //    result.PSQtyJumNextLine = source.PS_Qty_Jump_Next_Line;
            //    if (source.PS_Qty_Jump_Next_Line == true)
            //    {
            //        result.PSQtyJumNextLineTrue = true;
            //        result.PSQtyJumNextLineFalse = false;
            //    }
            //    else
            //    {
            //        result.PSQtyJumNextLineTrue = false;
            //        result.PSQtyJumNextLineFalse = true;
            //    }
            //    result.ShowAccountBal = source.Show_Account_Balance;
            //    if (source.Show_Account_Balance == true)
            //    {
            //        result.ShowAccountBalTrue = true;
            //        result.ShowAccountBalFalse = false;
            //    }
            //    else
            //    {
            //        result.ShowAccountBalTrue = false;
            //        result.ShowAccountBalFalse = true;
            //    }
            //    result.ShowAmountIncGST = source.Show_Amount_Inc_GST;
            //    if (source.Show_Amount_Inc_GST == true)
            //    {
            //        result.ShowAmountIncGSTTrue = true;
            //        result.ShowAmountIncGSTFalse = false;
            //    }
            //    else
            //    {
            //        result.ShowAmountIncGSTTrue = false;
            //        result.ShowAmountIncGSTFalse = true;
            //    }
            //    result.ShowPSName = source.Show_PS_Name;
            //    if (source.Show_PS_Name == true)
            //    {
            //        result.ShowPSNameTrue = true;
            //        result.ShowPSNameFalse = false;
            //    }
            //    else
            //    {
            //        result.ShowPSNameTrue = false;
            //        result.ShowPSNameFalse = true;
            //    }
            //    result.ShowPSNameDesc = source.Show_PS_Name_Desc;
            //    if (source.Show_PS_Name_Desc == true)
            //    {
            //        result.ShowPSNameDescTrue = true;
            //        result.ShowPSNameDescFalse = false;
            //    }
            //    else
            //    {
            //        result.ShowPSNameDescTrue = false;
            //        result.ShowPSNameDescFalse = true;
            //    }

            //    result.PrintDelSalesInv = source.Print_Del_Sales_Inv;
            //    if (source.Print_Del_Sales_Inv == true)
            //    {
            //        result.PrintDelSalesInvTrue = true;
            //        result.PrintDelSalesInvFalse = false;
            //    }
            //    else
            //    {
            //        result.PrintDelSalesInvTrue = false;
            //        result.PrintDelSalesInvFalse = true;
            //    }

            //    result.StartingSalesInvNo = source.Starting_Sales_Inv_No;

            //}

            return result;
        }

        public bool AddEditOptions(OptionsEntity optionEntity)
        {
            var options = entites.Options.FirstOrDefault();

            try
            {
                if (options != null)
                {
                    Option opt = entites.Options.FirstOrDefault();
                    opt.Allow_Edit_Discount = optionEntity.AllowEditDiscount == null ? false : optionEntity.AllowEditDiscount;
                    opt.Allow_Edit_PS_Name_Desc = optionEntity.AllowEditPSNameDesc == null ? false : optionEntity.AllowEditPSNameDesc;
                    opt.Allow_Edit_PS_Price = optionEntity.AllowEditPSPrice == null ? false : optionEntity.AllowEditPSPrice;
                    opt.Allow_to_Create_Sales_Inv = optionEntity.AllowToCreateSaleInv == null ? false : optionEntity.AllowToCreateSaleInv;
                    opt.Cus_Detail_Allow_Chg_Limit = optionEntity.CusDetailAllowChgLimit == null ? false : optionEntity.CusDetailAllowChgLimit;
                    opt.Hide_Discount_Column = optionEntity.HideDiscColumn == null ? false : optionEntity.HideDiscColumn;
                    opt.Print_Del_Sales_Inv = optionEntity.PrintDelSalesInv == null ? false : optionEntity.PrintDelSalesInv;
                    opt.Print_PS_Name = optionEntity.PrintPSName == null ? false : optionEntity.PrintPSName;
                    opt.Print_PS_Name_Desc = optionEntity.PrintPSNameDesc == null ? false : optionEntity.PrintPSNameDesc;
                    opt.PS_Detail_Allow_Chg_Act = optionEntity.PSDetailAllowChgAct == null ? false : optionEntity.PSDetailAllowChgAct;
                    opt.PS_Qty_Jump_Next_Line = optionEntity.PSQtyJumNextLine == null ? false : optionEntity.PSQtyJumNextLine;
                    opt.Show_Account_Balance = optionEntity.ShowAccountBal == null ? false : optionEntity.ShowAccountBal;
                    opt.Show_PS_Name = optionEntity.ShowPSName == null ? false : optionEntity.ShowPSName;
                    opt.Show_Amount_Inc_GST = optionEntity.ShowAmountIncGST == null ? false : optionEntity.ShowAmountIncGST;
                    opt.Show_PS_Name_Desc = optionEntity.ShowPSNameDesc == null ? false : optionEntity.ShowPSNameDesc;
                    opt.Starting_Sales_Inv_No = optionEntity.StartingSalesInvNo;
                    opt.Number_Format = optionEntity.CurrencyName;
                    opt.Date_Format = optionEntity.DateFormat;
                    opt.Name_to_Print_Sales_Invoice = optionEntity.NametoPrintSalesInv;
                    opt.Decimal_Places = Convert.ToByte(optionEntity.DecimalPlaces);
                    opt.Def_Cash_Bank_Acc = optionEntity.AccountID;
                    opt.Currency_Code = optionEntity.CurrencyCode;
                    opt.ModifiedBy = 0;
                    opt.ModifiedDate = DateTime.Now;
                    entites.SaveChanges();
                    return true;
                }
                else
                {
                    Option optionDetails = new Option()
                    {
                        Allow_Edit_Discount = optionEntity.AllowEditDiscount == null ? false : optionEntity.AllowEditDiscount,
                        Allow_Edit_PS_Name_Desc = optionEntity.AllowEditPSNameDesc == null ? false : optionEntity.AllowEditPSNameDesc,
                        Allow_Edit_PS_Price = optionEntity.AllowEditPSPrice == null ? false : optionEntity.AllowEditPSPrice,
                        Allow_to_Create_Sales_Inv = optionEntity.AllowToCreateSaleInv == null ? false : optionEntity.AllowToCreateSaleInv,
                        Cus_Detail_Allow_Chg_Limit = optionEntity.CusDetailAllowChgLimit == null ? false : optionEntity.CusDetailAllowChgLimit,
                        Hide_Discount_Column = optionEntity.HideDiscColumn == null ? false : optionEntity.HideDiscColumn,
                        Print_Del_Sales_Inv = optionEntity.PrintDelSalesInv == null ? false : optionEntity.PrintDelSalesInv,
                        Print_PS_Name = optionEntity.PrintPSName == null ? false : optionEntity.PrintPSName,
                        Print_PS_Name_Desc = optionEntity.PrintPSNameDesc == null ? false : optionEntity.PrintPSNameDesc,
                        PS_Detail_Allow_Chg_Act = optionEntity.PSDetailAllowChgAct == null ? false : optionEntity.PSDetailAllowChgAct,
                        PS_Qty_Jump_Next_Line = optionEntity.PSQtyJumNextLine == null ? false : optionEntity.PSQtyJumNextLine,
                        Show_Account_Balance = optionEntity.ShowAccountBal == null ? false : optionEntity.ShowAccountBal,
                        Show_PS_Name = optionEntity.ShowPSName == null ? false : optionEntity.ShowPSName,
                        Show_Amount_Inc_GST = optionEntity.ShowAmountIncGST == null ? false : optionEntity.ShowAmountIncGST,
                        Show_PS_Name_Desc = optionEntity.ShowPSNameDesc == null ? false : optionEntity.ShowPSNameDesc,
                        Starting_Sales_Inv_No = optionEntity.StartingSalesInvNo,
                        Number_Format = optionEntity.CurrencyName,
                        Date_Format = optionEntity.DateFormat,
                        Name_to_Print_Sales_Invoice = optionEntity.NametoPrintSalesInv,
                        Decimal_Places = Convert.ToByte(optionEntity.DecimalPlaces),
                        Def_Cash_Bank_Acc = optionEntity.AccountID,
                        Currency_Code = optionEntity.CurrencyCode,
                        CreatedBy = 0,
                        CreatedDate = DateTime.Now
                    };

                    entites.Options.Add(optionDetails);
                    entites.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }

        public List<AccountsEntity> GetAccountDetails()
        {
            List<AccountsEntity> accountsource = entites.Accounts.Where(x=>x.IsDeleted!=true).Select(x => new AccountsEntity
            {
                AccountName = x.Acc_Name,
                AccountID = x.ID,
                AccountType = x.Acc_Type
            }).ToList();
            return accountsource;
        }

        public int GetYearStart()
        {
            var yearstart = entites.Options.FirstOrDefault().CreatedDate.Value.Year;
            return yearstart;
        }
    }
}
