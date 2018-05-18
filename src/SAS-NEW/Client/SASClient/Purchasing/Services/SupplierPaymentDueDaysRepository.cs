using SASBAL.Purchasing;
using SDN.UI.Entities;
using SDN.UI.Entities.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASClient.Purchasing.Services
{
    public class SupplierPaymentDueDaysRepository: ISupplierPaymentDueDaysRepository
    {
        public List<SupplierPaymentDueDaysEntity> GetAllData()
        {
            ISupplierPaymentDueDaysBL paymentBL= new SupplierPaymentDueDaysBL();
            List<SupplierPaymentDueDaysEntity> PaymentList = paymentBL.GetAllData();
            return PaymentList;
        }
        public List<TaxModel> GetDefaultTaxes()
        {
            ISupplierPaymentDueDaysBL paymentBL = new SupplierPaymentDueDaysBL();
            return paymentBL.GetDefaultTaxes();
        }
        public OptionsEntity GetOptionSettings()
        {
            ISupplierPaymentDueDaysBL paymentBL = new SupplierPaymentDueDaysBL();
            return paymentBL.GetOptionSettings();

        }
    }
}
