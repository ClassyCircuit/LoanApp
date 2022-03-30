using LoanApp.Domain.Payback;

namespace LoanApp.Domain.Entities
{
	/// <summary>
	/// Payments are divided on an equal basis, but percentage towards principal and interest payments vary every month.
	/// Fixed interest rate.
	/// </summary>
	public class StandardPayback : IPaybackPlan
	{
		public string Name => "Standard Payback";

		public PaybackSchedule GetPaybackSchedule(PaybackParameters paybackParams)
		{
			int paymentCount = paybackParams.LoanTimeInYears * 12;
			decimal monthlyPayment = GetMonthlyPayment(paybackParams.LoanAmount, paybackParams.InterestRate, paymentCount);

			var schedule = new PaybackSchedule();
			var balance = paybackParams.LoanAmount;

			for (int i = 0; i < paymentCount; i++)
			{
				var principalPayment = GetPrincipalPayment(monthlyPayment, balance, paybackParams.InterestRate);
				balance = balance - principalPayment;

				schedule.Payments.Add(new PaybackSchedule.Payment()
				{
					PaymentId = i + 1,
					MonthlyPayment = Math.Round(monthlyPayment, 2),
					UnpaidBalance = Math.Round(balance, 2),
					Principal = Math.Round(principalPayment, 2),
					Interest = Math.Round(monthlyPayment - principalPayment, 2)
				});

			}

			return schedule;
		}

		private decimal GetPrincipalPayment(decimal monthlyPayment, decimal balance, decimal interestRate)
		{
			var result = monthlyPayment - (balance * (interestRate / 12));
			return result;
		}

		private decimal GetMonthlyPayment(decimal principal, decimal interest, int numberOfPayments)
		{
			// Formula:
			//M= P[r(1 + r) ^ n / ((1 + r) ^ n) - 1)] 

			var P = principal;
			var r = interest / 12;
			var n = numberOfPayments;

			var inner = Convert.ToDecimal(Math.Pow((double)(1 + r), n));
			var left = r * inner;
			var right = inner - 1;

			var result = P * (left / right);

			return result;
		}
	}
}
