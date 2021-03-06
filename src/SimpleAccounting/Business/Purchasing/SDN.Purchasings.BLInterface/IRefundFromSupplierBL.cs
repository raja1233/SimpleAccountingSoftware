﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BLInterface
{
    using SDN.UI.Entities;
    using UI.Entities.Purchase;

    public interface IRefundFromSupplierBL
    {
        string GetCountOfPOSuppliers(out List<SupplierDetailEntity> lstSuppliers);
        string GetCountOfDNSuppliers(out List<SupplierDetailEntity> lstSuppliers);
        RefundFromSupplierForm GetNewPS(int? SupplierID);
        RefundFromSupplierForm GetRefundFromSupplierDetails(string cashChequeNo);
        int SaveRefundFromSupplier(RefundFromSupplierForm psForm);
        int UpdateRefundFromSupplier(RefundFromSupplierForm psForm);
        bool IsChequeNoPresent(string cashChequeNo);
        string GetLastCashNo();
    }
}
