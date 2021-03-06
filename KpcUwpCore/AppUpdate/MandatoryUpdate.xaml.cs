﻿/**
 * MandatoryUpdate.xaml.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using KanoComputing.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Services.Store;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace KanoComputing.AppUpdate {

    /// <summary>
    /// This page informs users that the app requires a mandatory update and
    /// allows them to download and install it. The process starts as soon as
    /// the page is loaded when automatic updates are enabled in the Store.
    /// </summary>
    public sealed partial class MandatoryUpdate : Page {

        private readonly INetworkStatus network = new NetworkStatus();

        public MandatoryUpdate() {
            this.InitializeComponent();
            this.Loaded += this.OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs args) {
            if (!this.network.IsInternetAvailable()) {
                this.Frame.Navigate(typeof(OfflinePage));
                return;
            }

            StoreContext storeContext = StoreContext.GetDefault();

            // If automatic updates are enabled in Microsoft Store > Settings then
            // start the process immediately. Otherwise, allow the user to start it.
            if (storeContext.CanSilentlyDownloadStorePackageUpdates) {
                await this.DoUpdateAsync();
            } else {
                VisualStateManager.GoToState(this, this.UpdateAvailableState.Name, false);
            }
        }

        private async void OnUpdateButtonClick(object sender, RoutedEventArgs args) {
            await this.DoUpdateAsync();
        }

        private async void OnStoreButtonClick(object sender, RoutedEventArgs args) {
            // Launch the Microsoft Store to the Downloads and Updates page.
            await Launcher.LaunchUriAsync(
                new Uri("ms-windows-store://downloadsandupdates")
            );
        }

        private void OnLaterButtonClick(object sender, RoutedEventArgs e) {
            CoreApplication.Exit();
        }

        /// <summary>
        /// Start the update process and change the UI accordingly.
        /// </summary>
        private async Task DoUpdateAsync() {
            VisualStateManager.GoToState(this, this.UpdateInstallingState.Name, false);

            try {
                StoreContext context = StoreContext.GetDefault();

                await this.CancelQueuedUpdatesAsync(context);

                IReadOnlyList<StorePackageUpdate> updates =
                    await context.GetAppAndOptionalStorePackageUpdatesAsync();

                StorePackageUpdateResult download =
                    await this.DownloadAllUpdatesAsync(context, updates);
                Debug.WriteLine($"{this.GetType()}: DoUpdateAsync: " +
                    $"Download result {download.OverallState}");

                // Only abort the process if the user explicitly cancelled. If there were
                // failures, the next step *should* handle it.
                if (download.OverallState == StorePackageUpdateState.Canceled) {
                    VisualStateManager.GoToState(this, this.UpdateAvailableState.Name, false);
                    return;
                }

                StorePackageUpdateResult result =
                    await this.InstallAllUpdatesAsync(context, updates);

                await this.HandleUpdateResultAsync(updates, result);

                // If anything fails, go straight to the Failed state.
            } catch (Exception e) {
                Debug.WriteLine($"{this.GetType()}: DoUpdateAsync: Caught {e}");
                VisualStateManager.GoToState(this, this.UpdateFailedState.Name, false);
            }
        }

        private async Task CancelQueuedUpdatesAsync(StoreContext storeContext) {
            IReadOnlyList<StoreQueueItem> queuedUpdates =
                await storeContext.GetAssociatedStoreQueueItemsAsync();

            foreach (var update in queuedUpdates) {
                Debug.WriteLine($"{this.GetType()}: CancelQueuedUpdatesAsync: " +
                    $"Canceling {update.PackageFamilyName}");
                await update.CancelInstallAsync();
            }
        }

        /// <summary>
        /// Downloads all package updates.
        /// </summary>
        private async Task<StorePackageUpdateResult> DownloadAllUpdatesAsync(
                StoreContext storeContext,
                IReadOnlyList<StorePackageUpdate> updates) {

            if (updates.Count <= 0) {
                Debug.WriteLine($"{this.GetType()}: DownloadAllUpdatesAsync: No updates available");
                return null;
            }
            foreach (var update in updates) {
                Debug.WriteLine($"{this.GetType()}: DownloadAllUpdatesAsync: Update for " +
                    $"{update.Package.Id.FamilyName} to version {update.Package.Id.Version.Major}." +
                    $"{update.Package.Id.Version.Minor}.{update.Package.Id.Version.Build}." +
                    $"{update.Package.Id.Version.Revision} available");
            }

            // Download and install the updates and attempt to avoid
            // asking the user for further confirmation.
            IAsyncOperationWithProgress<StorePackageUpdateResult, StorePackageUpdateStatus> downloadOperation;
            downloadOperation = storeContext.CanSilentlyDownloadStorePackageUpdates ?
                storeContext.TrySilentDownloadStorePackageUpdatesAsync(updates) :
                storeContext.RequestDownloadStorePackageUpdatesAsync(updates);

            // The Progress async method is called one time for each step in the download
            // and installation process for each package in this request.
            downloadOperation.Progress = async (asyncInfo, progress) => {
                await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () => {
                    Debug.WriteLine($"{this.GetType()}: DownloadAllUpdatesAsync: Updating " +
                        $"{progress.PackageFamilyName}, progress {progress.PackageDownloadProgress}");
                    this.ProgressBar.Value = progress.PackageDownloadProgress * 0.5;
                });
            };

            return await downloadOperation.AsTask();
        }

        /// <summary>
        /// Downloads and installs package updates.
        /// </summary>
        private async Task<StorePackageUpdateResult> InstallAllUpdatesAsync(
                StoreContext storeContext,
                IReadOnlyList<StorePackageUpdate> updates) {

            if (updates.Count <= 0) {
                Debug.WriteLine($"{this.GetType()}: InstallAllUpdatesAsync: No updates available");
                return null;
            }
            foreach (var update in updates) {
                Debug.WriteLine($"{this.GetType()}: InstallAllUpdatesAsync: Update for " +
                    $"{update.Package.Id.FamilyName} to version {update.Package.Id.Version.Major}." +
                    $"{update.Package.Id.Version.Minor}.{update.Package.Id.Version.Build}." +
                    $"{update.Package.Id.Version.Revision} available");
            }

            // Download and install the updates and attempt to avoid
            // asking the user for further confirmation.
            IAsyncOperationWithProgress<StorePackageUpdateResult, StorePackageUpdateStatus> updateOperation;
            updateOperation = storeContext.CanSilentlyDownloadStorePackageUpdates ?
                storeContext.TrySilentDownloadAndInstallStorePackageUpdatesAsync(updates) :
                storeContext.RequestDownloadAndInstallStorePackageUpdatesAsync(updates);

            // The Progress async method is called one time for each step in the download
            // and installation process for each package in this request.
            updateOperation.Progress = async (asyncInfo, progress) => {
                await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () => {
                    Debug.WriteLine($"{this.GetType()}: InstallAllUpdatesAsync: Updating " +
                        $"{progress.PackageFamilyName}, progress {progress.PackageDownloadProgress}");
                    this.ProgressBar.Value = 0.5 + progress.PackageDownloadProgress * 0.5;
                });
            };

            return await updateOperation.AsTask();
        }

        /// <summary>
        /// Handle the result of the update process and update the UI accordingly.
        /// </summary>
        private async Task HandleUpdateResultAsync(
                IReadOnlyList<StorePackageUpdate> updates, StorePackageUpdateResult result) {

            if (result == null) {
                VisualStateManager.GoToState(this, this.UpdateFailedState.Name, false);
                Debug.WriteLine($"{this.GetType()}: HandleUpdateResultAsync: result was null");
                return;
            }

            switch (result.OverallState) {
                // When the app has updated successfully, attempt to restart it,
                // or show a notification to user and exit.
                case StorePackageUpdateState.Completed: {
                    Debug.WriteLine($"{this.GetType()}: HandleUpdateResultAsync: Update successful");
                    if (!await this.RestartAppAsync()) {
                        // We expect the Microsoft Store to show a notification that
                        // the app was updated.
                        CoreApplication.Exit();
                    }
                    break;
                }
                // If the update was cancelled by the user, allow them to try again.
                case StorePackageUpdateState.Canceled: {
                    Debug.WriteLine($"{this.GetType()}: HandleUpdateResultAsync: Update cancelled");
                    VisualStateManager.GoToState(this, this.UpdateAvailableState.Name, false);
                    break;
                }
                // When the update failed for whatever reason, indicate this to
                // the user and what to do next.
                default: {
                    Debug.WriteLine($"{this.GetType()}: HandleUpdateResultAsync: " +
                        $"Update failed {result.OverallState}");
                    VisualStateManager.GoToState(this, this.UpdateFailedState.Name, false);

                    IEnumerable<StorePackageUpdateStatus> failedUpdates =
                        result.StorePackageUpdateStatuses.Where(
                            status => status.PackageUpdateState != StorePackageUpdateState.Completed);

                    foreach (StorePackageUpdateStatus failedUpdate in failedUpdates) {
                        Debug.WriteLine($"{this.GetType()}: HandleUpdateResultAsync: " +
                            $"{failedUpdate.PackageFamilyName} state is {failedUpdate.PackageUpdateState}");
                    }
                    if (updates.Any(u => u.Mandatory && failedUpdates.Any(
                        failed => failed.PackageFamilyName == u.Package.Id.FamilyName))) {

                        Debug.WriteLine($"{this.GetType()}: HandleUpdateResultAsync: " +
                            $"Mandatory updates remaining");
                    }
                    break;
                }
            }
        }

        private async Task<bool> RestartAppAsync(string appArgs = "") {
            AppRestartFailureReason result = await CoreApplication.RequestRestartAsync(appArgs);

            // When successful, execution stops above and the app closes.
            // Anything below gets executed when the request failed.

            Debug.WriteLine($"{this.GetType()}: RestartAppAsync: Result was {result}");
            return false;
        }
    }
}
