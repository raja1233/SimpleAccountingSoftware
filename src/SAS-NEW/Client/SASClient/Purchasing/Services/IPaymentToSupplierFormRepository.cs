

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Purchase;
    public interface IPaymentToSupplierFormRepository
    {
        List<AccountsEntity> GetAccountDetails();
        string GetCountOfPOSuppliers(out List<SupplierDetailEntity> lstSuppliers);
        string GetCountOfPISuppliers(out List<SupplierDetailEntity> lstSuppliers);
        bool IsChequeNoPresent(string cashChequeNo);
        int SavePaymentToSupplier(PaymentToSupplierForm psForm);
        int UpdatePaymentToSupplier(PaymentToSupplierForm psForm);
        PaymentToSupplierForm GetNewPS(int? SupplierID);
        PaymentToSupplierForm GetPaymentToSupplierDetails(string cashChequeNo);
        string GetLastCashNo();
    }
}
