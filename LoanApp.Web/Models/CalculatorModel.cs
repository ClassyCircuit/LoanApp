using LoanApp.Domain.Entities;
using LoanApp.Domain.Loans;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoanApp.Web.Models
{
	public class CalculatorModel
	{
		public LoanBase Loan { get; set; }
		public string SelectedLoan { get; set; }
		public string SelectedPaybackPlan { get; set; }
		public List<SelectListItem> LoanTypes { get; set; }
		public List<SelectListItem> PaybackPlans { get; set; }
		public PaybackSchedule PaybackSchedule { get; set; }
		public decimal LoanAmount { get; set; }
		public int PaybackTime { get; set; }
		public string Warning { get; set; }

		public CalculatorModel()
		{
			LoanTypes = new List<SelectListItem>();
			SelectedLoan = "Housing Loan"; // initial loan selected by default
			SelectedPaybackPlan = "Standard Payback"; // initial payback plan selected by default
		}
	}
}
