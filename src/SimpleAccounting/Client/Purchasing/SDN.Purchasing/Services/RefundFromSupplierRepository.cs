
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasing.Services
{
    using Purchasings.BL;
    using Purchasings.BLInterface;
    using SDN.UI.Entities.Purchase;
    using UI.Entities;

    public class RefundFromSupplierRepository: IRefundFromSupplierRepository
    {
        public RefundFromSupplierForm GetRefundFromSupplierDetails(string cashChequeNo)
        {
            IRefundFromSupplierBL psBL = new RefundFromSupplierBL();
            return psBL.GetRefundFromSupplierDetails(cashChequeNo);
        }
        public RefundFromSupplierForm GetNewPS(int? SupplierID)
        {
            IRefundFromSupplierBL psBL = new RefundFromSupplierBL();
            return psBL.GetNewPS(SupplierID);
        }

        public int SaveRefundFromSupplier(RefundFromSupplierForm psForm)
        {
            IRefundFromSupplierBL psBL = new RefundFromSupplierBL();
            return psBL.SaveRefundFromSupplier(psForm);

        }
        public string GetCountOfPOSuppliers(out List<SupplierDetailEntity> lstSuppliers)
        {
            IRefundFromSupplierBL psBL = new RefundFromSupplierBL();
            return psBL.GetCountOfPOSuppliers(out lstSuppliers);
        }
        public string GetCountOfDNSuppliers(out List<SupplierDetailEntity> lstSuppliers)
        {
            IRefundFromSupplierBL psBL = new RefundFromSupplierBL();
            return psBL.GetCountOfDNSuppliers(out lstSuppliers);
        }
        public int UpdateRefundFromSupplier(RefundFromSupplierForm psForm)
        {
            IRefundFromSupplierBL psBL = new RefundFromSupplierBL();
            return psBL.UpdateRefundFromSupplier(psForm);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            IRefundFromSupplierBL psBL = new RefundFromSupplierBL();
            return psBL.IsChequeNoPresent(cashChequeNo);
        }
        public string GetLastCashNo()
        {
            IRefundFromSupplierBL psBL = new RefundFromSupplierBL();
            return psBL.GetLastCashNo();
        }
    }
}
