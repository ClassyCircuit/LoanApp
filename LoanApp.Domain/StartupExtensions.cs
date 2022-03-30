using LoanApp.Domain.Entities;
using LoanApp.Domain.Loans;
using LoanApp.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LoanApp.Domain
{
	public static class StartupExtensions
	{
		public static void AddDomain(this IServiceCollection services)
		{
			RegisterLoanTypes(services);
			RegisterPaybackPlans(services);
			services.AddScoped<LoanResolver>();
			services.AddScoped<PaybackPlanResolver>();
		}

		private static void RegisterPaybackPlans(IServiceCollection services)
		{
			IEnumerable<Type> paybackPlans = Assembly.GetExecutingAssembly().GetTypes()
							.Where(t => t.IsClass)
							.Where(t => !t.IsAbstract)
							.Where(t => t.GetInterfaces().Contains(typeof(IPaybackPlan)));

			foreach (var plan in paybackPlans)
			{
				services.AddScoped(typeof(IPaybackPlan), plan);
			}
		}

		private static void RegisterLoanTypes(IServiceCollection services)
		{
			IEnumerable<Type> loanTypes = Assembly.GetExecutingAssembly().GetTypes()
				.Where(t => t.IsClass)
				.Where(t => !t.IsAbstract)
				.Where(t => t.IsSubclassOf(typeof(LoanBase)));

			foreach (var loanType in loanTypes)
			{
				services.AddScoped(typeof(LoanBase), loanType);
			}
		}
	}
}
