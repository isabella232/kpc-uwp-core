using KanoPlatformDetection.Internal;
using Windows.Security.ExchangeActiveSyncProvisioning;


namespace KanoPlatformDetection {

    public sealed class KanoPlatformDetector : IKanoPlatformDetector {

        private readonly EasClientDeviceInformation deviceInfo = null;

        public KanoPlatformDetector() {
            // TODO: Inject this dependency.
            this.deviceInfo = new EasClientDeviceInformation();
        }

        public bool IsKanoDevice() {
            return this.GetKanoDevice() != KanoDevice.Other;
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

            if (KanoPlatformIds.IsKanoDeviceIdValid(model))
                return KanoPlatformIds.GetDeviceById(model);

            return KanoDevice.Other;
        }

        public KanoPcSku GetKanoPcSku() {
            string sku = this.deviceInfo.SystemSku;

            if (KanoPlatformIds.IsKanoPcSkuValid(sku))
                return KanoPlatformIds.GetKanoPcSkuById(sku);

            return KanoPcSku.Other;
        }
    }
}
