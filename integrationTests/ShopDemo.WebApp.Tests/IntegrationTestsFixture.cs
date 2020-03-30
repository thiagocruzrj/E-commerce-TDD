using ShopDemo.WebApp.MVC;
using ShopDemo.WebApp.Tests.Config;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace ShopDemo.WebApp.Tests
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
            Factory = new ShopAppFactory<TStartup>();
            Client = Factory.CreateClient();
        }

        public void Dispose() { }
    }
}
