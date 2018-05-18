using SDN.Purchasings.DALInterface;
using SDN.PurchasingsEDM;
using SDN.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DAL
{
    public class SupplierDAL : ISupplierDAL
    {
        SDNPurchasingDBEntities entities = new SDNPurchasingDBEntities();
        public List<SupplierDetailEntity> GetAllSupplier()
        {
            List<SupplierDetailEntity> suppliersource = entities.Suppliers.Where(x => x.IsDeleted != true).Select(x => new SupplierDetailEntity
            {
                ID = x.ID,
                SupplierName = x.Sup_Name,
                Sup_Bill_to_city = x.Sup_Bill_to_city,
                Sup_Bill_to_country = x.Sup_Bill_to_country,
                Sup_Bill_to_line1 = x.Sup_Bill_to_line1,
                Sup_Bill_to_line2 = x.Sup_Bill_to_line2,
                Sup_Bill_to_post_code = x.Sup_Bill_to_post_code,
                Sup_Bill_to_state = x.Sup_Bill_to_state,
                ShipAddressLine1 = x.Sup_Ship_to_line1,
                ShipAddressLine2 = x.Sup_Ship_to_line2,
                ShipCity = x.Sup_Ship_to_city,
                ShipCountry = x.Sup_Ship_to_country,
                ShipPostalCode = x.Sup_Ship_to_post_code,
                ShipState = x.Sup_Ship_to_state,
                Supp_Reg_No = x.Sup_Company_Reg_no,
                CreditLimitDays = x.Sup_Credit_Limit_Days.ToString(),
                //SelectedCreditLimitAmount = x.Sup_Credit_Limit_Amount == null ? null as decimal? : x.Sup_Credit_Limit_Amount,
                Telephone = x.Sup_Telephone,
                Fax = x.Sup_Fax,
                Email = x.Sup_Email,
                ContactPerson = x.Sup_Contact_Person,
                GstRegistrationNo = x.Sup_GST_Reg_No,
                Remarks = x.Sup_Remarks,
                ChangeSupplierGST = x.Sup_Charge_GST,
                IsInActive = x.Sup_Inactive,
                IsRefreshed = x.IsRefreshed,
                RefreshedDate = x.RefreshedDate,
                CreditLimitAmount = x.Sup_Credit_Limit_Amount.ToString(),
                TaxId = x.TaxId

            }).OrderBy(e=>e.SupplierName).ToList();
            return suppliersource;
        }

        public bool CreateSupplier(SupplierDetailEntity entity)
        {
            try
            {
                var supplier = entities.Suppliers.FirstOrDefault(x => x.ID == entity.ID);
                if (supplier != null)
                {
                    supplier.Sup_Name = entity.SupplierName;
                    supplier.Sup_Bill_to_city = entity.Sup_Bill_to_city;
                    supplier.Sup_Bill_to_country = entity.Sup_Bill_to_country;
                    supplier.Sup_Bill_to_line1 = entity.Sup_Bill_to_line1;
                    supplier.Sup_Bill_to_line2 = entity.Sup_Bill_to_line2;
                    supplier.Sup_Bill_to_post_code = entity.Sup_Bill_to_post_code;
                    supplier.Sup_Bill_to_state = entity.Sup_Bill_to_state;
                    supplier.Sup_Company_Reg_no = entity.Supp_Reg_No;
                    supplier.Sup_Contact_Person = entity.ContactPerson;
                    supplier.Sup_Credit_Limit_Amount = Convert.ToDecimal(entity.CreditLimitAmount);
                    supplier.Sup_Credit_Limit_Days = entity.CreditLimitDays == string.Empty ? null as Int32? : Convert.ToInt32(entity.CreditLimitDays);
                    supplier.Sup_Email = entity.Email;
                    supplier.Sup_Fax = entity.Fax;
                    supplier.Sup_GST_Reg_No = entity.GstRegistrationNo;
                    supplier.Sup_Remarks = entity.Remarks;
                    supplier.Sup_Ship_to_city = entity.ShipCity;
                    supplier.Sup_Ship_to_country = entity.ShipCountry;
                    supplier.Sup_Ship_to_line1 = entity.ShipAddressLine1;
                    supplier.Sup_Ship_to_line2 = entity.ShipAddressLine2;
                    supplier.Sup_Ship_to_post_code = entity.ShipPostalCode;
                    supplier.Sup_Ship_to_state = entity.ShipState;
                    supplier.Sup_Telephone = entity.Telephone;
                    supplier.Sup_Charge_GST = entity.ChangeSupplierGST;
                    supplier.Sup_Inactive = entity.IsInActive;
                    supplier.TaxId = entity.TaxId;
                    entities.SaveChanges();
                    return true;
                }
                else
                {
                    Supplier supplierdetail = new Supplier()
                    {
                        Sup_Name = entity.SupplierName,
                        Sup_Bill_to_city = entity.Sup_Bill_to_city,
                        Sup_Bill_to_country = entity.Sup_Bill_to_country,
                        Sup_Bill_to_line1 = entity.Sup_Bill_to_line1,
                        Sup_Bill_to_line2 = entity.Sup_Bill_to_line2,
                        Sup_Bill_to_post_code = entity.Sup_Bill_to_post_code,
                        Sup_Bill_to_state = entity.Sup_Bill_to_state,
                        Sup_Company_Reg_no = entity.Supp_Reg_No,
                        Sup_Contact_Person = entity.ContactPerson,
                        Sup_Credit_Limit_Amount = Convert.ToDecimal(entity.CreditLimitAmount),
                        Sup_Credit_Limit_Days = entity.CreditLimitDays == string.Empty ? null as Int32? : Convert.ToInt32(entity.CreditLimitDays),
                        Sup_Email = entity.Email,
                        Sup_Fax = entity.Fax,
                        Sup_GST_Reg_No = entity.GstRegistrationNo,
                        Sup_Remarks = entity.Remarks,
                        Sup_Ship_to_city = entity.ShipCity,
                        Sup_Ship_to_country = entity.ShipCountry,
                        Sup_Ship_to_line1 = entity.ShipAddressLine1,
                        Sup_Ship_to_line2 = entity.ShipAddressLine2,
                        Sup_Ship_to_post_code = entity.ShipPostalCode,
                        Sup_Ship_to_state = entity.ShipState,
                        Sup_Telephone = entity.Telephone,
                        Sup_Charge_GST = entity.ChangeSupplierGST,
                        Sup_Inactive = entity.IsInActive,
                        TaxId = entity.SelectedTaxId
                    };
                    entities.Suppliers.Add(supplierdetail);
                    entities.SaveChanges();
                    return true;

                }
            }
            catch
            {
                return false;
            }
            //if (entities.SupplierDetails.AsNoTracking().FirstOrDefault(x => x.ID == entity.ID) == null)
            //{
            //    entities.SupplierDetails.Add(entity);
            //}
            //else
            //{
            //    entities.Entry(entity).State = EntityState.Modified;
            //}
        }

        public int GetSupplierCount(string isInActive)
        {
            int customerCount = 0;
            customerCount = SupplierListByStatus(isInActive).Count();

            return customerCount;
        }
        private List<SupplierDetailEntity> SupplierListByStatus(string isInActive)
        {
            string activeVal = "A";
            if (isInActive.ToString() != string.Empty)
            {
                activeVal = isInActive;
            }
            List<SupplierDetailEntity> resultCust = new List<SupplierDetailEntity>();

            if (activeVal == "A")
            {
                resultCust = entities.Suppliers.Where(x => x.IsDeleted != true).Select(x => new SupplierDetailEntity
                {
                    ID = x.ID,
                    SupplierName = x.Sup_Name,
                    Sup_Bill_to_city = x.Sup_Bill_to_city,
                    Sup_Bill_to_country = x.Sup_Bill_to_country,
                    Sup_Bill_to_line1 = x.Sup_Bill_to_line1,
                    Sup_Bill_to_line2 = x.Sup_Bill_to_line2,
                    Sup_Bill_to_post_code = x.Sup_Bill_to_post_code,
                    Sup_Bill_to_state = x.Sup_Bill_to_state,
                    ShipAddressLine1 = x.Sup_Ship_to_line1,
                    ShipAddressLine2 = x.Sup_Ship_to_line2,
                    ShipCity = x.Sup_Ship_to_city,
                    ShipCountry = x.Sup_Ship_to_country,
                    ShipPostalCode = x.Sup_Ship_to_post_code,
                    ShipState = x.Sup_Ship_to_state,
                    Supp_Reg_No = x.Sup_Company_Reg_no,
                    CreditLimitDays = x.Sup_Credit_Limit_Days.ToString(),
                    //SelectedCreditLimitAmount = x.Sup_Credit_Limit_Amount == null ? null as decimal? : x.Sup_Credit_Limit_Amount,
                    Telephone = x.Sup_Telephone,
                    Fax = x.Sup_Fax,
                    Email = x.Sup_Email,
                    ContactPerson = x.Sup_Contact_Person,
                    GstRegistrationNo = x.Sup_GST_Reg_No,
                    Remarks = x.Sup_Remarks,
                    ChangeSupplierGST = x.Sup_Charge_GST,
                    IsInActive = x.Sup_Inactive
                }).OrderBy(e => e.SupplierName).ToList();

            }
            else
            {
                resultCust = entities.Suppliers.Where(x => x.IsDeleted != true && x.Sup_Inactive == activeVal).Select(x => new SupplierDetailEntity
                {
                    ID = x.ID,
                    SupplierName = x.Sup_Name,
                    Sup_Bill_to_city = x.Sup_Bill_to_city,
                    Sup_Bill_to_country = x.Sup_Bill_to_country,
                    Sup_Bill_to_line1 = x.Sup_Bill_to_line1,
                    Sup_Bill_to_line2 = x.Sup_Bill_to_line2,
                    Sup_Bill_to_post_code = x.Sup_Bill_to_post_code,
                    Sup_Bill_to_state = x.Sup_Bill_to_state,
                    ShipAddressLine1 = x.Sup_Ship_to_line1,
                    ShipAddressLine2 = x.Sup_Ship_to_line2,
                    ShipCity = x.Sup_Ship_to_city,
                    ShipCountry = x.Sup_Ship_to_country,
                    ShipPostalCode = x.Sup_Ship_to_post_code,
                    ShipState = x.Sup_Ship_to_state,
                    Supp_Reg_No = x.Sup_Company_Reg_no,
                    CreditLimitDays = x.Sup_Credit_Limit_Days.ToString(),
                    //SelectedCreditLimitAmount = x.Sup_Credit_Limit_Amount == null ? null as decimal? : x.Sup_Credit_Limit_Amount,
                    Telephone = x.Sup_Telephone,
                    Fax = x.Sup_Fax,
                    Email = x.Sup_Email,
                    ContactPerson = x.Sup_Contact_Person,
                    GstRegistrationNo = x.Sup_GST_Reg_No,
                    Remarks = x.Sup_Remarks,
                    ChangeSupplierGST = x.Sup_Charge_GST,
                    IsInActive = x.Sup_Inactive
                }).OrderBy(e => e.SupplierName).ToList();

            }



            return resultCust;
        }

        public bool CanDeleteSupplier(int supId)
        {
            bool allowDelete = true;

            var PQ = entities.PurchaseQuotations.Where(x => x.IsDeleted != true && x.Sup_Id == supId).FirstOrDefault();
            var PO = entities.PurchaseOrders.Where(x => x.IsDeleted != true && x.Sup_Id == supId).FirstOrDefault();
            var PI = entities.PurchaseInvoices.Where(x => x.IsDeleted != true && x.Sup_Id == supId).FirstOrDefault();
            if (PQ != null || PO != null || PI != null)
            {
                allowDelete = false;
            }
            //else if (PO != null)
            //{
            //    allowDelete = false;
            //}
            //else if (PI != null)
            //{
            //    allowDelete = false;
            //}

            return allowDelete;
        }

        public bool DeleteSupplier(int supId)
        {
            bool result = false;
            try
            {
                var obj = entities.Suppliers.Where(x => x.ID == supId).FirstOrDefault();
                entities.Suppliers.Remove(obj);
                entities.SaveChanges();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool RefreshSupplier(int supId)
        {
            bool result = false;
            try
            {
                    var obj = entities.Suppliers.Where(x => x.IsRefreshed == true).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.IsRefreshed = false;
                        entities.SaveChanges();
                    }
                    var obj2 = entities.Suppliers.Where(x => x.ID == supId).FirstOrDefault();
                    if (obj2 != null)
                    {
                        obj2.IsRefreshed = true;
                        obj2.RefreshedDate = System.DateTime.UtcNow;
                        entities.SaveChanges();
                    }

                
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public List<string> GetAutoFillData(string EntityType)
        {
            List<string> lstResult = new List<string>();
            if (EntityType != string.Empty)
            {
                    if (EntityType.ToLower() == "country")
                    {
                        lstResult = entities.Suppliers.Select(x => x.Sup_Bill_to_country).Distinct().ToList();
                    }
                    else if (EntityType.ToLower() == "state")
                    {
                        lstResult = entities.Suppliers.Select(x => x.Sup_Bill_to_state).Distinct().ToList();
                    }
                    else if (EntityType.ToLower() == "city")
                    {
                        lstResult = entities.Suppliers.Select(x => x.Sup_Bill_to_city).Distinct().ToList();
                    }
                    else if (EntityType.ToLower() == "postalcode")
                    {
                        lstResult = entities.Suppliers.Select(x => x.Sup_Bill_to_post_code).Distinct().ToList();
                    }
            }
            return lstResult;
        }

        public SupplierDetailEntity GetSupplierById(int supId)
        {
            try {
                SupplierDetailEntity suppliersource = entities.Suppliers.Where(x => x.IsDeleted != true && x.ID== supId).Select(x => new SupplierDetailEntity
                {
                    ID = x.ID,
                    SupplierName = x.Sup_Name,
                    Sup_Bill_to_city = x.Sup_Bill_to_city,
                    Sup_Bill_to_country = x.Sup_Bill_to_country,
                    Sup_Bill_to_line1 = x.Sup_Bill_to_line1,
                    Sup_Bill_to_line2 = x.Sup_Bill_to_line2,
                    Sup_Bill_to_post_code = x.Sup_Bill_to_post_code,
                    Sup_Bill_to_state = x.Sup_Bill_to_state,
                    ShipAddressLine1 = x.Sup_Ship_to_line1,
                    ShipAddressLine2 = x.Sup_Ship_to_line2,
                    ShipCity = x.Sup_Ship_to_city,
                    ShipCountry = x.Sup_Ship_to_country,
                    ShipPostalCode = x.Sup_Ship_to_post_code,
                    ShipState = x.Sup_Ship_to_state,
                    Supp_Reg_No = x.Sup_Company_Reg_no,
                    CreditLimitDays = x.Sup_Credit_Limit_Days.ToString(),                   
                    Telephone = x.Sup_Telephone,
                    Fax = x.Sup_Fax,
                    Email = x.Sup_Email,
                    ContactPerson = x.Sup_Contact_Person,
                    GstRegistrationNo = x.Sup_GST_Reg_No,
                    Remarks = x.Sup_Remarks,
                    ChangeSupplierGST = x.Sup_Charge_GST,
                    IsInActive = x.Sup_Inactive,
                    IsRefreshed = x.IsRefreshed,
                    RefreshedDate = x.RefreshedDate,
                    CreditLimitAmount = x.Sup_Credit_Limit_Amount.ToString(),

                }).FirstOrDefault();
                return suppliersource;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

