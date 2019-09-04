using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OpenPay_Payment_PLan
{
    public class PaymentPlanA : IPaymentPlan
    {
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal DepositRate { get; set; }
        public decimal Deposit { get; set; }
        public int Installments { get; set; }
        public int InstallmentsInterval { get; set; }
        public List<KeyValuePair<DateTime, decimal>> InstallmentDates { get; set; }
        public HelperClass helper;

        public void CreatePlan(decimal purchaseprice, DateTime purchasedate)
        {
            PurchasePrice = purchaseprice;
            PurchaseDate = purchasedate;
            DepositRate = 0.20M; //%
            Installments = 5;
            InstallmentsInterval = 15; //days
            helper = new HelperClass();


            Deposit = helper.GetDeposit(PurchasePrice, DepositRate);
            InstallmentDates = helper.GetInstallments(PurchaseDate, Installments, InstallmentsInterval, (PurchasePrice - Deposit));
        }

    }
}
