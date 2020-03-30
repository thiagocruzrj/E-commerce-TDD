using Microsoft.AspNetCore.Mvc.Testing;
using ShopDemo.WebApp.MVC;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace ShopDemo.WebApp.Tests.Config
{
    [CollectionDefinition(nameof(IntegrationWebTestsFixtureCollection))]
    public class IntegrationWebTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupWebTests>> { }

    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupApiTests>> { }

    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly ShopAppFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTestsFixture(ShopAppFactory<TStartup> factory, HttpClient client)
        {
            var clientOptions = new WebApplicationFactoryClientOptions { };

            Factory = new ShopAppFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }

        public void Dispose() { Client.Dispose(); Factory.Dispose(); }
    }
}
