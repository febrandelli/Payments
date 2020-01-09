using System;
using System.Collections.Generic;
using System.Text;
using Payments.Services.Interfaces;

namespace Payments.Services
{
    class PaypalServices : IOnlinePaymentService
    {

        public double PaymentFee(double amount)
        {

            return amount * 1.02;
        }

        public double Interest(double amount, int months)
        {
            return amount * (1+(0.01 * months));
        }
    }
}
