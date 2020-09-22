/**
 * KConnectionProfile.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using System;
using Windows.Networking.Connectivity;


namespace KanoComputing.Wrappers {

    public class KConnectionProfile : IKConnectionProfile {

        private readonly ConnectionProfile profile;

        public KConnectionProfile(ConnectionProfile profile) {
            this.profile = profile ?? throw new ArgumentNullException(
                "The KConnectionProfile wrapper class cannot work without " +
                "a valid instance of the object");
        }

        public NetworkConnectivityLevel GetNetworkConnectivityLevel() {
            return this.profile.GetNetworkConnectivityLevel();
        }
    }
}
