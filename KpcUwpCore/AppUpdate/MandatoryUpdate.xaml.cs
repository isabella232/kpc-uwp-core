/**
 * MandatoryUpdate.xaml.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using System;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace KanoComputing.AppUpdate {

    /// <summary>
    /// This page informs users that the app requires a mandatory update
    /// </summary>
    public sealed partial class MandatoryUpdate : Page {

        public MandatoryUpdate() {
            this.InitializeComponent();
        }

        private async void OnUpdateButtonClick(object sender, RoutedEventArgs e) {
            // Launch the Microsoft Store to the Downloads and Updates page.
            await Launcher.LaunchUriAsync(
                new Uri("ms-windows-store://downloadsandupdates")
            );
        }
    }
}
