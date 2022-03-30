namespace LoanApp.Web.Helpers
{
	public static class FormattingHelper
	{
		public static string GetFormattedPercentage(decimal value)
		{
			return $"{(value * 100).ToString().Trim('0').Trim('.')}%";
		}
	}
}
