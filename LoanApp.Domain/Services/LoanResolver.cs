using LoanApp.Domain.Exceptions;
using LoanApp.Domain.Loans;

namespace LoanApp.Domain.Services
{
	/// <summary>
	/// 
	/// </summary>
	public class LoanResolver
	{
		private readonly IEnumerable<LoanBase> _loanTypes;
		private readonly PaybackPlanResolver _planResolver;

		public LoanResolver(IEnumerable<LoanBase> loanTypes,
					  PaybackPlanResolver planResolver)
		{
			_loanTypes = loanTypes;
			_planResolver = planResolver;
		}

		public LoanBase ResolveLoanByName(string loanName, string paybackPlanName)
		{
			var paybackPlan = _planResolver.ResolvePlanByName(paybackPlanName);
			var loanType = _loanTypes.FirstOrDefault(x => x.Name == loanName);
			loanType.PaybackPlan = paybackPlan;

			if (loanType == null)
			{
				throw new InvalidLoanTypeException($"{loanName} is not a supported loan type.");
			}

			return loanType;
		}

		public LoanBase[] GetSupportedLoanTypes()
		{
			return _loanTypes.ToArray();
		}
	}
}
