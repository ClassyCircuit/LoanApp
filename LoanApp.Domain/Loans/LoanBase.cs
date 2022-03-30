using LoanApp.Domain.Entities;
using LoanApp.Domain.Payback;

namespace LoanApp.Domain.Loans
{
	/// <summary>
	/// Base class for all types of loans.
	/// </summary>
	public abstract class LoanBase
	{
		public string Name { get; set; }
		public decimal InterestRate { get; set; }
		public decimal MinLoanAmount { get; set; }
		public decimal MaxLoanAmount { get; set; }
		public int MinPaybackTime { get; set; }
		public int MaxPaybackTime { get; set; }
		public IPaybackPlan PaybackPlan { get; set; }

		public PaybackSchedule GetPaybackSchedule(decimal loanAmount, int loanTimeInYears)
		{
			var paybackOptions = new PaybackParameters()
			{
				LoanAmount = loanAmount,
				LoanTimeInYears = loanTimeInYears,
				InterestRate = InterestRate
			};

			return PaybackPlan.GetPaybackSchedule(paybackOptions);
		}
	}
}
