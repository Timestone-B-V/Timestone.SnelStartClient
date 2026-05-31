using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Timestone.SnelStartClient.Configuration;
using Timestone.SnelStartClient.DependencyInjection;
using Timestone.SnelStartClient.Repositories.Catalog;
using Timestone.SnelStartClient.Repositories.Vat;
using Timestone.SnelStartClient.Tests.TestDoubles;

namespace Timestone.SnelStartClient.Tests.DependencyInjection;

public sealed class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddSnelStartClient_WhenCalled_RegistersClientAndRepositories()
    {
        var services = new ServiceCollection();
        services.AddHttpClient(SnelStartClientOptions.DefaultHttpClientName, client =>
        {
            client.BaseAddress = new Uri("https://api.example.test/");
        });

        services.AddSnelStartClient(options =>
        {
            options.ClientKey = "client-key";
            options.SnelStartSubscriptionKey = "subscription-key";
        });

        using var serviceProvider = services.BuildServiceProvider();

        Assert.NotNull(serviceProvider.GetRequiredService<ISnelStartClient>());
        Assert.NotNull(serviceProvider.GetRequiredService<IArticlesRepository>());
        Assert.NotNull(serviceProvider.GetRequiredService<IPriceAgreementsRepository>());
        Assert.NotNull(serviceProvider.GetRequiredService<IVatRatesRepository>());
    }

    [Fact]
    public void AddSnelStartClient_WhenConfigured_StoresConfiguredOptions()
    {
        var services = new ServiceCollection();
        services.AddHttpClient(SnelStartClientOptions.DefaultHttpClientName, client =>
        {
            client.BaseAddress = new Uri("https://api.example.test/");
        });

        services.AddSnelStartClient(options =>
        {
            options.BaseUrl = "https://configured.example.test/v2/";
            options.ClientKey = "client-key";
            options.SnelStartSubscriptionKey = "subscription-key";
            options.TokenExpirationBufferSeconds = 120;
        });

        using var serviceProvider = services.BuildServiceProvider();
        var options = serviceProvider.GetRequiredService<IOptions<SnelStartClientOptions>>().Value;

        Assert.Equal("https://configured.example.test/v2/", options.BaseUrl);
        Assert.Equal("client-key", options.ClientKey);
        Assert.Equal("subscription-key", options.SnelStartSubscriptionKey);
        Assert.Equal(120, options.TokenExpirationBufferSeconds);
    }

    [Fact]
    public async Task AddSnelStartClient_WhenNoCustomClientKeyProviderIsRegistered_UsesOptionsClientKeyProvider()
    {
        var services = new ServiceCollection();
        services.AddHttpClient(SnelStartClientOptions.DefaultHttpClientName, client =>
        {
            client.BaseAddress = new Uri("https://api.example.test/");
        });

        services.AddSnelStartClient(options =>
        {
            options.ClientKey = "client-key-from-options";
        });

        using var serviceProvider = services.BuildServiceProvider();
        var clientKeyProvider = serviceProvider.GetRequiredService<ISnelStartClientKeyProvider>();

        var clientKey = await clientKeyProvider.GetClientKeyAsync();

        Assert.IsType<OptionsSnelStartClientKeyProvider>(clientKeyProvider);
        Assert.Equal("client-key-from-options", clientKey);
    }

    [Fact]
    public async Task AddSnelStartClient_WhenCustomClientKeyProviderIsRegistered_KeepsCustomRegistration()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ISnelStartClientKeyProvider>(new TestSnelStartClientKeyProvider("client-key-from-custom-provider"));
        services.AddHttpClient(SnelStartClientOptions.DefaultHttpClientName, client =>
        {
            client.BaseAddress = new Uri("https://api.example.test/");
        });

        services.AddSnelStartClient(_ =>
        {
        });

        using var serviceProvider = services.BuildServiceProvider();
        var clientKeyProvider = serviceProvider.GetRequiredService<ISnelStartClientKeyProvider>();

        var clientKey = await clientKeyProvider.GetClientKeyAsync();

        Assert.IsNotType<OptionsSnelStartClientKeyProvider>(clientKeyProvider);
        Assert.Equal("client-key-from-custom-provider", clientKey);
    }
}
