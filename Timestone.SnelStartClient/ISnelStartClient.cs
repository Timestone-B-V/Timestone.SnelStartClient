using Timestone.SnelStartClient.Repositories.Banking;
using Timestone.SnelStartClient.Repositories.Catalog;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Repositories.Purchases;
using Timestone.SnelStartClient.Repositories.Relations;
using Timestone.SnelStartClient.Repositories.Sales;
using Timestone.SnelStartClient.Repositories.Vat;

namespace Timestone.SnelStartClient;

/// <summary>
/// Central access point for all SnelStart repositories.
/// </summary>
public interface ISnelStartClient
{
    /// <summary>
    /// Provides access to the action prices repository.
    /// </summary>
    IActionPricesRepository ActionPrices { get; }

    /// <summary>
    /// Provides access to the articles repository.
    /// </summary>
    IArticlesRepository Articles { get; }

    /// <summary>
    /// Provides access to the item departments repository.
    /// </summary>
    IItemDepartmentsRepository ItemDepartments { get; }

    /// <summary>
    /// Provides access to the price agreements repository.
    /// </summary>
    IPriceAgreementsRepository PriceAgreements { get; }

    /// <summary>
    /// Provides access to the bank entries repository.
    /// </summary>
    IBankEntriesRepository BankEntries { get; }

    /// <summary>
    /// Provides access to the bank statement files repository.
    /// </summary>
    IBankStatementFilesRepository BankStatementFiles { get; }

    /// <summary>
    /// Provides access to the cash entries repository.
    /// </summary>
    ICashEntriesRepository CashEntries { get; }

    /// <summary>
    /// Provides access to the authorization repository.
    /// </summary>
    IAuthorizationRepository Authorization { get; }

    /// <summary>
    /// Provides access to the company information repository.
    /// </summary>
    ICompanyInfoRepository CompanyInfo { get; }

    /// <summary>
    /// Provides access to the cost centres repository.
    /// </summary>
    ICostCentresRepository CostCentres { get; }

    /// <summary>
    /// Provides access to the countries repository.
    /// </summary>
    ICountriesRepository Countries { get; }

    /// <summary>
    /// Provides access to the documents repository.
    /// </summary>
    IDocumentsRepository Documents { get; }

    /// <summary>
    /// Provides access to the echo test repository.
    /// </summary>
    IEchoRepository Echo { get; }

    /// <summary>
    /// Provides access to the general ledger mutations repository.
    /// </summary>
    IGeneralLedgerMutationsRepository GeneralLedgerMutations { get; }

    /// <summary>
    /// Provides access to the general ledgers repository.
    /// </summary>
    IGeneralLedgersRepository GeneralLedgers { get; }

    /// <summary>
    /// Provides access to the journal entries repository.
    /// </summary>
    IJournalEntriesRepository JournalEntries { get; }

    /// <summary>
    /// Provides access to the journals repository.
    /// </summary>
    IJournalsRepository Journals { get; }

    /// <summary>
    /// Provides access to the reports repository.
    /// </summary>
    IReportsRepository Reports { get; }

    /// <summary>
    /// Provides access to the purchase entries repository.
    /// </summary>
    IPurchaseEntriesRepository PurchaseEntries { get; }

    /// <summary>
    /// Provides access to the purchase invoices repository.
    /// </summary>
    IPurchaseInvoicesRepository PurchaseInvoices { get; }

    /// <summary>
    /// Provides access to the relations repository.
    /// </summary>
    IRelationsRepository Relations { get; }

    /// <summary>
    /// Provides access to the quotations repository.
    /// </summary>
    IQuotationsRepository Quotations { get; }

    /// <summary>
    /// Provides access to the sales entries repository.
    /// </summary>
    ISaleEntriesRepository SaleEntries { get; }

    /// <summary>
    /// Provides access to the sales invoices repository.
    /// </summary>
    ISaleInvoicesRepository SaleInvoices { get; }

    /// <summary>
    /// Provides access to the sales orders repository.
    /// </summary>
    ISaleOrdersRepository SaleOrders { get; }

    /// <summary>
    /// Provides access to the sales order templates repository.
    /// </summary>
    ISaleOrderTemplatesRepository SaleOrderTemplates { get; }

    /// <summary>
    /// Provides access to the VAT declarations repository.
    /// </summary>
    IVatDeclarationsRepository VatDeclarations { get; }

    /// <summary>
    /// Provides access to the VAT rate definitions repository.
    /// </summary>
    IVatRateDefinitionsRepository VatRateDefinitions { get; }

    /// <summary>
    /// Provides access to the international VAT rates repository.
    /// </summary>
    IVatRateIntlRepository VatRateIntl { get; }

    /// <summary>
    /// Provides access to the VAT rates repository.
    /// </summary>
    IVatRatesRepository VatRates { get; }
}
