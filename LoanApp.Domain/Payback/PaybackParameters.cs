namespace LoanApp.Domain.Payback
{
	public class PaybackParameters
	{
		public decimal LoanAmount { get; set; }
		public int LoanTimeInYears { get; set; }
		public decimal InterestRate { get; set; }
	}
}
