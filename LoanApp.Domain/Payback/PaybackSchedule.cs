namespace LoanApp.Domain.Entities
{
	public class PaybackSchedule
	{
		public List<Payment> Payments { get; set; }

		public PaybackSchedule()
		{
			Payments = new List<Payment>();
		}

		public class Payment
		{
			public int PaymentId { get; set; }
			public decimal MonthlyPayment { get; set; }
			public decimal Principal { get; set; }
			public decimal Interest { get; set; }
			public decimal UnpaidBalance { get; set; }
		}
	}
}
