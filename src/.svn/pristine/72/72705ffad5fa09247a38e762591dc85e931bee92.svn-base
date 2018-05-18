
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.DALInterface
{
    using SDN.UI.Entities;
    using SDN.UI.Entities.Purchase;
    public interface IPaymentToSupplierDAl
    {
        List<AccountsEntity> GetAccountDetails();
        string GetCountOfPOSuppliers(out List<SupplierDetailEntity> lstSuppliers);
        string GetCountOfPISuppliers(out List<SupplierDetailEntity> lstSuppliers);
        PaymentToSupplierForm GetNewPS(int? SupplierID);
        PaymentToSupplierForm GetPaymentToSupplierDetails(string cashChequeNo);
        int SavePaymentToSupplier(PaymentToSupplierForm psForm);
        int UpdatePaymentToSupplier(PaymentToSupplierForm psForm);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLastCashNo();
    }
}
