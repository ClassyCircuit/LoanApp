using LoanApp.Domain.Entities;
using LoanApp.Domain.Loans;
using LoanApp.Domain.Services;
using LoanApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoanApp.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly LoanResolver _loanResolver;
		private readonly PaybackPlanResolver _paybackPlanResolver;

		public HomeController(LoanResolver loanResolver,
						PaybackPlanResolver paybackPlanResolver)
		{
			_loanResolver = loanResolver;
			_paybackPlanResolver = paybackPlanResolver;
		}

		[HttpGet]
		[HttpPost]
		public IActionResult Index(CalculatorModel model = null)
		{
			if (model == null)
			{
				model = new CalculatorModel();
			}

			var supportedLoans = _loanResolver.GetSupportedLoanTypes();
			var supportedPaybackPlans = _paybackPlanResolver.GetSupportedPlanTypes();

			var selectedLoan = _loanResolver.ResolveLoanByName(model.SelectedLoan, model.SelectedPaybackPlan);
			model.Loan = selectedLoan;

			SetDropDownMenus(model, supportedLoans, supportedPaybackPlans, selectedLoan);
			PopulatePaybackSchedule(model);

			return View(model);
		}

		private static void SetDropDownMenus(CalculatorModel model, LoanBase[] supportedLoans, IPaybackPlan[] supportedPaybackPlans, LoanBase selectedLoan)
		{
			model.LoanTypes = supportedLoans.Select(t => new SelectListItem()
			{
				Text = t.Name,
				Value = t.Name,
				Selected = t.Name == selectedLoan.Name

			}).ToList();

			model.PaybackPlans = supportedPaybackPlans.Select(t => new SelectListItem()
			{
				Text = t.Name,
				Value = t.Name,
				Selected = t.Name == selectedLoan.PaybackPlan.Name

			}).ToList();
		}

		private void PopulatePaybackSchedule(CalculatorModel model)
		{
			if (model.LoanAmount == 0 || model.PaybackTime == 0)
			{
				return;
			}

			try
			{
				model.PaybackSchedule = model.Loan.GetPaybackSchedule(loanAmount: model.LoanAmount, loanTimeInYears: model.PaybackTime);
			}
			catch (NotImplementedException)
			{
				model.Warning = $"'{model.Loan.PaybackPlan.Name}' calculations are not implemented. It is added as an example how to extend the app.";
			}
		}
	}
}
