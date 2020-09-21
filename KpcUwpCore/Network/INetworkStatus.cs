/**
 * INetworkStatus.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


namespace KanoComputing.Network {

    public interface INetworkStatus {

        bool IsInternetAvailable();
    }
}
