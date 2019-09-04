using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPay_Payment_PLan
{
    public interface IPaymentPlan
    {
        decimal PurchasePrice { get; set; }
        DateTime PurchaseDate { get; set; }
        decimal DepositRate { get; set; }
        decimal Deposit { get; set; }
        int Installments { get; set; }
        int InstallmentsInterval { get; set; }
        List<KeyValuePair<DateTime, decimal>> InstallmentDates { get; set; }
        void CreatePlan(decimal purchaseprice, DateTime purchasedate);
    }
}
