namespace LoanApp.Domain.Loans
{
	public class HousingLoan : LoanBase
	{
		public HousingLoan()
		{
			// In a real system these values would be configurable and persistable.
			// For the sake of simplicity they are hard-coded now.

			Name = "Housing Loan";
			MinLoanAmount = 1000m;
			MaxLoanAmount = 500000m;
			MaxPaybackTime = 1;
			MaxPaybackTime = 30;
			InterestRate = 0.035m;
		}
	}
}
