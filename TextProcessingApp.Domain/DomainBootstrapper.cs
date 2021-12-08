using Microsoft.Extensions.DependencyInjection;
using TextProcessingApp.Domain.Models;

namespace TextProcessingApp.Domain
{
    public static class DomainBootstrapper
    {
        public static IServiceCollection AddTextProcesser(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddScoped<IWordFrequencyAnalyzer, WordFrequencyAnalyzer>();
        }
    }
}
