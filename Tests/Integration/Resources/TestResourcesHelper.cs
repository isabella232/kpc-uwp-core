/**
 * TestResourcesHelper.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using Castle.Core.Internal;
using KanoComputing.Assets;
using KanoComputing.Resources;
using KanoComputing.Tests.Fixtures.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.ApplicationModel.Resources;


namespace KanoComputing.Tests.Integration.Resources {

    [TestClass]
    public class TestResourcesHelper {

        [DataTestMethod]
        [DynamicData(nameof(ResourcesFixtures.AllStringKeys),
                     typeof(ResourcesFixtures), DynamicDataSourceType.Method)]
        public void TestGetResourceLoader(string key) {
            ResourceLoader resources = new ResourcesHelper().GetResourceLoader(ResourceMapIds.Strings);

            Assert.IsFalse(
                resources.GetString(key).IsNullOrEmpty(),
                $"Could not retrieve the string with key '{key}'");
        }
    }
}
