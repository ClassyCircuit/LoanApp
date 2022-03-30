using System.Runtime.Serialization;

namespace LoanApp.Domain.Exceptions
{
	[Serializable]
	internal class InvalidPaybackPlanException : Exception
	{
		public InvalidPaybackPlanException()
		{
		}

		public InvalidPaybackPlanException(string message) : base(message)
		{
		}

		public InvalidPaybackPlanException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InvalidPaybackPlanException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}