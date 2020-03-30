using ShopDemo.WebApp.MVC;
using ShopDemo.WebApp.Tests.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopDemo.WebApp.Tests
{
    public class UserTests
    {
        private readonly IntegrationTestsFixture<StartupWebTests> _testsFixture;

        public UserTests(IntegrationTestsFixture<StartupWebTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }
    }
}
