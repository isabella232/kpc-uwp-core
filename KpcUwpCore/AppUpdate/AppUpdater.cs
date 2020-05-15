/**
 * AppUpdater.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Services.Store;
using Windows.Storage;


namespace KanoComputing.AppUpdate {

    public class AppUpdater : IAppUpdater {

        private readonly StoreContext StoreContext = null;
        private readonly ApplicationDataContainer LocalSettings = null;

        public AppUpdater() {
            this.StoreContext = StoreContext.GetDefault();
            this.LocalSettings = ApplicationData.Current.LocalSettings;
        }

        /// <summary>
        /// Check the Microsoft Store if there are update available for the app.
        /// </summary>
        public async Task<bool> IsUpdateAvailableAsync() {
            // Get the list of packages for the current app for which there
            // are updates available.
            IReadOnlyList<StorePackageUpdate> updatablePackages =
                await this.StoreContext.GetAppAndOptionalStorePackageUpdatesAsync();

            bool result = (updatablePackages.Count > 0);
            Debug.WriteLine("IsUpdateAvailableAsync: " + result);
            return result;
        }

        /// <summary>
        /// Check the Microsoft Store if there are mandatory updates available
        /// for the app and optionally set a feature flag in local settings.
        /// </summary>
        /// <param name="setFlag">(optional) Whether or not to set the feature flag.</param>
        public async Task<bool> IsMandatoryUpdateAvailableAsync(bool setFlag = true) {
            // Get the list of packages for the current app for which there
            // are updates available.
            IReadOnlyList<StorePackageUpdate> updatablePackages =
                await this.StoreContext.GetAppAndOptionalStorePackageUpdatesAsync();

            bool result = (
                updatablePackages.Count > 0 &&
                updatablePackages.Any(u => u.Mandatory)
            );
            Debug.WriteLine("IsMandatoryUpdateAvailableAsync: " + result);

            // Set the mandatory updates feature flag.
            if (setFlag) {
                this.SetMandatoryUpdateAvailableFlag(result);
            }
            return result;
        }

        private void SetMandatoryUpdateAvailableFlag(bool value) {
            this.LocalSettings.Values["MANDATORY_UPDATES_AVAILABLE"] = value ? "1" : "0";
        }

        /// <summary>
        /// Check if the mandatory updates flag was set in local settings.
        /// </summary>
        public bool IsMandatoryUpdateAvailableFlagSet() {
            bool result = (
                this.LocalSettings.Values.ContainsKey("MANDATORY_UPDATES_AVAILABLE") &&
                this.LocalSettings.Values["MANDATORY_UPDATES_AVAILABLE"].ToString() == "1"
            );
            Debug.WriteLine("IsMandatoryUpdateAvailableFlagSet: " + result);
            return result;
        }
    }
}
