/**
 * NetworkStatusFixtures.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using System.Collections.Generic;
using Windows.Networking.Connectivity;


namespace KanoComputing.Tests.Fixtures.Network {

    public class NetworkStatusFixtures {

        public static IEnumerable<object[]> NetworkConnectivityLevels() {
            yield return new object[] { NetworkConnectivityLevel.None };
            yield return new object[] { NetworkConnectivityLevel.LocalAccess };
            yield return new object[] { NetworkConnectivityLevel.ConstrainedInternetAccess };
            yield return new object[] { NetworkConnectivityLevel.InternetAccess };
        }
    }
}
