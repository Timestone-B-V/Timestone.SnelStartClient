# Timestone.SnelStartClient

**English version below**

`Timestone.SnelStartClient` is een .NET-client voor de SnelStart B2B API. De library biedt een centrale `ISnelStartClient` met repositories voor onder meer artikelen, relaties, verkoop, inkoop, bankboekingen, rapportages en btw.

De library ondersteunt naast simpele requests ook typed OData-queryopbouw voor endpoints die filteren, sorteren, pagineren en selecteren ondersteunen.

## Installatie

```bash
dotnet add package TimestoneNL.SnelStartClient
```

## Registratie via dependency injection

### Aanbevolen: dynamische client key via provider

Gebruik voor multi-tenant- of klantspecifieke scenario's een eigen `ISnelStartClientKeyProvider`. De library vraagt deze provider iedere keer op wanneer een nieuw token nodig is en cachet tokens per client key.

```csharp
using Timestone.SnelStartClient.Configuration;
using Timestone.SnelStartClient.DependencyInjection;

services.AddHttpContextAccessor();

services.AddSingleton<ISnelStartClientKeyProvider, HttpContextSnelStartClientKeyProvider>();

services.AddHttpClient(SnelStartClientOptions.DefaultHttpClientName, client =>
{
    client.BaseAddress = new Uri("https://b2bapi.snelstart.nl/v2/");
});

services.AddSnelStartClient(options =>
{
    options.SnelStartSubscriptionKey = "your-subscription-key";
});

public sealed class HttpContextSnelStartClientKeyProvider : ISnelStartClientKeyProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextSnelStartClientKeyProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public ValueTask<string?> GetClientKeyAsync(CancellationToken cancellationToken = default)
    {
        var clientKey = _httpContextAccessor.HttpContext?.User.FindFirst("snelstart_client_key")?.Value;
        return ValueTask.FromResult(clientKey);
    }
}
```

### Fallback: vaste client key via options

Als je applicatie altijd met één vaste client key werkt, kan `SnelStartClientOptions.ClientKey` nog steeds als fallback worden gebruikt.

```csharp
using Timestone.SnelStartClient.Configuration;
using Timestone.SnelStartClient.DependencyInjection;

services.AddHttpClient(SnelStartClientOptions.DefaultHttpClientName, client =>
{
    client.BaseAddress = new Uri("https://b2bapi.snelstart.nl/v2/");
});

services.AddSnelStartClient(options =>
{
    options.ClientKey = "your-fixed-client-key";
    options.SnelStartSubscriptionKey = "your-subscription-key";
});
```

## Gebruik

```csharp
using Timestone.SnelStartClient;
using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Queries;

public sealed class ArticleService
{
    private readonly ISnelStartClient _snelStartClient;

    public ArticleService(ISnelStartClient snelStartClient)
    {
        _snelStartClient = snelStartClient;
    }

    public Task<IReadOnlyList<ArticleQueryModel>> GetArticlesAsync(CancellationToken cancellationToken)
    {
        var query = new ArticleQueryOptions()
            .Where(x => !x.IsNonActief)
            .OrderBy(x => x.Artikelcode);

        query.Top = 25;

        return _snelStartClient.Articles.ListAsync(query, cancellationToken);
    }
}
```

## Relaties aanmaken en wijzigen

```csharp
using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Relations;

public sealed class RelationService
{
    private readonly ISnelStartClient _snelStartClient;

    public RelationService(ISnelStartClient snelStartClient)
    {
        _snelStartClient = snelStartClient;
    }

    public async Task<Guid?> CreateRelationAsync(CancellationToken cancellationToken)
    {
        var snelStartRelation = new RelationModel
        {
            Naam = "Voorbeeldrelatie B.V.",
            Relatiesoort = ["Klant"],
            Email = "info@voorbeeld.nl",
            Telefoon = "+31 10 123 45 67",
            VestigingsAdres = new AddressModel
            {
                Straat = "Coolsingel 1",
                Postcode = "3012 AA",
                Plaats = "Rotterdam"
            }
        };

        var createdRelation = await _snelStartClient.Relations.CreateAsync(snelStartRelation, cancellationToken);
        return createdRelation?.Id;
    }

    public async Task UpdateRelationAsync(RelationModel snelStartRelation, CancellationToken cancellationToken)
    {
        snelStartRelation.Email = "administratie@voorbeeld.nl";
        await _snelStartClient.Relations.UpdateAsync(snelStartRelation.Id!.Value, snelStartRelation, cancellationToken);
    }
}
```

## Kantoorinformatie ophalen

```csharp
var administratieNaam = (await snelStartClient.CompanyInfo.GetAsync(cancellationToken))?.AdministratieNaam;
```

Dit is bijvoorbeeld handig om de naam van de administratie of andere algemene bedrijfsinstellingen op te halen.

## Typed filters, sortering, selectie en paging

Voor OData-endpoints kan een queryobject worden meegegeven aan `ListAsync(...)`. Daarmee kunnen filters, sortering, paging en selecties typed worden opgebouwd.

```csharp
using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Queries;

public sealed class ArticleSearchService
{
    private readonly ISnelStartClient _snelStartClient;

    public ArticleSearchService(ISnelStartClient snelStartClient)
    {
        _snelStartClient = snelStartClient;
    }

    public Task<IReadOnlyList<ArticleQueryModel>> SearchAsync(Guid relationId, CancellationToken cancellationToken)
    {
        var query = new ArticleQueryOptions
        {
            RelationId = relationId,
            Amount = 10,
            Skip = 0,
            Top = 25
        }
        .Where(x => !x.IsNonActief && x.Omschrijving!.Contains("kabel"))
        .AndWhere(x => x.Relatie!.Id == relationId)
        .OrderBy(x => x.Omschrijving)
        .ThenByDescending(x => x.ModifiedOn)
        .SelectProperties(x => x.Id, x => x.Artikelcode, x => x.Omschrijving, x => x.ModifiedOn);

        return _snelStartClient.Articles.ListAsync(query, cancellationToken);
    }
}
```

Beschikbare helpers op `ODataQueryOptions<TModel>`:

- `Where(...)` voor een typed `$filter`
- `AndWhere(...)` en `OrWhere(...)` voor extra filterdelen
- `OrderBy(...)` en `OrderByDescending(...)`
- `ThenBy(...)` en `ThenByDescending(...)`
- `SelectProperties(...)` voor `$select`
- `Skip` en `Top` voor paging

Ondersteunde filterscenario's zijn onder meer:

- vergelijkingen zoals `==`, `!=`, `>`, `>=`, `<`, `<=`
- booleans zoals `x => !x.IsNonActief`
- stringfuncties zoals `Contains`, `StartsWith` en `EndsWith`
- geneste propertypaden zoals `x => x.Relatie!.Id == relationId`
- serialisatie van `Guid`, enums en datumwaarden naar OData-literals

## Directe OData-filter en handmatige paging

Als een endpoint extra OData-regels heeft, kan altijd direct de ruwe filterstring worden gezet via `Filter`, `Select`, `Top` en `Skip`.

Dat is bijvoorbeeld nuttig voor endpoints waar je bewust handmatig wilt pagineren of waar je een exacte OData-expressie wilt gebruiken.

```csharp
using Timestone.SnelStartClient.Models.Relations;
using Timestone.SnelStartClient.Queries;

private async Task<RelationModel[]> ApiGetAllClientsForInvoiceSyncFromSnelStart(CancellationToken cancellationToken)
{
    var select = "Id,Relatiecode,IncassoSoort,Naam";
    return await ApiGetAllClientsFromSnelStart(cancellationToken, select);
}

private async Task<RelationModel[]> ApiGetAllClientsFromSnelStart(
    CancellationToken cancellationToken,
    string? select = null,
    string? filter = "Relatiecode gt 0 and Relatiesoort/any(x: x eq 'Klant')")
{
    const int pageSize = 500;
    var skip = 0;

    var resultList = new List<RelationModel>();
    IReadOnlyCollection<RelationModel> result;

    do
    {
        var options = new RelationQueryOptions
        {
            Top = pageSize,
            Skip = skip,
            Select = select,
            Filter = filter
        };

        result = await snelStartClient.Relations.ListAsync(options, cancellationToken: cancellationToken);
        resultList.AddRange(result);
        skip += pageSize;
    }
    while (result.Count == pageSize);

    return [.. resultList];
}
```

## Enkel item ophalen

Voor endpoints met een `GetAsync(id, ...)` kan naast de identifier ook een queryobject worden meegegeven voor extra queryparameters.

```csharp
public Task<ArticleQueryModel?> GetArticleAsync(Guid articleId, Guid relationId, CancellationToken cancellationToken)
{
    var query = new ArticleQueryOptions
    {
        RelationId = relationId,
        Amount = 5
    };

    return _snelStartClient.Articles.GetAsync(articleId, query, cancellationToken);
}
```

## Foutafhandeling

Wanneer de SnelStart API een niet-succesvolle HTTP-response teruggeeft, gooit de client een `SnelStartApiException`.

```csharp
using Timestone.SnelStartClient.Transport;

private async Task<Guid?> ApiCreateSnelStartInvoice(SaleEntryModel saleEntryModel, CancellationToken cancellationToken)
{
    try
    {
        var result = await snelStartClient.SaleEntries.CreateAsync(saleEntryModel, cancellationToken);
        return result?.Id;
    }
    catch (SnelStartApiException ex)
    {
        logger.LogWarning(ex, "SnelStart gaf een fout terug: {ApiMessage}", ex.ApiMessage ?? ex.Message);
        throw new InvalidOperationException(ex.ApiMessage ?? ex.Message, ex);
    }
}
```

De exception probeert automatisch een nette foutmelding uit de responsebody te halen. Daarbij worden onder meer ondersteund:

- plain text response bodies
- JSON-objecten
- JSON-arrays
- `errorCode`
- `message`
- `description`
- `details`
- `modelState`-validatiefouten, afgevlakt naar `veld: foutmelding`

De volgende informatie zit in `SnelStartApiException`:

- `StatusCode`: de HTTP-statuscode
- `RequestUri`: de volledige request-URI
- `ResponseBody`: de ruwe responsebody
- `ApiMessage`: de geparste, best leesbare API-foutmelding
- `Message`: de uiteindelijke exception message, bijvoorbeeld:
  - `Status code 400 (BadRequest) in '/verkoopboekingen'. BOE-0021: Het factuurnummer bestaat al`

Veelvoorkomende fouten die je in de praktijk kunt verwachten zijn bijvoorbeeld:

- `400 BadRequest`: validatiefouten, ongeldige combinaties van velden of business rules vanuit SnelStart
- `401 Unauthorized`: ongeldige of ontbrekende authenticatie
- `403 Forbidden`: onvoldoende rechten voor de betreffende administratie of resource
- `404 NotFound`: de resource bestaat niet of is niet toegankelijk
- `409 Conflict`: conflict met bestaande data
- `429 TooManyRequests`: rate limiting of tijdelijke blokkering
- `500` en hoger: fouten aan SnelStart-zijde of tijdelijke storingen

Aanbevolen aanpak:

- vang gericht `SnelStartApiException`
- gebruik `ex.ApiMessage ?? ex.Message` voor logging of gebruikersfeedback
- bewaar `ex.ResponseBody` en `ex.RequestUri` voor technische logging en support
- wrap de exception alleen als je domeinspecifieke fouttypes wilt introduceren

## Belangrijk

- Registreer een named `HttpClient` met de naam uit `SnelStartClientOptions.DefaultHttpClientName`, of overschrijf die naam via `SnelStartClientOptions.SnelStartHttpClientName`.
- Gebruik bij voorkeur een eigen `ISnelStartClientKeyProvider` als de client key per aanvraag, tenant of klant kan verschillen.
- `SnelStartClientOptions.ClientKey` blijft beschikbaar als fallback voor scenario's met één vaste client key.
- De library verzorgt access-tokenverversing intern en cachet tokens per client key.
- De package target `net10.0`.
- Niet elk endpoint ondersteunt dezelfde queryopties. Controleer per repositorymethode en de SnelStart API-reference welke parameters op dat endpoint geldig zijn.
- OData `$expand` wordt niet ondersteund door de SnelStart API en moet daarom niet worden gebruikt of gedocumenteerd.

## Disclaimer

Deze gehele solution is gegenereerd met GitHub Copilot, inclusief de unit tests. Dit kan ertoe leiden dat de code onlogisch of incompleet is.
Timestone B.V. gebruikt in de praktijk op dit moment alleen de volgende onderdelen van de SnelStart API-client actief:

- Grootboekrekeningen
- Landen
- Relaties
- Verkoopboekingen
- Verkoopboekingbijlages

Deze onderdelen worden daarom actief gebruikt en indirect getest in echte scenario's. De overige repositories en modellen zijn wel opgenomen in de client, maar worden door Timestone B.V. op dit moment niet actief gebruikt of volledig getest.

Gebruik je andere delen van deze client en ontdek je fouten of onvolledigheden, dan nodigen we je nadrukkelijk uit om een pull request te maken.

---
# English version
---

# Timestone.SnelStartClient

`Timestone.SnelStartClient` is a .NET client for the SnelStart B2B API. The library provides a central `ISnelStartClient` with repositories for, among others, articles, relations, sales, purchases, bank entries, reports, and VAT.

In addition to simple requests, the library also supports typed OData query construction for endpoints that support filtering, sorting, paging, and selecting.

## Installation

```bash
dotnet add package TimestoneNL.SnelStartClient
```

## Registration via dependency injection

### Recommended: dynamic client key through a provider

For multi-tenant or customer-specific scenarios, register your own `ISnelStartClientKeyProvider`. The library asks this provider for a client key whenever a new token is needed and caches tokens per client key.

```csharp
using Timestone.SnelStartClient.Configuration;
using Timestone.SnelStartClient.DependencyInjection;

services.AddHttpContextAccessor();

services.AddSingleton<ISnelStartClientKeyProvider, HttpContextSnelStartClientKeyProvider>();

services.AddHttpClient(SnelStartClientOptions.DefaultHttpClientName, client =>
{
    client.BaseAddress = new Uri("https://b2bapi.snelstart.nl/v2/");
});

services.AddSnelStartClient(options =>
{
    options.SnelStartSubscriptionKey = "your-subscription-key";
});

public sealed class HttpContextSnelStartClientKeyProvider : ISnelStartClientKeyProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextSnelStartClientKeyProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public ValueTask<string?> GetClientKeyAsync(CancellationToken cancellationToken = default)
    {
        var clientKey = _httpContextAccessor.HttpContext?.User.FindFirst("snelstart_client_key")?.Value;
        return ValueTask.FromResult(clientKey);
    }
}
```

### Fallback: fixed client key through options

If your application always uses one fixed client key, `SnelStartClientOptions.ClientKey` can still be used as a fallback.

```csharp
using Timestone.SnelStartClient.Configuration;
using Timestone.SnelStartClient.DependencyInjection;

services.AddHttpClient(SnelStartClientOptions.DefaultHttpClientName, client =>
{
    client.BaseAddress = new Uri("https://b2bapi.snelstart.nl/v2/");
});

services.AddSnelStartClient(options =>
{
    options.ClientKey = "your-fixed-client-key";
    options.SnelStartSubscriptionKey = "your-subscription-key";
});
```

## Usage

```csharp
using Timestone.SnelStartClient;
using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Queries;

public sealed class ArticleService
{
    private readonly ISnelStartClient _snelStartClient;

    public ArticleService(ISnelStartClient snelStartClient)
    {
        _snelStartClient = snelStartClient;
    }

    public Task<IReadOnlyList<ArticleQueryModel>> GetArticlesAsync(CancellationToken cancellationToken)
    {
        var query = new ArticleQueryOptions()
            .Where(x => !x.IsNonActief)
            .OrderBy(x => x.Artikelcode);

        query.Top = 25;

        return _snelStartClient.Articles.ListAsync(query, cancellationToken);
    }
}
```

## Creating and updating relations

```csharp
using Timestone.SnelStartClient.Models.Common;
using Timestone.SnelStartClient.Models.Relations;

public sealed class RelationService
{
    private readonly ISnelStartClient _snelStartClient;

    public RelationService(ISnelStartClient snelStartClient)
    {
        _snelStartClient = snelStartClient;
    }

    public async Task<Guid?> CreateRelationAsync(CancellationToken cancellationToken)
    {
        var snelStartRelation = new RelationModel
        {
            Naam = "Example relation Ltd.",
            Relatiesoort = ["Klant"],
            Email = "info@example.com",
            Telefoon = "+31 10 123 45 67",
            VestigingsAdres = new AddressModel
            {
                Straat = "Coolsingel 1",
                Postcode = "3012 AA",
                Plaats = "Rotterdam"
            }
        };

        var createdRelation = await _snelStartClient.Relations.CreateAsync(snelStartRelation, cancellationToken);
        return createdRelation?.Id;
    }

    public async Task UpdateRelationAsync(RelationModel snelStartRelation, CancellationToken cancellationToken)
    {
        snelStartRelation.Email = "administration@example.com";
        await _snelStartClient.Relations.UpdateAsync(snelStartRelation.Id!.Value, snelStartRelation, cancellationToken);
    }
}
```

## Retrieving company information

```csharp
var administrationName = (await snelStartClient.CompanyInfo.GetAsync(cancellationToken))?.AdministratieNaam;
```

This is useful, for example, when retrieving the administration name or other general company settings.

## Typed filters, sorting, selecting, and paging

For OData endpoints, a query object can be passed to `ListAsync(...)`. This allows filters, sorting, paging, and selections to be constructed in a typed manner.

```csharp
using Timestone.SnelStartClient.Models.Catalog;
using Timestone.SnelStartClient.Queries;

public sealed class ArticleSearchService
{
    private readonly ISnelStartClient _snelStartClient;

    public ArticleSearchService(ISnelStartClient snelStartClient)
    {
        _snelStartClient = snelStartClient;
    }

    public Task<IReadOnlyList<ArticleQueryModel>> SearchAsync(Guid relationId, CancellationToken cancellationToken)
    {
        var query = new ArticleQueryOptions
        {
            RelationId = relationId,
            Amount = 10,
            Skip = 0,
            Top = 25
        }
        .Where(x => !x.IsNonActief && x.Omschrijving!.Contains("kabel"))
        .AndWhere(x => x.Relatie!.Id == relationId)
        .OrderBy(x => x.Omschrijving)
        .ThenByDescending(x => x.ModifiedOn)
        .SelectProperties(x => x.Id, x => x.Artikelcode, x => x.Omschrijving, x => x.ModifiedOn);

        return _snelStartClient.Articles.ListAsync(query, cancellationToken);
    }
}
```

Available helpers on `ODataQueryOptions<TModel>`:

- `Where(...)` for a typed `$filter`
- `AndWhere(...)` and `OrWhere(...)` for additional filter parts
- `OrderBy(...)` and `OrderByDescending(...)`
- `ThenBy(...)` and `ThenByDescending(...)`
- `SelectProperties(...)` for `$select`
- `Skip` and `Top` for paging

Supported filter scenarios include:

- comparisons such as `==`, `!=`, `>`, `>=`, `<`, `<=`
- booleans such as `x => !x.IsNonActief`
- string functions such as `Contains`, `StartsWith`, and `EndsWith`
- nested property paths such as `x => x.Relatie!.Id == relationId`
- serialization of `Guid`, enums, and date values to OData literals

## Using a direct OData filter and manual paging

If an endpoint has additional OData requirements, the raw filter string can always be set through `Filter`, `Select`, `Top`, and `Skip`.

This is useful, for example, when you deliberately want to page manually or when you need an exact OData expression.

```csharp
using Timestone.SnelStartClient.Models.Relations;
using Timestone.SnelStartClient.Queries;

private async Task<RelationModel[]> ApiGetAllClientsForInvoiceSyncFromSnelStart(CancellationToken cancellationToken)
{
    var select = "Id,Relatiecode,IncassoSoort,Naam";
    return await ApiGetAllClientsFromSnelStart(cancellationToken, select);
}

private async Task<RelationModel[]> ApiGetAllClientsFromSnelStart(
    CancellationToken cancellationToken,
    string? select = null,
    string? filter = "Relatiecode gt 0 and Relatiesoort/any(x: x eq 'Klant')")
{
    const int pageSize = 500;
    var skip = 0;

    var resultList = new List<RelationModel>();
    IReadOnlyCollection<RelationModel> result;

    do
    {
        var options = new RelationQueryOptions
        {
            Top = pageSize,
            Skip = skip,
            Select = select,
            Filter = filter
        };

        result = await snelStartClient.Relations.ListAsync(options, cancellationToken: cancellationToken);
        resultList.AddRange(result);
        skip += pageSize;
    }
    while (result.Count == pageSize);

    return [.. resultList];
}
```

## Retrieving a single item

For endpoints with a `GetAsync(id, ...)`, a query object can also be passed alongside the identifier for additional query parameters.

```csharp
public Task<ArticleQueryModel?> GetArticleAsync(Guid articleId, Guid relationId, CancellationToken cancellationToken)
{
    var query = new ArticleQueryOptions
    {
        RelationId = relationId,
        Amount = 5
    };

    return _snelStartClient.Articles.GetAsync(articleId, query, cancellationToken);
}
```

## Error handling

When the SnelStart API returns a non-successful HTTP response, the client throws a `SnelStartApiException`.

```csharp
using Timestone.SnelStartClient.Transport;

private async Task<Guid?> ApiCreateSnelStartInvoice(SaleEntryModel saleEntryModel, CancellationToken cancellationToken)
{
    try
    {
        var result = await snelStartClient.SaleEntries.CreateAsync(saleEntryModel, cancellationToken);
        return result?.Id;
    }
    catch (SnelStartApiException ex)
    {
        logger.LogWarning(ex, "SnelStart returned an error: {ApiMessage}", ex.ApiMessage ?? ex.Message);
        throw new InvalidOperationException(ex.ApiMessage ?? ex.Message, ex);
    }
}
```

The exception automatically tries to extract a readable error message from the response body. Among other things, it supports:

- plain text response bodies
- JSON objects
- JSON arrays
- `errorCode`
- `message`
- `description`
- `details`
- `modelState` validation errors, flattened to `field: error message`

The following information is available on `SnelStartApiException`:

- `StatusCode`: the HTTP status code
- `RequestUri`: the full request URI
- `ResponseBody`: the raw response body
- `ApiMessage`: the parsed, most readable API error message
- `Message`: the final exception message, for example:
  - `Status code 400 (BadRequest) in '/verkoopboekingen'. BOE-0021: Het factuurnummer bestaat al`

Common errors you can expect in practice include:

- `400 BadRequest`: validation errors, invalid field combinations, or SnelStart business rules
- `401 Unauthorized`: invalid or missing authentication
- `403 Forbidden`: insufficient permissions for the administration or resource
- `404 NotFound`: the resource does not exist or is not accessible
- `409 Conflict`: conflict with existing data
- `429 TooManyRequests`: rate limiting or temporary blocking
- `500` and higher: server-side SnelStart errors or temporary outages

Recommended approach:

- catch `SnelStartApiException` explicitly
- use `ex.ApiMessage ?? ex.Message` for logging or user-facing feedback
- keep `ex.ResponseBody` and `ex.RequestUri` for technical logging and support purposes
- only wrap the exception when you want to introduce domain-specific error types

## Important

- Register a named `HttpClient` using the name from `SnelStartClientOptions.DefaultHttpClientName`, or override it via `SnelStartClientOptions.SnelStartHttpClientName`.
- Prefer a custom `ISnelStartClientKeyProvider` when the client key can vary per request, tenant, or customer.
- `SnelStartClientOptions.ClientKey` remains available as a fallback for single-client-key scenarios.
- The library handles access token refreshing internally and caches tokens per client key.
- The package targets `net10.0`.
- Not every endpoint supports the same query options. Check the repository method and the SnelStart API reference to see which parameters are valid for each endpoint.
- OData `$expand` is not supported by the SnelStart API and must therefore not be used or documented.

## Disclaimer

The entire solution is generated with GitHub Copilot, including the unit tests. This can cause the code to be illogical or incomplete. 
Timestone B.V. currently only actively uses the following parts of the SnelStart API client in practice:

- Ledgers
- Countries
- Relations
- SaleEntries
- Documents

These parts are therefore actively used and indirectly tested in real-world scenarios. The remaining repositories and models are included in the client, but are currently not actively used or fully tested by Timestone B.V.

If you use other parts of this client and discover bugs or incomplete behavior, we explicitly invite you to open a pull request.
