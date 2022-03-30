using LoanApp.Domain.Entities;
using LoanApp.Domain.Exceptions;

namespace LoanApp.Domain.Services
{
	public class PaybackPlanResolver
	{
		private readonly IEnumerable<IPaybackPlan> _paybackPlans;

		public PaybackPlanResolver(IEnumerable<IPaybackPlan> paybackPlans)
		{
			_paybackPlans = paybackPlans;
		}

		public IPaybackPlan ResolvePlanByName(string name)
		{
			var result = _paybackPlans.FirstOrDefault(x => x.Name == name);

			if (result == null)
			{
				throw new InvalidPaybackPlanException($"{name} is not a supported payback plan.");
			}

			return result;
		}

		public IPaybackPlan[] GetSupportedPlanTypes()
		{
			return _paybackPlans.ToArray();
		}
	}
}
