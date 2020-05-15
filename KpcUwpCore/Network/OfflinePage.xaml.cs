/**
 * OfflinePage.xaml.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using System;
using System.Diagnostics;
using Windows.Networking.Connectivity;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace KanoComputing.Network {

    /// <summary>
    /// This page informs users that the app requires an Internet connection
    /// in order to continue and directs them to the Windows Settings app at
    /// the Network page. Once a valid connection is established this page will
    /// navigate back to the page where it was shown from.
    /// </summary>
    public sealed partial class OfflinePage : Page {

        public OfflinePage() {
            this.InitializeComponent();

            NetworkInformation.NetworkStatusChanged +=
                new NetworkStatusChangedEventHandler(this.OnNetworkStatusChanged);
        }

        private void OnNetworkStatusChanged(object sender) {
            ConnectionProfile profile = NetworkInformation.GetInternetConnectionProfile();
            if (profile != null) {
                this.GoBack();
            }
        }

        private void OnRefreshButtonClick(object sender, RoutedEventArgs args) {
            this.GoBack();
        }

        private void GoBack() {
            if (this.Frame.CanGoBack) {
                this.Frame.GoBack();
            } else {
                Debug.WriteLine("OfflinePage: GoBack: Cannot go back to the previous page");
            }
        }

        private async void OnCheckConnectionButtonClick(object sender, RoutedEventArgs args) {
            await Launcher.LaunchUriAsync(new Uri("ms-settings:network"));
        }
    }
}
