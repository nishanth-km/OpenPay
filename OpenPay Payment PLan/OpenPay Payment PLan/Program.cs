using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace OpenPay_Payment_PLan
{
    class Program
    {
        static void Main(string[] args)
        {
            //input Purchase Date and Price
            try
            {

                decimal purchasePrice;
                DateTime purchaseDate;

                while (true)
                {

                    Console.WriteLine("Please input the Purchase Price");
                    string priceInput = Console.ReadLine();

                    if (!decimal.TryParse(priceInput, out purchasePrice))
                    {
                        Console.WriteLine("Please enter a valid amount for the Price");
                        continue;
                    }

                    Console.WriteLine("Please Input the PurchaseDate in the format : dd/mm/yyyy");
                    string dateInput = Console.ReadLine();
                    CultureInfo enAU = new CultureInfo("en-AU");
                    if (!DateTime.TryParseExact(dateInput, "dd/MM/yyyy", enAU, DateTimeStyles.None, out purchaseDate))
                    {
                        Console.WriteLine("Please enter the date in the specified format");
                        continue;
                    }


                    //choosePlan
                    //named them plan a,b,c ->  need better way to identify 
                    List<IPaymentPlan> plans = new List<IPaymentPlan>();
                    plans.AddRange(GetPlans(purchasePrice, purchaseDate));

                    Console.WriteLine("Plans Available: " + plans.Count);
                    Console.WriteLine();

                    int plancount = 1;
                    foreach (IPaymentPlan plan in plans)
                    {
                        Console.WriteLine("Plan " + plancount);
                        Console.WriteLine("Deposit - " + plan.Deposit);
                        Console.WriteLine("Date --- Installment Amount");

                        foreach (KeyValuePair<DateTime, decimal> installment in plan.InstallmentDates)
                        {
                            Console.WriteLine(installment.Key.Date.ToString() + " --- " + installment.Value);
                        }

                        plancount++;
                    }

                    Console.ReadLine();
                    break;

                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }

        public static List<IPaymentPlan> GetPlans(decimal purchaseprice, DateTime purchasedate)
        {
            List<IPaymentPlan> paymentPlans = new List<IPaymentPlan>();
            if (purchaseprice < 100 || purchaseprice >= 10000)
                throw new Exception("No plans offered for this Purchase Price");
            if (purchaseprice >= 100 && purchaseprice < 1000)
            {
                IPaymentPlan plana = new PaymentPlanA();
                plana.CreatePlan(purchaseprice, purchasedate);
                paymentPlans.Add(plana);

                IPaymentPlan planb = new PaymentPlanB();
                planb.CreatePlan(purchaseprice, purchasedate);
                paymentPlans.Add(planb);
            }
            if (purchaseprice >= 1000 && purchaseprice < 10000)
            {
                IPaymentPlan planc = new PaymentPlanC();
                planc.CreatePlan(purchaseprice, purchasedate);
                paymentPlans.Add(planc);
            }

            return paymentPlans;
        }
    }
}
