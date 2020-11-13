/**
 * TestStringsLocalisation.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using Castle.Core.Internal;
using KanoComputing.Tests.Fixtures.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace KanoComputing.Tests.Integration.Resources {

    /// <summary>
    /// Ensure that all strings have been separated in resource files,
    /// configured correctly, and accessible via relevant APIs.
    /// Encompasses all tests relevant to the string Localisation phase
    /// of the project.
    /// </summary>
    [TestClass]
    public class TestStringsLocalisation {

        /// <summary>
        /// Test that strings separated in resources files are accessible
        /// to ResourceLoaders.
        /// </summary>
        [TestMethod]
        public void TestStringResources() {
            // Fetching all strings is analogous to the fixture providing
            // the data so reuse the call.
            var strings = ResourcesFixtures.AllStringKeys();

            Assert.IsFalse(
                strings.IsNullOrEmpty(),
                "No strings were found in resource files");
        }
    }
}
