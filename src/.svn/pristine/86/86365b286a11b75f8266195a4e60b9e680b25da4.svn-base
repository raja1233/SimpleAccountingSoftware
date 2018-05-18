
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Purchasings.BL
{
    using DAL;
    using DALInterface;
    using SDN.Purchasings.BLInterface;
    using UI.Entities;
    using UI.Entities.Purchase;

    public class RefundFromSupplierBL: IRefundFromSupplierBL
    {
        public RefundFromSupplierForm GetRefundFromSupplierDetails(string cashChequeNo)
        {
            IRefundFromSupplierDAL psDAL = new RefundFromSupplierDAL();
            return psDAL.GetRefundFromSupplierDetails(cashChequeNo);
        }
        public bool IsChequeNoPresent(string cashChequeNo)
        {
            IRefundFromSupplierDAL psDAL = new RefundFromSupplierDAL();
            return psDAL.IsChequeNoPresent(cashChequeNo);
        }
        public RefundFromSupplierForm GetNewPS(int? SupplierID)
        {
            IRefundFromSupplierDAL psDAL = new RefundFromSupplierDAL();
            return psDAL.GetNewPS(SupplierID);
        }
        public int SaveRefundFromSupplier(RefundFromSupplierForm psForm)
        {
            IRefundFromSupplierDAL psDAL = new RefundFromSupplierDAL();
            return psDAL.SaveRefundFromSupplier(psForm);
        }
        public int UpdateRefundFromSupplier(RefundFromSupplierForm psForm)
        {
            IRefundFromSupplierDAL psDAL = new RefundFromSupplierDAL();
            return psDAL.UpdateRefundFromSupplier(psForm);
        }
        public string GetCountOfPOSuppliers(out List<SupplierDetailEntity> lstSuppliers)
        {
            IRefundFromSupplierDAL psDAL = new RefundFromSupplierDAL();
            return psDAL.GetCountOfPOSuppliers(out lstSuppliers);
        }
        public string GetCountOfDNSuppliers(out List<SupplierDetailEntity> lstSuppliers)
        {
            IRefundFromSupplierDAL psDAL = new RefundFromSupplierDAL();
            return psDAL.GetCountOfDNSuppliers(out lstSuppliers);
        }

        public string GetLastCashNo()
        {
            IRefundFromSupplierDAL psDAL = new RefundFromSupplierDAL();
            return psDAL.GetLastCashNo();
        }
    }
}
