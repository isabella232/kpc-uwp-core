/**
 * TestNetworkStatus.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using KanoComputing.Network;
using KanoComputing.Tests.Fixtures.Network;
using KanoComputing.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Windows.Networking.Connectivity;


namespace KanoComputing.Tests.Unit.Network {

    [TestClass]
    public class TestNetworkStatus {

        [DataTestMethod]
        [DynamicData(nameof(NetworkStatusFixtures.NetworkConnectivityLevels),
                     typeof(NetworkStatusFixtures), DynamicDataSourceType.Method)]
        public void TestIsInternetAvailable(NetworkConnectivityLevel networkConnectivity) {
            // Setup any objects and mocks.
            var mockConnectionProfile = new Mock<IKConnectionProfile>();
            var mockNetworkInformation = new Mock<IKNetworkInformation>();
            NetworkStatus networkStatus = new NetworkStatus(mockNetworkInformation.Object);

            mockConnectionProfile
                .Setup(obj => obj.GetNetworkConnectivityLevel())
                .Returns(networkConnectivity);
            mockNetworkInformation
                .Setup(obj => obj.GetInternetConnectionProfile())
                .Returns(mockConnectionProfile.Object);

            // Call the method under test.
            bool available = networkStatus.IsInternetAvailable();
            bool expected = networkConnectivity == NetworkConnectivityLevel.InternetAccess;

            // Verify the results produced.
            Assert.AreEqual(
                expected, available,
                "Function is not reporting the correct status");
        }
    }
}
