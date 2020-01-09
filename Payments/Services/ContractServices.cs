using System;
using System.Collections.Generic;
using Payments.Entities;
using System.Text;
using Payments.Services.Interfaces;

namespace Payments.Services
{
    class ContractServices
    {
        private IOnlinePaymentService _onlinePaymentService;
        public ContractServices(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double valueInstallmentNoTax = contract.TotalValue / months;
            for (int i = 1; i <= months; i++)
            {
                double valueInstallmentWithTax = _onlinePaymentService.PaymentFee(_onlinePaymentService.Interest(valueInstallmentNoTax,i));
                DateTime installmentDate = contract.Date.AddMonths(i);
                contract.Installments.Add(new Installment(installmentDate, valueInstallmentWithTax));
            }
        }
    }
}
