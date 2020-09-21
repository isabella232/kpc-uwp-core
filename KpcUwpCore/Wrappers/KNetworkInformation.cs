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
            return new KConnectionProfile(NetworkInformation.GetInternetConnectionProfile());
        }
    }
}
