using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Timestone.SnelStartClient.Configuration;
using Timestone.SnelStartClient.Repositories.Banking;
using Timestone.SnelStartClient.Repositories.Catalog;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Repositories.Purchases;
using Timestone.SnelStartClient.Repositories.Relations;
using Timestone.SnelStartClient.Repositories.Sales;
using Timestone.SnelStartClient.Repositories.Vat;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.DependencyInjection;

/// <summary>
/// Registration extensions for the SnelStart client.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the SnelStart client and all repositories.
    /// In addition, register a named <see cref="HttpClient"/> yourself with the name <c>SnelStartHttpClientName</c>
    /// or override that name through <see cref="SnelStartClientOptions.SnelStartHttpClientName"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configureOptions">The client configuration.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddSnelStartClient(this IServiceCollection services, Action<SnelStartClientOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);

        services.Configure(configureOptions);

        services.TryAddSingleton<ISnelStartClientKeyProvider>(serviceProvider =>
            new OptionsSnelStartClientKeyProvider(
                serviceProvider.GetRequiredService<Microsoft.Extensions.Options.IOptions<SnelStartClientOptions>>()));

        services.TryAddSingleton<ISnelStartAccessTokenProvider>(serviceProvider =>
            new SnelStartAccessTokenProvider(
                serviceProvider.GetRequiredService<IHttpClientFactory>(),
                serviceProvider.GetRequiredService<Microsoft.Extensions.Options.IOptions<SnelStartClientOptions>>(),
                serviceProvider.GetRequiredService<ISnelStartClientKeyProvider>()));

        services.TryAddSingleton<ISnelStartRequestExecutor>(serviceProvider =>
            new SnelStartRequestExecutor(
                serviceProvider.GetRequiredService<IHttpClientFactory>(),
                serviceProvider.GetRequiredService<ISnelStartAccessTokenProvider>(),
                serviceProvider.GetRequiredService<Microsoft.Extensions.Options.IOptions<SnelStartClientOptions>>()));

        services.TryAddSingleton<ISnelStartClient, SnelStartClient>();

        services.TryAddSingleton<IActionPricesRepository, ActionPricesRepository>();
        services.TryAddSingleton<IArticlesRepository, ArticlesRepository>();
        services.TryAddSingleton<IItemDepartmentsRepository, ItemDepartmentsRepository>();
        services.TryAddSingleton<IPriceAgreementsRepository, PriceAgreementsRepository>();

        services.TryAddSingleton<IBankEntriesRepository, BankEntriesRepository>();
        services.TryAddSingleton<IBankStatementFilesRepository, BankStatementFilesRepository>();
        services.TryAddSingleton<ICashEntriesRepository, CashEntriesRepository>();

        services.TryAddSingleton<IAuthorizationRepository, AuthorizationRepository>();
        services.TryAddSingleton<ICompanyInfoRepository, CompanyInfoRepository>();
        services.TryAddSingleton<ICostCentresRepository, CostCentresRepository>();
        services.TryAddSingleton<ICountriesRepository, CountriesRepository>();
        services.TryAddSingleton<IDocumentsRepository, DocumentsRepository>();
        services.TryAddSingleton<IEchoRepository, EchoRepository>();
        services.TryAddSingleton<IGeneralLedgerMutationsRepository, GeneralLedgerMutationsRepository>();
        services.TryAddSingleton<IGeneralLedgersRepository, GeneralLedgersRepository>();
        services.TryAddSingleton<IJournalEntriesRepository, JournalEntriesRepository>();
        services.TryAddSingleton<IJournalsRepository, JournalsRepository>();
        services.TryAddSingleton<IReportsRepository, ReportsRepository>();

        services.TryAddSingleton<IPurchaseEntriesRepository, PurchaseEntriesRepository>();
        services.TryAddSingleton<IPurchaseInvoicesRepository, PurchaseInvoicesRepository>();

        services.TryAddSingleton<IRelationsRepository, RelationsRepository>();

        services.TryAddSingleton<IQuotationsRepository, QuotationsRepository>();
        services.TryAddSingleton<ISaleEntriesRepository, SaleEntriesRepository>();
        services.TryAddSingleton<ISaleInvoicesRepository, SaleInvoicesRepository>();
        services.TryAddSingleton<ISaleOrdersRepository, SaleOrdersRepository>();
        services.TryAddSingleton<ISaleOrderTemplatesRepository, SaleOrderTemplatesRepository>();

        services.TryAddSingleton<IVatDeclarationsRepository, VatDeclarationsRepository>();
        services.TryAddSingleton<IVatRateDefinitionsRepository, VatRateDefinitionsRepository>();
        services.TryAddSingleton<IVatRateIntlRepository, VatRateIntlRepository>();
        services.TryAddSingleton<IVatRatesRepository, VatRatesRepository>();

        return services;
    }
}
