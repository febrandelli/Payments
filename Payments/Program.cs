using System;
using Payments.Entities;
using System.Globalization;
using Payments.Services;
using Payments.Services.Interfaces;

namespace Payments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data ");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Contract value: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Contract contract = new Contract(number, date, value);
            Console.Write("Enter number of installments: ");
            int installments = int.Parse(Console.ReadLine());
            IOnlinePaymentService service = new PaypalServices();
            ContractServices contractServices = new ContractServices(service);
            contractServices.ProcessContract(contract, installments);
            foreach (var installment in contract.Installments)
            {
                Console.WriteLine($"{installment.DueDate.ToString("dd/MM/yyyy")} - {installment.Amount.ToString("F2")}");
            }
        }
    }
}
