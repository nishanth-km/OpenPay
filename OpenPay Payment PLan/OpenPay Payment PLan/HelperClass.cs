using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPay_Payment_PLan
{
    public class HelperClass
    {

        public decimal GetDeposit(decimal price, decimal depositrate)
        {
            return price * depositrate;
        }

        public List<KeyValuePair<DateTime, decimal>> GetInstallments(DateTime date, int installments, double InstallmentInterval, decimal balanceamount)
        {
            List<KeyValuePair<DateTime, decimal>> InstallmentAmounts = new List<KeyValuePair<DateTime, decimal>>();
            var installmentdate = date;
            for (int i = 1; i <= installments; i++)
            {
                var installmentamount = balanceamount / installments;

                installmentdate = installmentdate.AddDays(InstallmentInterval);
                KeyValuePair<DateTime, decimal> InstallmentAmt = new KeyValuePair<DateTime, decimal>(installmentdate, installmentamount);
                InstallmentAmounts.Add(InstallmentAmt);
            }

            return InstallmentAmounts;
        }

    }
}
