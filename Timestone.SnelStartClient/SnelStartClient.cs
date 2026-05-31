using Timestone.SnelStartClient.Repositories.Banking;
using Timestone.SnelStartClient.Repositories.Catalog;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Repositories.Purchases;
using Timestone.SnelStartClient.Repositories.Relations;
using Timestone.SnelStartClient.Repositories.Sales;
using Timestone.SnelStartClient.Repositories.Vat;

namespace Timestone.SnelStartClient;

/// <summary>
/// Central facade over all SnelStart repositories.
/// </summary>
public sealed class SnelStartClient : ISnelStartClient
{
    /// <summary>
    /// Initializes a new central SnelStart client with access to all repositories.
    /// </summary>
    public SnelStartClient(
        IActionPricesRepository actionPrices,
        IArticlesRepository articles,
        IItemDepartmentsRepository itemDepartments,
        IPriceAgreementsRepository priceAgreements,
        IBankEntriesRepository bankEntries,
        IBankStatementFilesRepository bankStatementFiles,
        ICashEntriesRepository cashEntries,
        IAuthorizationRepository authorization,
        ICompanyInfoRepository companyInfo,
        ICostCentresRepository costCentres,
        ICountriesRepository countries,
        IDocumentsRepository documents,
        IEchoRepository echo,
        IGeneralLedgerMutationsRepository generalLedgerMutations,
        IGeneralLedgersRepository generalLedgers,
        IJournalEntriesRepository journalEntries,
        IJournalsRepository journals,
        IReportsRepository reports,
        IPurchaseEntriesRepository purchaseEntries,
        IPurchaseInvoicesRepository purchaseInvoices,
        IRelationsRepository relations,
        IQuotationsRepository quotations,
        ISaleEntriesRepository saleEntries,
        ISaleInvoicesRepository saleInvoices,
        ISaleOrdersRepository saleOrders,
        ISaleOrderTemplatesRepository saleOrderTemplates,
        IVatDeclarationsRepository vatDeclarations,
        IVatRateDefinitionsRepository vatRateDefinitions,
        IVatRateIntlRepository vatRateIntl,
        IVatRatesRepository vatRates)
    {
        ActionPrices = actionPrices;
        Articles = articles;
        ItemDepartments = itemDepartments;
        PriceAgreements = priceAgreements;
        BankEntries = bankEntries;
        BankStatementFiles = bankStatementFiles;
        CashEntries = cashEntries;
        Authorization = authorization;
        CompanyInfo = companyInfo;
        CostCentres = costCentres;
        Countries = countries;
        Documents = documents;
        Echo = echo;
        GeneralLedgerMutations = generalLedgerMutations;
        GeneralLedgers = generalLedgers;
        JournalEntries = journalEntries;
        Journals = journals;
        Reports = reports;
        PurchaseEntries = purchaseEntries;
        PurchaseInvoices = purchaseInvoices;
        Relations = relations;
        Quotations = quotations;
        SaleEntries = saleEntries;
        SaleInvoices = saleInvoices;
        SaleOrders = saleOrders;
        SaleOrderTemplates = saleOrderTemplates;
        VatDeclarations = vatDeclarations;
        VatRateDefinitions = vatRateDefinitions;
        VatRateIntl = vatRateIntl;
        VatRates = vatRates;
    }

    /// <summary>
    /// Provides access to the action prices repository.
    /// </summary>
    public IActionPricesRepository ActionPrices { get; }

    /// <summary>
    /// Provides access to the articles repository.
    /// </summary>
    public IArticlesRepository Articles { get; }

    /// <summary>
    /// Provides access to the item departments repository.
    /// </summary>
    public IItemDepartmentsRepository ItemDepartments { get; }

    /// <summary>
    /// Provides access to the price agreements repository.
    /// </summary>
    public IPriceAgreementsRepository PriceAgreements { get; }

    /// <summary>
    /// Provides access to the bank entries repository.
    /// </summary>
    public IBankEntriesRepository BankEntries { get; }

    /// <summary>
    /// Provides access to the bank statement files repository.
    /// </summary>
    public IBankStatementFilesRepository BankStatementFiles { get; }

    /// <summary>
    /// Provides access to the cash entries repository.
    /// </summary>
    public ICashEntriesRepository CashEntries { get; }

    /// <summary>
    /// Provides access to the authorization repository.
    /// </summary>
    public IAuthorizationRepository Authorization { get; }

    /// <summary>
    /// Provides access to the company information repository.
    /// </summary>
    public ICompanyInfoRepository CompanyInfo { get; }

    /// <summary>
    /// Provides access to the cost centres repository.
    /// </summary>
    public ICostCentresRepository CostCentres { get; }

    /// <summary>
    /// Provides access to the countries repository.
    /// </summary>
    public ICountriesRepository Countries { get; }

    /// <summary>
    /// Provides access to the documents repository.
    /// </summary>
    public IDocumentsRepository Documents { get; }

    /// <summary>
    /// Provides access to the echo test repository.
    /// </summary>
    public IEchoRepository Echo { get; }

    /// <summary>
    /// Provides access to the general ledger mutations repository.
    /// </summary>
    public IGeneralLedgerMutationsRepository GeneralLedgerMutations { get; }

    /// <summary>
    /// Provides access to the general ledgers repository.
    /// </summary>
    public IGeneralLedgersRepository GeneralLedgers { get; }

    /// <summary>
    /// Provides access to the journal entries repository.
    /// </summary>
    public IJournalEntriesRepository JournalEntries { get; }

    /// <summary>
    /// Provides access to the journals repository.
    /// </summary>
    public IJournalsRepository Journals { get; }

    /// <summary>
    /// Provides access to the reports repository.
    /// </summary>
    public IReportsRepository Reports { get; }

    /// <summary>
    /// Provides access to the purchase entries repository.
    /// </summary>
    public IPurchaseEntriesRepository PurchaseEntries { get; }

    /// <summary>
    /// Provides access to the purchase invoices repository.
    /// </summary>
    public IPurchaseInvoicesRepository PurchaseInvoices { get; }

    /// <summary>
    /// Provides access to the relations repository.
    /// </summary>
    public IRelationsRepository Relations { get; }

    /// <summary>
    /// Provides access to the quotations repository.
    /// </summary>
    public IQuotationsRepository Quotations { get; }

    /// <summary>
    /// Provides access to the sales entries repository.
    /// </summary>
    public ISaleEntriesRepository SaleEntries { get; }

    /// <summary>
    /// Provides access to the sales invoices repository.
    /// </summary>
    public ISaleInvoicesRepository SaleInvoices { get; }

    /// <summary>
    /// Provides access to the sales orders repository.
    /// </summary>
    public ISaleOrdersRepository SaleOrders { get; }

    /// <summary>
    /// Provides access to the sales order templates repository.
    /// </summary>
    public ISaleOrderTemplatesRepository SaleOrderTemplates { get; }

    /// <summary>
    /// Provides access to the VAT declarations repository.
    /// </summary>
    public IVatDeclarationsRepository VatDeclarations { get; }

    /// <summary>
    /// Provides access to the VAT rate definitions repository.
    /// </summary>
    public IVatRateDefinitionsRepository VatRateDefinitions { get; }

    /// <summary>
    /// Provides access to the international VAT rates repository.
    /// </summary>
    public IVatRateIntlRepository VatRateIntl { get; }

    /// <summary>
    /// Provides access to the VAT rates repository.
    /// </summary>
    public IVatRatesRepository VatRates { get; }
}
