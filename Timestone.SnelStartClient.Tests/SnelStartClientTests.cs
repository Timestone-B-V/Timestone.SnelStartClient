using Timestone.SnelStartClient.Repositories.Banking;
using Timestone.SnelStartClient.Repositories.Catalog;
using Timestone.SnelStartClient.Repositories.Core;
using Timestone.SnelStartClient.Repositories.Purchases;
using Timestone.SnelStartClient.Repositories.Relations;
using Timestone.SnelStartClient.Repositories.Sales;
using Timestone.SnelStartClient.Repositories.Vat;
using Timestone.SnelStartClient.Tests.TestDoubles;

namespace Timestone.SnelStartClient.Tests;

public sealed class SnelStartClientTests
{
    [Fact]
    public void Constructor_WhenCalled_AssignsAllRepositoryProperties()
    {
        var actionPrices = NoOpDispatchProxy.Create<IActionPricesRepository>();
        var articles = NoOpDispatchProxy.Create<IArticlesRepository>();
        var itemDepartments = NoOpDispatchProxy.Create<IItemDepartmentsRepository>();
        var priceAgreements = NoOpDispatchProxy.Create<IPriceAgreementsRepository>();
        var bankEntries = NoOpDispatchProxy.Create<IBankEntriesRepository>();
        var bankStatementFiles = NoOpDispatchProxy.Create<IBankStatementFilesRepository>();
        var cashEntries = NoOpDispatchProxy.Create<ICashEntriesRepository>();
        var authorization = NoOpDispatchProxy.Create<IAuthorizationRepository>();
        var companyInfo = NoOpDispatchProxy.Create<ICompanyInfoRepository>();
        var costCentres = NoOpDispatchProxy.Create<ICostCentresRepository>();
        var countries = NoOpDispatchProxy.Create<ICountriesRepository>();
        var documents = NoOpDispatchProxy.Create<IDocumentsRepository>();
        var echo = NoOpDispatchProxy.Create<IEchoRepository>();
        var generalLedgerMutations = NoOpDispatchProxy.Create<IGeneralLedgerMutationsRepository>();
        var generalLedgers = NoOpDispatchProxy.Create<IGeneralLedgersRepository>();
        var journalEntries = NoOpDispatchProxy.Create<IJournalEntriesRepository>();
        var journals = NoOpDispatchProxy.Create<IJournalsRepository>();
        var reports = NoOpDispatchProxy.Create<IReportsRepository>();
        var purchaseEntries = NoOpDispatchProxy.Create<IPurchaseEntriesRepository>();
        var purchaseInvoices = NoOpDispatchProxy.Create<IPurchaseInvoicesRepository>();
        var relations = NoOpDispatchProxy.Create<IRelationsRepository>();
        var quotations = NoOpDispatchProxy.Create<IQuotationsRepository>();
        var saleEntries = NoOpDispatchProxy.Create<ISaleEntriesRepository>();
        var saleInvoices = NoOpDispatchProxy.Create<ISaleInvoicesRepository>();
        var saleOrders = NoOpDispatchProxy.Create<ISaleOrdersRepository>();
        var saleOrderTemplates = NoOpDispatchProxy.Create<ISaleOrderTemplatesRepository>();
        var vatDeclarations = NoOpDispatchProxy.Create<IVatDeclarationsRepository>();
        var vatRateDefinitions = NoOpDispatchProxy.Create<IVatRateDefinitionsRepository>();
        var vatRateIntl = NoOpDispatchProxy.Create<IVatRateIntlRepository>();
        var vatRates = NoOpDispatchProxy.Create<IVatRatesRepository>();

        var client = new SnelStartClient(
            actionPrices,
            articles,
            itemDepartments,
            priceAgreements,
            bankEntries,
            bankStatementFiles,
            cashEntries,
            authorization,
            companyInfo,
            costCentres,
            countries,
            documents,
            echo,
            generalLedgerMutations,
            generalLedgers,
            journalEntries,
            journals,
            reports,
            purchaseEntries,
            purchaseInvoices,
            relations,
            quotations,
            saleEntries,
            saleInvoices,
            saleOrders,
            saleOrderTemplates,
            vatDeclarations,
            vatRateDefinitions,
            vatRateIntl,
            vatRates);

        Assert.Same(actionPrices, client.ActionPrices);
        Assert.Same(articles, client.Articles);
        Assert.Same(itemDepartments, client.ItemDepartments);
        Assert.Same(priceAgreements, client.PriceAgreements);
        Assert.Same(bankEntries, client.BankEntries);
        Assert.Same(bankStatementFiles, client.BankStatementFiles);
        Assert.Same(cashEntries, client.CashEntries);
        Assert.Same(authorization, client.Authorization);
        Assert.Same(companyInfo, client.CompanyInfo);
        Assert.Same(costCentres, client.CostCentres);
        Assert.Same(countries, client.Countries);
        Assert.Same(documents, client.Documents);
        Assert.Same(echo, client.Echo);
        Assert.Same(generalLedgerMutations, client.GeneralLedgerMutations);
        Assert.Same(generalLedgers, client.GeneralLedgers);
        Assert.Same(journalEntries, client.JournalEntries);
        Assert.Same(journals, client.Journals);
        Assert.Same(reports, client.Reports);
        Assert.Same(purchaseEntries, client.PurchaseEntries);
        Assert.Same(purchaseInvoices, client.PurchaseInvoices);
        Assert.Same(relations, client.Relations);
        Assert.Same(quotations, client.Quotations);
        Assert.Same(saleEntries, client.SaleEntries);
        Assert.Same(saleInvoices, client.SaleInvoices);
        Assert.Same(saleOrders, client.SaleOrders);
        Assert.Same(saleOrderTemplates, client.SaleOrderTemplates);
        Assert.Same(vatDeclarations, client.VatDeclarations);
        Assert.Same(vatRateDefinitions, client.VatRateDefinitions);
        Assert.Same(vatRateIntl, client.VatRateIntl);
        Assert.Same(vatRates, client.VatRates);
    }
}
