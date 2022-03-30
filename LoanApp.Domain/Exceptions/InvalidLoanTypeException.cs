using System.Runtime.Serialization;

namespace LoanApp.Domain.Exceptions
{
	[Serializable]
	internal class InvalidLoanTypeException : Exception
	{
		public InvalidLoanTypeException()
		{
		}

		public InvalidLoanTypeException(string? message) : base(message)
		{
		}

		public InvalidLoanTypeException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected InvalidLoanTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}