using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenPay_Payment_PLan;

namespace OpenPay_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PlanATester()
        {
            //
            IPaymentPlan plana = new PaymentPlanA();

            plana.CreatePlan(100, DateTime.Today);

        }
        [TestMethod]
        public void PlanBTester()
        {
            //
            IPaymentPlan planb = new PaymentPlanB();

            planb.CreatePlan(100, DateTime.Today);

        }
        [TestMethod]
        public void PlanCTester()
        {
            //
            IPaymentPlan planc = new PaymentPlanC();

            planc.CreatePlan(100, DateTime.Today);

        }

    }
}
