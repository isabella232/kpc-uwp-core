using System.Collections.Generic;


namespace KanoPlatformDetection.Internal {

    public static class KanoPlatformIds {

        private static readonly Dictionary<string, KanoDevice> KanoDeviceIds =
            new Dictionary<string, KanoDevice> {
                {"KANO-PC", KanoDevice.KanoPc}
            };

        public static bool IsKanoDeviceIdValid(string deviceId) {
            return KanoDeviceIds.ContainsKey(deviceId);
        }

        public static KanoDevice GetDeviceById(string deviceId) {
            return IsKanoDeviceIdValid(deviceId) ? 
                KanoDeviceIds[deviceId] : KanoDevice.Unknown;
        }


        private static readonly Dictionary<string, KanoPcSku> KanoPcSkuIds =
            new Dictionary<string, KanoPcSku> {
                // The first revision of the hardware & firmware didn't set the
                // SKU identifier and had a default value.
                {"Default string", KanoPcSku.Retail},
                {"EDU", KanoPcSku.Education}
            };

        public static bool IsKanoPcSkuValid(string skuId) {
            return KanoPcSkuIds.ContainsKey(skuId);
        }

        public static KanoPcSku GetKanoPcSkuById(string skuId) {
            return IsKanoPcSkuValid(skuId) ?
                KanoPcSkuIds[skuId] : KanoPcSku.Unknown;
        }
    }
}
