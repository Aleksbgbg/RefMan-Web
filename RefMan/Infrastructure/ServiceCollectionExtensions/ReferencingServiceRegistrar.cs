namespace RefMan.Infrastructure.ServiceCollectionExtensions
{
    using Microsoft.Extensions.DependencyInjection;

    using RefMan.Services.Referencing;
    using RefMan.Services.Referencing.PageSearching;
    using RefMan.Services.Referencing.PageSearching.ContentExtraction;

    public static class ReferencingServiceRegistrar
    {
        public static IServiceCollection AddReferencingService(this IServiceCollection services)
        {
            services.AddTransient<IReferencingService, ReferencingService>()
                    .AddTransient<IPageSearcherFactory, PageSearcherFactory>()
                    .AddTransient<IContentExtractionStrategyFactory, ContentExtractionStrategyFactory>()
                    .AddTransient<IWebpageDownloader, WebpageDownloader>();

            return services;
        }
    }
}