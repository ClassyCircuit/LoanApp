using LoanApp.Domain.Payback;

namespace LoanApp.Domain.Entities
{
	/// <summary>
	/// Common interface for all types of payback plans.
	/// </summary>
	public interface IPaybackPlan
	{
		string Name { get; }
		PaybackSchedule GetPaybackSchedule(PaybackParameters paybackOptions);
	}
}
