using LoanApp.Domain.Payback;

namespace LoanApp.Domain.Entities
{
	public class VariableRatePayback : IPaybackPlan
	{
		public string Name => "Variable Rate Payback";

		public PaybackSchedule GetPaybackSchedule(PaybackParameters paybackOptions)
		{
			// Here we can extend payback plans by adding a new set of calculations

			throw new NotImplementedException();
		}
	}
}
