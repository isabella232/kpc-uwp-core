/**
 * KNetworkInformation.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using Windows.Networking.Connectivity;


namespace KanoComputing.Wrappers {

    public class KNetworkInformation : IKNetworkInformation {
        
        public IKConnectionProfile GetInternetConnectionProfile() {
            ConnectionProfile profile = NetworkInformation.GetInternetConnectionProfile();
            return profile == null ? null : new KConnectionProfile(profile);
        }
    }
}
