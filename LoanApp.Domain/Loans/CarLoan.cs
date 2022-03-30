namespace LoanApp.Domain.Loans
{
	public class CarLoan : LoanBase
	{
		public CarLoan()
		{
			Name = "Car Loan";
			MinLoanAmount = 500;
			MaxLoanAmount = 10000m;
			MaxPaybackTime = 1;
			MaxPaybackTime = 10;
			InterestRate = 0.09m;
		}
	}
}
