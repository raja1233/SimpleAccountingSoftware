using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Products.DAL
{
    using SDN.Products.DALInterface;
    //using UI.Entities;
    using SASDAL;
    using UI.Entities;
    using UI.Entities.Purchase;
    using UI.Entities.Sales;
    using UI.Entities.Product;

    //using SASDAL;

    public class PandSCategoryContentDAL : IPandSCategoryContentDAL
    {

        /// <summary>
        /// This method is used to get category content 
        /// </summary>
        /// <returns></returns>
        public List<ContentModel> GetCategoryContent(string catType)
        {
            List<ContentModel> lstContents = new List<ContentModel>();
            using (SASEntitiesEDM objProdEntities = new SASEntitiesEDM())
            {
                try
                {
                    lstContents = (from content in objProdEntities.CategoriesContents
                                   join cat in objProdEntities.Categories on content.Cat_Id equals cat.ID
                                   where cat.Cat_Code == catType && content.IsDeleted == false
                                   select new ContentModel
                                   {
                                       CategoryID = cat.ID,
                                       ContentID = content.ID,
                                       ContentName = content.Cat_Contents,
                                       IsSelected = content.Set_Default
                                   }).ToList();

                    return lstContents;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }

    public class PandSTaxCodeAndRateDAL : IPandSTaxCodeAndRateDAL
    {
        /// <summary>
        /// This method is used to get all the taxes which are not deleted and inactive
        /// </summary>
        /// <returns></returns>
        public List<TaxModel> GetTax()
        {
            List<TaxModel> lstContents = new List<TaxModel>();
            using (SASEntitiesEDM objProdEntities = new SASEntitiesEDM())
            {
                try
                {
                    lstContents = (from tax in objProdEntities.TaxCodesAndRates
                                   where tax.IsDeleted == false && tax.Tax_Inactive.Trim() == "N"
                                   // && tax.Tax_Default==true
                                   select new TaxModel
                                   {
                                       TaxID = tax.ID,
                                       TaxDescription = tax.Tax_Description,
                                       TaxCode = tax.Tax_Code,
                                       TaxName = tax.Tax_Name,
                                       TaxRate = tax.Tax_Rate,
                                       IsDefault = tax.Tax_Default,
                                       IsInActive = tax.Tax_Inactive

                                   }).ToList();

                    return lstContents;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }

    public class PandSAccountDetailsDAL : IPandSAccountDetailsDAL
    {
        public List<AccountsEntity> GetAssetsAccount()
        {
            throw new NotImplementedException();
        }

        public List<AccountsEntity> GetCostsAccount()
        {
            throw new NotImplementedException();
        }

        public List<AccountsEntity> GetIncomeAcount()
        {
            throw new NotImplementedException();
        }
    }

    public class PAndSDetailsDAL : IPAndSDetailsDAL
    {
        public List<PandSDetailsModel> GetAllPandSCodes()
        {
            List<PandSDetailsModel> lstCodes = new List<PandSDetailsModel>();
            using (SASEntitiesEDM objEntities = new SASEntitiesEDM())
            {
                try
                {
                    lstCodes = (from code in objEntities.ProductsAndServices
                                where (code.IsDeleted == false || code.IsDeleted == null)
                                select new PandSDetailsModel
                                {
                                    ID = code.ID,
                                    PSCode = code.PandS_Code,
                                    PSName = code.PandS_Name,
                                    PSCategory1 = code.PandS_Cat1,
                                    PSCategory2 = code.PandS_Cat2,
                                    TaxID = code.Tax_ID,
                                    TaxRate = code.Tax_Rate,
                                    PSType = code.PandS_Type,
                                    PSDescription = code.PandS_Description,
                                    IsInActive = code.PandS_Inactive,
                                    StandardSellPriceBeforeGST = code.PandS_Std_Sell_Price_bef_GST.ToString(),
                                    StandardSellPriceAfterGST = code.PandS_Std_Sell_Price_aft_GST.ToString(),
                                    StandardCostpriceBeforeGST = code.PandS_Std_Cost_Price_bef_GST.ToString(),
                                    StandardCostpriceAfterGST = code.PandS_Std_Cost_Price_aft_GST.ToString(),
                                    AverageSellPriceBeforeGST = code.PandS_Ave_Sell_Price_bef_GST.ToString(),
                                    AverageSellPriceAfterGST = code.PandS_Ave_Sell_Price_aft_GST.ToString(),
                                    AverageCostPriceAfterGST = code.PandS_Ave_Cost_Price_aft_GST.ToString(),
                                    AverageCostPriceBeforeGST = code.PandS_Ave_Cost_Price_bef_GST.ToString(),
                                    LastSoldPriceBeforeGST = code.PandS_Last_Sold_Price_bef_GST.ToString(),
                                    LastSoldPriceAfterGST = code.PandS_Last_Sold_Price_aft_GST.ToString(),
                                    LastPurchasePriceBeforeGST = code.PandS_Last_Pur_Price_bef_GST.ToString(),
                                    LastPurchasePriceAfterGST = code.PandS_Last_Pur_Price_aft_GST.ToString(),
                                    MinimumQuantity = code.PandS_Min_Qty,
                                    QuantityInStock = code.PandS_Qty_in_stock,
                                    ReservedForSalesOrders = code.PandS_Qty_for_SO,
                                    OnPurchaseOrders = code.PandS_Qty_on_PO,
                                    StockValue = code.PandS_Stock_Value,
                                    ImgSource = code.PandS_Stock_Picture,
                                    IsRefreshData = code.IsRefresh == null ? false : code.IsRefresh,
                                    RefreshDate = code.RefreshDate == null ? (code.ModifiedDate == null ? code.CreatedDate : code.ModifiedDate) : code.RefreshDate


                                }).OrderBy(e => e.PSName).ToList<PandSDetailsModel>();

                    return lstCodes;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<PandSDetailsModel> GetAllPandSNames()
        {
            List<PandSDetailsModel> lstCodes = new List<PandSDetailsModel>();
            using (SASEntitiesEDM objEntities = new SASEntitiesEDM())
            {
                try
                {
                    lstCodes = (from code in objEntities.ProductsAndServices
                                where code.IsDeleted == false
                                select new PandSDetailsModel
                                {
                                    ID = code.ID,
                                    PSCode = code.PandS_Code,
                                    PSName = code.PandS_Description,

                                }).ToList<PandSDetailsModel>();

                    return lstCodes;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<PandSListModel> GetPandSComboList()
        {
            List<PandSListModel> lstCodes = new List<PandSListModel>();
            using (SASEntitiesEDM objEntities = new SASEntitiesEDM())
            {
                try
                {
                    lstCodes = (from code in objEntities.ProductsAndServices
                                where (code.IsDeleted == false || code.IsDeleted == null && code.PandS_Inactive!="Y")
                                select new PandSListModel
                                {
                                    ID = code.ID,
                                    PSCode = code.PandS_Code,
                                    PSName = code.PandS_Name,
                                    TaxID = code.Tax_ID,
                                    TaxRate = code.Tax_Rate,
                                    PSType = code.PandS_Type,
                                    IsInActive = code.PandS_Inactive,
                                    SellPriceExcludingTax = code.PandS_Std_Sell_Price_bef_GST,
                                    SellPriceIncludingTax = code.PandS_Std_Sell_Price_aft_GST,
                                    CostPriceExcludingTax = code.PandS_Std_Cost_Price_bef_GST,
                                    CostPriceIncludingTax = code.PandS_Std_Cost_Price_aft_GST,
                                    SellPriceExcludingTaxBackup = code.PandS_Std_Sell_Price_bef_GST,
                                    SellPriceIncludingTaxBackup = code.PandS_Std_Sell_Price_aft_GST,
                                    CostPriceExcludingTaxBackup = code.PandS_Std_Cost_Price_bef_GST,
                                    CostPriceIncludingTaxBackup = code.PandS_Std_Cost_Price_aft_GST

                                }).OrderBy(e => e.PSName).ToList<PandSListModel>();

                    return lstCodes;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<PandSQtyAndStockModel> GetPandSList()
        {
            List<PandSQtyAndStockModel> lstCodes = new List<PandSQtyAndStockModel>();
            using (SASEntitiesEDM objEntities = new SASEntitiesEDM())
            {
                try
                {
                    lstCodes = (from code in objEntities.ProductsAndServices
                                where (code.IsDeleted == false || code.IsDeleted == null)
                                select new PandSQtyAndStockModel
                                {
                                    PSID = code.ID,
                                    PSCode = code.PandS_Code,
                                    PSName = code.PandS_Name,
                                    Category1 = code.PandS_Cat1,
                                    Category2 = code.PandS_Cat2,
                                    QtyInStock = code.PandS_Qty_in_stock,
                                    PSType = code.PandS_Type,
                                    IsInActive = code.PandS_Inactive,
                                    AvgCostPriceAfterGSTd = code.PandS_Ave_Cost_Price_aft_GST,
                                    AvgCostPriceBeforeGSTd = code.PandS_Ave_Cost_Price_bef_GST,
                                    StdPriceAfterGSTd = code.PandS_Std_Cost_Price_aft_GST,
                                    StdPriceBeforeGSTd = code.PandS_Std_Cost_Price_bef_GST

                                }).OrderBy(e => e.PSName).ToList<PandSQtyAndStockModel>();

                    return lstCodes;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

    public class PandSPurchaseInvoiceDetailsDAL : IPandSPurchaseInvoiceDetailsDAL
    {
        public List<PurchaseInvoiceEntity> GetPurchaseInvoiceDetails(int psID)
        {
            string pandsId = Convert.ToString(psID);
            try
            {
                List<PurchaseInvoiceEntity> lstCodes = new List<PurchaseInvoiceEntity>();
                using (SASEntitiesEDM objprodEntities = new SASEntitiesEDM())
                {
                    lstCodes = (from pi in objprodEntities.PurchaseInvoices
                                join pid in objprodEntities.PurchaseInvoiceDetails
                                on pi.ID equals pid.PI_ID
                                where pid.PI_No == pandsId
                                select new PurchaseInvoiceEntity
                                {
                                    ID = pi.ID,

                                    InvoiceDate = pi.PI_Date,
                                    Amount = pi.PI_Tot_bef_Tax,
                                    Price = pid.PI_Price,
                                    Quantity = pid.PI_Qty == null ? 0 : pid.PI_Qty
                                }).ToList<PurchaseInvoiceEntity>();

                    return lstCodes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class OptionsDetailsDAL : IOptionsDetailsDAL
    {
        public OptionsEntity GetOptionsDetails()
        {
            OptionsEntity result = new OptionsEntity();
            using (SASEntitiesEDM entites = new SASEntitiesEDM())
            {
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

                }
                return result;
            }
        }
    }

    public class PandSSalesInvoiceDetailsDAL : IPandSSalesInvoiceDetailsDAL
    {
        public List<SalesInvoiceEntity> GetSalesInvoiceDetails(int psID)
        {
            string pandsID = Convert.ToString(psID);
            try
            {
                List<SalesInvoiceEntity> lstCodes = new List<SalesInvoiceEntity>();
                using (SASEntitiesEDM objprodEntities = new SASEntitiesEDM())
                {
                    lstCodes = (from pi in objprodEntities.SalesInvoices
                                join pid in objprodEntities.SalesInvoiceDetails
                                on pi.ID equals pid.SI_ID
                                where pid.SI_No == pandsID
                                orderby pi.CreatedDate descending
                                select new SalesInvoiceEntity
                                {
                                    ID = pi.ID,
                                    //PSCode = pid.PandS_Code,
                                    // PSName = pid.PandS_Name,
                                    InvoiceDate = pi.SI_Date,
                                    Amount = pid.SI_Amount,
                                    Price = pid.SI_Price,
                                    Quantity = pid.SI_Qty
                                }).ToList<SalesInvoiceEntity>();

                    return lstCodes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    public class PandSDetailsOperationDAL : IPandSDetailsOperationDAL
    {
        public void DeletePandS(PandSDetailsModel pandsModel)
        {
            try
            {
                using (SASEntitiesEDM objEntities = new SASEntitiesEDM())
                {
                    ProductsAndService pands = objEntities.ProductsAndServices.Where(p => p.ID == pandsModel.ID).SingleOrDefault();
                    if (pands != null)
                    {
                        pands.IsDeleted = true;
                        pands.ModifiedBy = pandsModel.LoggedinUserID;
                        pands.ModifiedDate = DateTime.Now;
                        objEntities.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SavePandS(PandSDetailsModel pandsModel)
        {
            int Id = 0;
            try
            {
                using (SASEntitiesEDM objEntities = new SASEntitiesEDM())
                {
                    ProductsAndService pands = new ProductsAndService();
                    pands.PandS_Code = pandsModel.PSCode;
                    pands.PandS_Name = pandsModel.PSName;
                    pands.PandS_Type = pandsModel.PSType;
                    pands.PandS_Cat1 = pandsModel.PSCategory1;
                    pands.PandS_Cat2 = pandsModel.PSCategory2;
                    pands.Tax_Rate = pandsModel.TaxRate;
                    pands.Tax_ID = pandsModel.TaxID;
                    pands.PandS_Description = pandsModel.PSDescription;
                    pands.PandS_Inactive = pandsModel.IsInActive == null ? null : pandsModel.IsInActive;
                    pands.PandS_Stock_Picture = pandsModel.ImgSource;
                    //Standard Sell and cost price
                    pands.PandS_Std_Sell_Price_bef_GST = Convert.ToDecimal(pandsModel.StandardSellPriceBeforeGST);
                    //pands.PandS_Std_Sell_Price_aft_GST = pandsModel.StandardSellPriceAfterGST;
                    pands.PandS_Std_Sell_Price_aft_GST = Convert.ToDecimal(pandsModel.StandardSellPriceAfterGST);
                    pands.PandS_Std_Cost_Price_bef_GST = Convert.ToDecimal(pandsModel.StandardCostpriceBeforeGST);
                    pands.PandS_Std_Cost_Price_aft_GST = Convert.ToDecimal(pandsModel.StandardCostpriceAfterGST);
                    //Average 
                    pands.PandS_Ave_Sell_Price_bef_GST = Convert.ToDecimal(pandsModel.AverageSellPriceBeforeGST);
                    pands.PandS_Ave_Sell_Price_aft_GST = Convert.ToDecimal(pandsModel.AverageSellPriceAfterGST);
                    pands.PandS_Ave_Cost_Price_bef_GST = Convert.ToDecimal(pandsModel.AverageCostPriceBeforeGST);
                    pands.PandS_Ave_Cost_Price_aft_GST = Convert.ToDecimal(pandsModel.AverageCostPriceAfterGST);
                    //Last
                    pands.PandS_Last_Sold_Price_bef_GST = Convert.ToDecimal(pandsModel.LastSoldPriceBeforeGST);
                    pands.PandS_Last_Sold_Price_aft_GST = Convert.ToDecimal(pandsModel.LastSoldPriceAfterGST);
                    pands.PandS_Last_Pur_Price_bef_GST = Convert.ToDecimal(pandsModel.LastPurchasePriceBeforeGST);
                    pands.PandS_Last_Pur_Price_aft_GST = Convert.ToDecimal(pandsModel.LastPurchasePriceAfterGST);
                    //Stock
                    pands.PandS_Min_Qty = pandsModel.MinimumQuantity;
                    pands.PandS_Qty_in_stock = pandsModel.QuantityInStock;
                    pands.PandS_Qty_for_SO = pandsModel.ReservedForSalesOrders;
                    pands.PandS_Qty_on_PO = pandsModel.OnPurchaseOrders;
                    pands.PandS_Stock_Value = pandsModel.StockValue;
                    pands.CreatedBy = pandsModel.LoggedinUserID;
                    pands.CreatedDate = DateTime.Now;
                    pands.IsRefresh = false;
                    pands.RefreshDate = null;

                    objEntities.ProductsAndServices.Add(pands);
                    objEntities.SaveChanges();

                    ProductsAndService ps = objEntities.ProductsAndServices.SingleOrDefault(e => e.PandS_Code == pandsModel.PSCode);
                    if (ps != null)
                    {
                        Id = ps.ID;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }

        public void UpdatePandS(PandSDetailsModel pandsModel)
        {
            try
            {
                using (SASEntitiesEDM objEntities = new SASEntitiesEDM())
                {
                    ProductsAndService pands = objEntities.ProductsAndServices.Where(p => p.ID == pandsModel.ID).SingleOrDefault();
                    if (pands != null)
                    {
                        pands.PandS_Code = pandsModel.PSCode;
                        pands.PandS_Name = pandsModel.PSName;
                        pands.PandS_Type = pandsModel.PSType;
                        pands.PandS_Cat1 = pandsModel.PSCategory1;
                        pands.PandS_Cat2 = pandsModel.PSCategory2;
                        pands.Tax_Rate = pandsModel.TaxRate;
                        pands.Tax_ID = pandsModel.TaxID;
                        pands.PandS_Description = pandsModel.PSDescription;
                        pands.PandS_Inactive = pandsModel.IsInActive == null ? null : pandsModel.IsInActive;
                        pands.PandS_Stock_Picture = pandsModel.ImgSource;
                        //Standard Sell and cost price
                        pands.PandS_Std_Sell_Price_bef_GST = Convert.ToDecimal(pandsModel.StandardSellPriceBeforeGST);
                        pands.PandS_Std_Sell_Price_aft_GST = Convert.ToDecimal(pandsModel.StandardSellPriceAfterGST);
                        pands.PandS_Std_Cost_Price_bef_GST = Convert.ToDecimal(pandsModel.StandardCostpriceBeforeGST);
                        pands.PandS_Std_Cost_Price_aft_GST = Convert.ToDecimal(pandsModel.StandardCostpriceAfterGST);
                        //Average 
                        pands.PandS_Ave_Sell_Price_bef_GST = Convert.ToDecimal(pandsModel.AverageSellPriceBeforeGST);
                        pands.PandS_Ave_Sell_Price_aft_GST = Convert.ToDecimal(pandsModel.AverageSellPriceAfterGST);
                        pands.PandS_Ave_Cost_Price_bef_GST = Convert.ToDecimal(pandsModel.AverageCostPriceBeforeGST);
                        pands.PandS_Ave_Cost_Price_aft_GST = Convert.ToDecimal(pandsModel.AverageCostPriceAfterGST);
                        //Last
                        pands.PandS_Last_Sold_Price_bef_GST = Convert.ToDecimal(pandsModel.LastSoldPriceBeforeGST);
                        pands.PandS_Last_Sold_Price_aft_GST = Convert.ToDecimal(pandsModel.LastSoldPriceAfterGST);
                        pands.PandS_Last_Pur_Price_bef_GST = Convert.ToDecimal(pandsModel.LastPurchasePriceBeforeGST);
                        pands.PandS_Last_Pur_Price_aft_GST = Convert.ToDecimal(pandsModel.LastPurchasePriceAfterGST);
                        //Stock
                        pands.PandS_Min_Qty = pandsModel.MinimumQuantity;
                        pands.PandS_Qty_in_stock = pandsModel.QuantityInStock;
                        pands.PandS_Qty_for_SO = pandsModel.ReservedForSalesOrders;
                        pands.PandS_Qty_on_PO = pandsModel.OnPurchaseOrders;
                        pands.PandS_Stock_Value = pandsModel.StockValue;
                        pands.ModifiedBy = pandsModel.LoggedinUserID;
                        pands.ModifiedDate = DateTime.Now;
                        pands.IsRefresh = false;
                        pands.RefreshDate = null;
                        objEntities.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateRefreshData(int psID)
        {
            try
            {
                using (SASEntitiesEDM objEntities = new SASEntitiesEDM())
                {
                    ProductsAndService pands = objEntities.ProductsAndServices.Where(p => p.ID == psID).SingleOrDefault();
                    if (pands != null)
                    {
                        pands.IsRefresh = true;
                        pands.RefreshDate = DateTime.Now.Date;
                        objEntities.SaveChanges();
                    }

                    List<ProductsAndService> pandsOther = objEntities.ProductsAndServices.Where(e => e.ID != psID).ToList();
                    if (pandsOther != null)
                    {
                        foreach (var item in pandsOther)
                        {
                            item.IsRefresh = false;
                            item.RefreshDate = null;
                            objEntities.SaveChanges();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
