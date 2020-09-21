/**
 * NetworkStatus.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using KanoComputing.Wrappers;
using Windows.Networking.Connectivity;


namespace KanoComputing.Network {

    public class NetworkStatus : INetworkStatus {

        private readonly IKNetworkInformation networkInformation;

        public NetworkStatus(IKNetworkInformation networkInformation = null) {
            this.networkInformation = networkInformation ?? new KNetworkInformation();
        }

        public bool IsInternetAvailable() {
            IKConnectionProfile profile = this.networkInformation.GetInternetConnectionProfile();
            return
                profile != null &&
                profile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
        }
    }
}
