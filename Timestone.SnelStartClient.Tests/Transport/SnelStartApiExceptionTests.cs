using System.Net;
using Timestone.SnelStartClient.Transport;

namespace Timestone.SnelStartClient.Tests.Transport;

public sealed class SnelStartApiExceptionTests
{
    [Fact]
    public void Constructor_WhenCalled_SetsAllPropertiesAndBuildsReadableMessage()
    {
        var requestUri = new Uri("https://api.example.test/artikelen");

        var exception = new SnelStartApiException(HttpStatusCode.BadRequest, requestUri, "ongeldige aanvraag");

        Assert.Equal(HttpStatusCode.BadRequest, exception.StatusCode);
        Assert.Equal(requestUri, exception.RequestUri);
        Assert.Equal("ongeldige aanvraag", exception.ResponseBody);
        Assert.Equal("ongeldige aanvraag", exception.ApiMessage);
        Assert.Equal("Status code 400 (BadRequest) in '/artikelen'. ongeldige aanvraag", exception.Message);
    }

    [Fact]
    public void Constructor_WhenJsonResponseContainsApiMessage_ExtractsReadableMessageFromResponseBody()
    {
        var requestUri = new Uri("https://api.example.test/verkoopboekingen");
        const string responseBody = "[{\"errorCode\":\"BOE-0021\",\"message\":\"Het factuurnummer bestaat al\",\"details\":null}]";

        var exception = new SnelStartApiException(HttpStatusCode.BadRequest, requestUri, responseBody);

        Assert.Equal("BOE-0021: Het factuurnummer bestaat al", exception.ApiMessage);
        Assert.Equal("Status code 400 (BadRequest) in '/verkoopboekingen'. BOE-0021: Het factuurnummer bestaat al", exception.Message);
    }

    [Fact]
    public void Constructor_WhenJsonResponseContainsDetailsAndModelState_IncludesThemInApiMessage()
    {
        var requestUri = new Uri("https://api.example.test/verkoopboekingen");
        const string responseBody = "[{\"message\":\"Validatie mislukt\",\"details\":\"Controleer de invoer\",\"modelState\":{\"relatie.Naam\":[\"The field Naam is required.\"],\"bedrag\":[\"The field bedrag must be greater than 0.\"]}}]";

        var exception = new SnelStartApiException(HttpStatusCode.BadRequest, requestUri, responseBody);

        Assert.Equal("Validatie mislukt | Controleer de invoer | relatie.Naam: The field Naam is required. | bedrag: The field bedrag must be greater than 0.", exception.ApiMessage);
        Assert.Equal("Status code 400 (BadRequest) in '/verkoopboekingen'. Validatie mislukt | Controleer de invoer | relatie.Naam: The field Naam is required. | bedrag: The field bedrag must be greater than 0.", exception.Message);
    }
}
