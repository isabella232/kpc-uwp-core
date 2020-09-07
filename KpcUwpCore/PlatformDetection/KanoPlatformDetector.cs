/**
 * KanoPlatformDetector.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using KanoComputing.PlatformDetection.Internal;
using KanoComputing.Wrappers;


namespace KanoComputing.PlatformDetection {

    public class KanoPlatformDetector : IKanoPlatformDetector {

        private readonly IKEasClientDeviceInformation deviceInfo = null;

        public KanoPlatformDetector(IKEasClientDeviceInformation deviceInfo = null) {
            // TODO: Inject this dependency.
            this.deviceInfo = deviceInfo ?? new KEasClientDeviceInformation();
        }

        public bool IsKanoDevice() {
            return this.GetKanoDevice() != KanoDevice.Unknown;
        }

        public bool IsKanoPc() {
            return this.GetKanoDevice() == KanoDevice.KanoPc;
        }

        public bool IsKanoPcRetail() {
            return
                this.IsKanoPc() &&
                this.GetKanoPcSku() == KanoPcSku.Retail;
        }
        public bool IsKanoPcEducation() {
            return
                this.IsKanoPc() &&
                this.GetKanoPcSku() == KanoPcSku.Education;
        }

        public KanoDevice GetKanoDevice() {
            string model = this.deviceInfo.SystemProductName;
            return KanoPlatformIds.GetDeviceById(model);
        }

        public KanoPcSku GetKanoPcSku() {
            string sku = this.deviceInfo.SystemSku;
            return KanoPlatformIds.GetKanoPcSkuById(sku);
        }
    }
}
