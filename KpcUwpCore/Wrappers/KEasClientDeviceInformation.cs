/**
 * KEasClientDeviceInformation.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using Windows.Security.ExchangeActiveSyncProvisioning;


namespace KanoComputing.Wrappers {

    /// <summary>
    /// Testable wrapper for Windows.Security.ExchangeActiveSyncProvisioning.EasClientDeviceInformation.
    /// </summary>
    public class KEasClientDeviceInformation : IKEasClientDeviceInformation {

        private readonly EasClientDeviceInformation easClientDeviceInformation =
            new EasClientDeviceInformation();

        public KEasClientDeviceInformation(
                string systemManufacturer = "",
                string systemProductName = "",
                string systemSku = "") {

            this.SystemManufacturer = systemManufacturer ?? this.easClientDeviceInformation.SystemManufacturer;
            this.SystemProductName = systemProductName ?? this.easClientDeviceInformation.SystemProductName;
            this.SystemSku = systemSku ?? this.easClientDeviceInformation.SystemSku;
        }

        public string SystemManufacturer { get; private set; }

        public string SystemProductName { get; private set; }

        public string SystemSku { get; private set; }
    }
}
