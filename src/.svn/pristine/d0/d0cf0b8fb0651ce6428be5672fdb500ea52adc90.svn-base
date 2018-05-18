using SDN.UI.Entities.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASDAL.File
{
    public class ImportDataDAL : IImportDataDAL
    {
        SASEntitiesEDM entities = new SASEntitiesEDM();
        public void getCustomerList(List<Customer_Detail> customerList, bool RUBool)
        {
            List<Customer_Detail> duplicate = new List<Customer_Detail>();
            List<Customer_Detail> unique = new List<Customer_Detail>();

            var customerResult = (from c1 in entities.Categories
                                  join c2 in entities.CategoriesContents
                                  on c1.ID equals c2.Cat_Id
                                  select new { masterId = c1.ID, c2.ID, c2.Cat_Contents, c1.Cat_Code }).ToList();
            //var Ct = customerResult.Where(p => customerList.Any(l => p.Cat_Contents == l.Type) && p.Cat_Code == "CT").FirstOrDefault().ID;
            //var Sm = customerResult.Where(p => customerList.Any(l => p.Cat_Contents == l.Type) && p.Cat_Code == "SM").FirstOrDefault().ID;
            //var Kld = customerResult.Where(p => customerList.Any(l => p.Cat_Contents == l.Type) && p.Cat_Code == "CCLD").FirstOrDefault().ID;
            //var Kla = customerResult.Where(p => customerList.Any(l => p.Cat_Contents == l.Type) && p.Cat_Code == "CCLA").FirstOrDefault().ID;
            //var Dc = customerResult.Where(p => customerList.Any(l => p.Cat_Contents == l.Type) && p.Cat_Code == "CD").FirstOrDefault().ID;


            List<Customer_Detail> customersource = entities.Customers.Where(x => x.IsDeleted != true).Select(x => new Customer_Detail
            {

                //Sup_Credit_Limit_Amount = item.Credit_Limit_Amount == string.Empty ? null as decimal? : Convert.ToDecimal(item.Credit_Limit_Amount)
                Name = x.Cus_Name,
                Inactive = x.Cus_Inactive,
                Company_Reg_No = x.Cus_Company_Reg_no,
                GST_Reg_No = x.Cus_GST_Reg_No,
                Telephone = x.Cus_Telephone,
                Fax = x.Cus_Fax,
                Email = x.Cus_Email,
                Contact_Person = x.Cus_Contact_Person,
                Type = x.Cus_Type,
                Salesman = x.Cus_Salesman.ToString(),
                Credit_Limit_Amount = String.IsNullOrEmpty(x.Cus_Credit_Limit_Amount.ToString()) ? "0" : x.Cus_Credit_Limit_Amount.ToString(),
                Credit_Limit_Days = String.IsNullOrEmpty(x.Cus_Credit_Limit_Days.ToString()) ? "0" : x.Cus_Credit_Limit_Days.ToString(),
                Discount = String.IsNullOrEmpty(x.Cus_Discount.ToString()) ? "0" : x.Cus_Discount.ToString(),
                Bill_To_Country = x.Cus_Bill_to_country,
                Bill_To_Line1 = x.Cus_Bill_to_line1,
                Bill_To_Line2 = x.Cus_Bill_to_line2,
                Bill_To_Postal_Code = x.Cus_Bill_to_post_code,
                Bill_To_State = x.Cus_Bill_to_state,
                Ship_To_Line1 = x.Cus_Ship_to_line1,
                Ship_To_Line2 = x.Cus_Ship_to_line2,
                Ship_To_City = x.Cus_Ship_to_city,
                Ship_To_Country = x.Cus_Ship_to_country,
                Ship_To_State = x.Cus_Ship_to_state,
                Ship_To_Postal_Code = x.Cus_Ship_to_post_code,
            }).OrderBy(e => e.Name).ToList();

            var namearray = (from cust in customersource
                             select cust.Name).ToArray();

            duplicate = (from customerlist in customerList
                         where namearray.Contains(customerlist.Name)
                         select customerlist).ToList();


            unique = customerList.Except(duplicate).ToList();

            var ThirdList = customersource.Except(customerList).ToList();
            
            if (RUBool == true)
            {
                try
                {
                    foreach (var item in unique)
                    {
                        Customer customerdetail = new Customer()
                        {
                            Cus_Name = item.Name,
                            Cus_Inactive = item.Inactive,
                            Cus_Company_Reg_no = item.Company_Reg_No,
                            Cus_GST_Reg_No = item.GST_Reg_No,
                            Cus_Telephone = item.Telephone,
                            Cus_Fax = item.Fax,
                            Cus_Email = item.Email,
                            Cus_Contact_Person = item.Contact_Person,
                            //Cus_Type = String.IsNullOrEmpty(customerResult.Where(p => p.Cat_Code == "CT" && p.Cat_Contents == item.Type).FirstOrDefault().ID.ToString()) ? "0" : customerResult.Where(p => p.Cat_Code == "CT" && p.Cat_Contents == item.Type).FirstOrDefault().ID.ToString(),
                            //Cus_Salesman = (int?)(String.IsNullOrEmpty(customerResult.Where(p => p.Cat_Code == "SM" && p.Cat_Contents == item.Type).FirstOrDefault().ID.ToString()) ? 0 : customerResult.Where(p => p.Cat_Code == "SM" && p.Cat_Contents == item.Type).FirstOrDefault().ID),
                            //Cus_Credit_Limit_Amount = String.IsNullOrEmpty(customerResult.Where(p => p.Cat_Code == "CCLD" && p.Cat_Contents == item.Type).FirstOrDefault().ID.ToString()) ? 0 : customerResult.Where(p => p.Cat_Code == "CCLD" && p.Cat_Contents == item.Type).FirstOrDefault().ID,
                            //Cus_Credit_Limit_Days = String.IsNullOrEmpty(customerResult.Where(p => p.Cat_Code == "CCLA" && p.Cat_Contents == item.Type).FirstOrDefault().ID.ToString()) ? 0 : customerResult.Where(p => p.Cat_Code == "CCLA" && p.Cat_Contents == item.Type).FirstOrDefault().ID,
                            //Cus_Discount = String.IsNullOrEmpty(customerResult.Where(p => p.Cat_Code == "CD" && p.Cat_Contents == item.Type).FirstOrDefault().ID.ToString()) ? 0 : customerResult.Where(p => p.Cat_Code == "CD" && p.Cat_Contents == item.Type).FirstOrDefault().ID,
                            Cus_Bill_to_city = item.Bill_To_City,
                            Cus_Bill_to_country = item.Bill_To_Country,
                            Cus_Bill_to_line1 = item.Bill_To_Line1,
                            Cus_Bill_to_line2 = item.Bill_To_Line2,
                            Cus_Bill_to_post_code = item.Bill_To_Postal_Code,
                            Cus_Bill_to_state = item.Bill_To_State,
                            Cus_Ship_to_line1 = item.Bill_To_Line1,
                            Cus_Ship_to_line2 = item.Bill_To_Line2,
                            Cus_Ship_to_city = item.Bill_To_City,
                            Cus_Ship_to_country = item.Bill_To_Country,
                            Cus_Ship_to_post_code = item.Ship_To_Postal_Code,
                        };

                        var salesman = customerResult.Where(p => p.Cat_Code == "SM" && p.Cat_Contents == item.Type).FirstOrDefault();
                        customerdetail.Cus_Salesman = (salesman == null) ? 0 : salesman.ID;
                        var Type = customerResult.Where(p => p.Cat_Code == "CT" && p.Cat_Contents == item.Type).FirstOrDefault();
                        customerdetail.Cus_Type = String.IsNullOrEmpty(Type.ToString()) ? "0" : Type.ID.ToString();
                        var LimitAmount = customerResult.Where(p => p.Cat_Code == "CCLD" && p.Cat_Contents == item.Type).FirstOrDefault();
                        customerdetail.Cus_Credit_Limit_Amount = (LimitAmount == null) ? 0 : LimitAmount.ID;
                        var LimitDays = customerResult.Where(p => p.Cat_Code == "CCLA" && p.Cat_Contents == item.Type).FirstOrDefault();
                        customerdetail.Cus_Credit_Limit_Days = (LimitDays == null) ? 0 : LimitDays.ID;
                        var Discount = customerResult.Where(p => p.Cat_Code == "CD" && p.Cat_Contents == item.Type).FirstOrDefault();
                        customerdetail.Cus_Discount = (Discount == null) ? 0 : Discount.ID;
                        entities.Customers.Add(customerdetail);
                        entities.SaveChanges();
                    }
                }
                catch(Exception e)
                {
                    throw e;
                }
              
            }
            else
            {
                try
                {
                    foreach (var item in ThirdList)
                    {
                        var customer = entities.Customers.FirstOrDefault(x => x.Cus_Name == item.Name);
                        if (customer != null)
                        {
                            customer.Cus_Inactive = item.Inactive;
                            customer.Cus_Company_Reg_no = item.Company_Reg_No;
                            customer.Cus_GST_Reg_No = item.GST_Reg_No;
                            customer.Cus_Telephone = item.Telephone;
                            customer.Cus_Fax = item.Fax;
                            customer.Cus_Email = item.Email;
                            customer.Cus_Contact_Person = item.Contact_Person;
                            customer.Cus_Type = item.Type;
                            customer.Cus_Salesman = item.Salesman == string.Empty ? null as int? : Convert.ToInt32(item.Salesman);
                            customer.Cus_Credit_Limit_Amount = item.Credit_Limit_Amount == string.Empty ? null as int? : Convert.ToInt32(item.Credit_Limit_Amount);
                            customer.Cus_Credit_Limit_Days = item.Credit_Limit_Days ==string.Empty ? null as int? : Convert.ToInt32(item.Credit_Limit_Days);
                            customer.Cus_Discount = item.Discount == string.Empty ? null as int? : Convert.ToInt32(item.Discount);
                            customer.Cus_Bill_to_city = item.Bill_To_City;
                            customer.Cus_Bill_to_country = item.Bill_To_Country;
                            customer.Cus_Bill_to_line1 = item.Bill_To_Line1;
                            customer.Cus_Bill_to_line2 = item.Bill_To_Line2;
                            customer.Cus_Bill_to_post_code = item.Bill_To_Postal_Code;
                            customer.Cus_Bill_to_state = item.Bill_To_State;
                            customer.Cus_Ship_to_line1 = item.Ship_To_Line1;
                            customer.Cus_Ship_to_line2 = item.Ship_To_Line2;
                            customer.Cus_Ship_to_city = item.Ship_To_City;
                            customer.Cus_Ship_to_country = item.Ship_To_Country;
                            customer.Cus_Ship_to_post_code = item.Ship_To_Postal_Code;
                            entities.SaveChanges();
                        }

                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
               

            }


        }
        public void getSupplierList(List<Supplier_Detail> supplierList, bool RUBool)
        {

            List<Supplier_Detail> duplicate = new List<Supplier_Detail>();
            List<Supplier_Detail> unique = new List<Supplier_Detail>();
            List<Supplier_Detail> suppliersource = entities.Suppliers.Where(x => x.IsDeleted != true).Select(x => new Supplier_Detail
            {

                Name = x.Sup_Name,
                Inactive = x.Sup_Inactive,
                Company_Reg_No = x.Sup_Company_Reg_no,
                GST_Reg_No = x.Sup_GST_Reg_No,
                Telephone = x.Sup_Telephone,
                Fax = x.Sup_Fax,
                Email = x.Sup_Email,
                Contact_Person = x.Sup_Contact_Person,
                Credit_Limit_Amount = x.Sup_Credit_Limit_Amount.ToString(),
                Credit_Limit_Days = x.Sup_Credit_Limit_Days.ToString(),
                Bill_To_City = x.Sup_Bill_to_city,
                Bill_To_Country = x.Sup_Bill_to_country,
                Bill_To_Line1 = x.Sup_Bill_to_line1,
                Bill_To_Line2 = x.Sup_Bill_to_line2,
                Bill_To_Postal_Code = x.Sup_Bill_to_post_code,
                Bill_To_State = x.Sup_Bill_to_state,
                Ship_To_Line1 = x.Sup_Ship_to_line1,
                Ship_To_Line2 = x.Sup_Ship_to_line2,
                Ship_To_City = x.Sup_Ship_to_city,
                Ship_To_Country = x.Sup_Ship_to_country,
                Ship_To_State = x.Sup_Ship_to_state,
                Ship_To_Postal_Code = x.Sup_Ship_to_post_code,
                Remarks = x.Sup_Remarks,
            }).OrderBy(e => e.Name).ToList();

            var namearray = (from sDetail in suppliersource
                             select sDetail.Name).ToArray();

            duplicate = (from Supplierlist in supplierList
                         where namearray.Contains(Supplierlist.Name)
                         select Supplierlist).ToList();


            unique = supplierList.Except(duplicate).ToList();

            var ThirdList = suppliersource.Except(supplierList).ToList();

            if (RUBool == true)
            {
                try
                {
                    foreach (var item in unique)
                    {
                        Supplier supplierdetail = new Supplier()
                        { 
                            
                            Sup_Name = item.Name,
                            Sup_Inactive = item.Inactive,
                            Sup_Company_Reg_no = item.Company_Reg_No,
                            Sup_GST_Reg_No = item.GST_Reg_No,
                            Sup_Telephone = item.Telephone,
                            Sup_Fax = item.Fax,
                            Sup_Email = item.Email,
                            Sup_Contact_Person = item.Contact_Person,
                            Sup_Credit_Limit_Amount = item.Credit_Limit_Amount == string.Empty ? null as decimal? : Convert.ToDecimal(item.Credit_Limit_Amount),
                            Sup_Credit_Limit_Days = item.Credit_Limit_Days == string.Empty ? null as int? : Convert.ToInt16(item.Credit_Limit_Days),
                            Sup_Bill_to_city = item.Bill_To_City,
                            Sup_Bill_to_country = item.Bill_To_Country,
                            Sup_Bill_to_line1 = item.Bill_To_Line1,
                            Sup_Bill_to_line2 = item.Bill_To_Line2,
                            Sup_Bill_to_post_code = item.Bill_To_Postal_Code,
                            Sup_Bill_to_state = item.Bill_To_State,
                            Sup_Ship_to_line1 = item.Ship_To_Line1,
                            Sup_Ship_to_line2 = item.Ship_To_Line2,
                            Sup_Ship_to_city = item.Ship_To_City,
                            Sup_Ship_to_country = item.Ship_To_Country,
                            Sup_Ship_to_post_code = item.Ship_To_Postal_Code,
                            Sup_Remarks = item.Remarks,
                        };
                        entities.Suppliers.Add(supplierdetail);
                        entities.SaveChanges();
                    }
                }
                catch(Exception e)
                {
                    throw e;
                }
               

            }
            else
            {
                try
                {
                    foreach (var item in ThirdList)
                    {
                        var supplier = entities.Suppliers.FirstOrDefault(x => x.Sup_Name == item.Name);
                        supplier.Sup_Inactive = item.Inactive;
                        supplier.Sup_Company_Reg_no = item.Company_Reg_No;
                        supplier.Sup_GST_Reg_No = item.GST_Reg_No;
                        supplier.Sup_Telephone = item.Telephone;
                        supplier.Sup_Fax = item.Fax;
                        supplier.Sup_Email = item.Email;
                        supplier.Sup_Contact_Person = item.Contact_Person;
                        supplier.Sup_Credit_Limit_Amount = (item.Credit_Limit_Amount == string.Empty ? null as decimal? : Convert.ToDecimal(item.Credit_Limit_Amount));
                        supplier.Sup_Credit_Limit_Days = (item.Credit_Limit_Days ==string.Empty ? null as int?: Convert.ToInt32(item.Credit_Limit_Days));
                        supplier.Sup_Bill_to_city = item.Bill_To_City;
                        supplier.Sup_Bill_to_country = item.Bill_To_Country;
                        supplier.Sup_Bill_to_line1 = item.Bill_To_Line1;
                        supplier.Sup_Bill_to_line2 = item.Bill_To_Line2;
                        supplier.Sup_Bill_to_post_code = item.Bill_To_Postal_Code;
                        supplier.Sup_Bill_to_state = item.Bill_To_State;
                        supplier.Sup_Ship_to_line1 = item.Bill_To_Line1;
                        supplier.Sup_Ship_to_line2 = item.Bill_To_Line2;
                        supplier.Sup_Ship_to_city = item.Bill_To_City;
                        supplier.Sup_Ship_to_country = item.Bill_To_Country;
                        supplier.Sup_Ship_to_post_code = item.Ship_To_Postal_Code;
                        supplier.Sup_Remarks = item.Remarks;
                        entities.SaveChanges();
                    }
                }
                catch(Exception e)
                {
                    throw e;
                }
               
            }


        }
        public void getPandsDetailsList(List<PandS_Details> pands, bool RUBool)
        {
            List<PandS_Details> duplicate = new List<PandS_Details>();
            List<PandS_Details> unique = new List<PandS_Details>();
            var PandServiceResult = (from c1 in entities.Categories
                                  join c2 in entities.ProductsAndServices
                                  on c1.ID equals c2.ID
                                  select new { masterId = c1.ID, c2.Tax_ID, c1.Cat_Code }).ToList();

            List<PandS_Details> productandservicesource = entities.ProductsAndServices.Where(x => x.IsDeleted != true).Select(x => new PandS_Details
            {
                Product_and_Service_Type = x.PandS_Type,
                Isinactive = x.PandS_Inactive,
                PandS_Code = x.PandS_Code,
                PandS_Name = x.PandS_Name,
                Category1 = (x.PandS_Cat1 == null ? "0" : Convert.ToString(x.PandS_Cat1)),
                Category2 = (x.PandS_Cat2 == null ? "0" : Convert.ToString(x.PandS_Cat2)),
                Description = x.PandS_Description,
                Tax_Rate = (x.Tax_Rate == null ? "" : Convert.ToString(x.Tax_Rate)),
                Std_Cost_Price_bef_Tax = x.PandS_Ave_Cost_Price_bef_GST == null ? "" : Convert.ToString(x.PandS_Ave_Cost_Price_bef_GST),
                Std_Cost_Price_aft_Tax = x.PandS_Ave_Sell_Price_aft_GST == null ? "" : Convert.ToString(x.PandS_Ave_Sell_Price_aft_GST),
            }).OrderBy(e => e.PandS_Code).ToList();

            var namearray = (from PabdServices in productandservicesource
                             select PabdServices.PandS_Code).ToArray();

            duplicate = (from PandSlist in pands
                         where namearray.Contains(PandSlist.PandS_Code)
                         select PandSlist).ToList();


            unique = pands.Except(duplicate).ToList();
            var ThirdList = productandservicesource.Except(pands).ToList();
            if(RUBool==true)
            {
                try
                {
                    foreach (var item in unique)
                    {
                        ProductsAndService taxCodesAndRate = new ProductsAndService()
                        {
                            PandS_Type = item.Product_and_Service_Type,
                            PandS_Inactive = item.Isinactive,
                            PandS_Code = item.PandS_Code,
                            PandS_Name = item.PandS_Name,
                            //PandS_Cat1 = (item.Category1 == string.Empty ? null as int ? : Convert.ToInt32(item.Category1)),
                            //PandS_Cat2 = (item.Category2 == string.Empty ? null as int ? : Convert.ToInt32(item.Category2)),
                            PandS_Description = item.Description,
                            Tax_Rate = (item.Tax_Rate == string.Empty ? null as decimal? : Convert.ToDecimal(item.Tax_Rate)),
                            PandS_Ave_Cost_Price_bef_GST = item.Ave_Cost_Price_bef_Tax == string.Empty ? null as decimal? : Convert.ToDecimal(item.Ave_Cost_Price_bef_Tax),
                            PandS_Ave_Cost_Price_aft_GST = item.Ave_Cost_Price_aft_Tax == string.Empty ? null as decimal? : Convert.ToDecimal(item.Ave_Cost_Price_aft_Tax),

                        };
                        var category1 = PandServiceResult.Where(p => p.Cat_Code == item.PandS_Code).FirstOrDefault();
                        taxCodesAndRate.PandS_Cat1 = (category1 == null) ? 0 : category1.Tax_ID;
                        var category2 = PandServiceResult.Where(p => p.Cat_Code == item.PandS_Code).FirstOrDefault();
                        taxCodesAndRate.PandS_Cat2 = (category2 == null) ? 0 : category2.Tax_ID;
                        entities.ProductsAndServices.Add(taxCodesAndRate);
                        entities.SaveChanges();
                    }
                    
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                try
                {
                    foreach (var item in ThirdList)
                    {
                        var pandservices = entities.ProductsAndServices.FirstOrDefault(x => x.PandS_Name == item.PandS_Code);
                        pandservices.PandS_Type = item.Product_and_Service_Type;
                        pandservices.PandS_Inactive = item.Isinactive;
                        pandservices.PandS_Code = item.PandS_Code;
                        pandservices.PandS_Name = item.PandS_Name;
                        pandservices.PandS_Cat1 = (item.Category1 == string.Empty ? null as int? : Convert.ToInt32(item.Category1));
                        pandservices.PandS_Cat2 = (item.Category2 == string.Empty ? null as int? : Convert.ToInt32(item.Category2));
                        pandservices.PandS_Description = item.Description;
                        pandservices.Tax_Rate = (item.Tax_Rate == string.Empty ? null as decimal? : Convert.ToDecimal(item.Tax_Rate));
                        pandservices.PandS_Ave_Cost_Price_bef_GST = item.Ave_Cost_Price_bef_Tax == string.Empty ? null as decimal? : Convert.ToDecimal(item.Ave_Cost_Price_bef_Tax);
                        pandservices.PandS_Ave_Cost_Price_aft_GST = item.Ave_Cost_Price_aft_Tax == string.Empty ? null as decimal? : Convert.ToDecimal(item.Ave_Cost_Price_aft_Tax);
                        entities.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
           
        }
        public void getTaxCodesandRatesList(List<Tax_Codes_and_Rates> taxcodesandrates, bool RUBool)
        {
            List<Tax_Codes_and_Rates> duplicate = new List<Tax_Codes_and_Rates>();
            List<Tax_Codes_and_Rates> unique = new List<Tax_Codes_and_Rates>();
            List<Tax_Codes_and_Rates> TaxCodesandRates = entities.TaxCodesAndRates.Where(x => x.IsDeleted != true).Select(x => new Tax_Codes_and_Rates
            {

                Tax_Name = x.Tax_Name,
                Tax_Description = x.Tax_Description,
                Tax_Code = x.Tax_Code,
                Tax_Rate = x.Tax_Rate.ToString(),
                Isinactive = x.Tax_Inactive,
            }).OrderBy(e => e.Tax_Code).ToList();

            var namearray = (from tcandRates in TaxCodesandRates
                             select tcandRates.Tax_Code).ToArray();

            duplicate = (from tCodelist in taxcodesandrates
                         where namearray.Contains(tCodelist.Tax_Code)
                         select tCodelist).ToList();

            unique = taxcodesandrates.Except(duplicate).ToList();

            var ThirdList = taxcodesandrates.Except(TaxCodesandRates).ToList();
            if (RUBool == true)
            {
                try
                {
                    foreach (var item in unique)
                    {
                        TaxCodesAndRate taxCodesAndRate = new TaxCodesAndRate()
                        {
                            Tax_Name = item.Tax_Name,
                            Tax_Inactive = item.Isinactive,
                            Tax_Description = item.Tax_Description,
                            Tax_Code = item.Tax_Code,
                            Tax_Rate = item.Tax_Rate == string.Empty ? 0: Convert.ToDecimal(item.Tax_Rate),

                        };
                        entities.TaxCodesAndRates.Add(taxCodesAndRate);
                        entities.SaveChanges();
                    }
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
            else
            {
                try
                {
                    foreach (var item in ThirdList)
                    {
                        var taxandrates = entities.TaxCodesAndRates.FirstOrDefault(x => x.Tax_Code == item.Tax_Code);
                        taxandrates.Tax_Name = item.Tax_Name;
                        taxandrates.Tax_Inactive = item.Isinactive;
                        taxandrates.Tax_Description = item.Tax_Description;
                        taxandrates.Tax_Rate = item.Tax_Rate == string.Empty ? 0 : Convert.ToDecimal(item.Tax_Rate);
                        taxandrates.Tax_Code = item.Tax_Code;
                        entities.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }       
}
