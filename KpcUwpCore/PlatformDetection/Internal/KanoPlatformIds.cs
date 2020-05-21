/**
 * KanoPlatformIds.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using System.Collections.Generic;


namespace KanoComputing.PlatformDetection.Internal {

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
                // SKU identifier and had a default value. This is the device
                // that used the Atom chip and made by one OEM.
                {"Default string", KanoPcSku.Retail},

                // The second version of the Kano PC was made using a Celeron
                // chip by another OEM and planned for use in education markets.
                {"EDU", KanoPcSku.Education},

                // The third version of the PC is planned to be used in all
                // markets and uses a generic versioning scheme:
                // KPC-<last two digits of the year><month in two digits>
                {"KPC2002", KanoPcSku.KPC2002},

                // The forth version of the PC coincided with KPC2005JA and the
                // image contains both English and Japanese language packs. With
                // the only difference being in the BIOS SKU identifier.
                {"KPC2005", KanoPcSku.KPC2005},

                // The fifth version of the PC coincided with KPC2005 and the
                // image contains both English and Japanese language packs. With
                // the only difference being in the BIOS SKU identifier.
                {"KPC2005JA", KanoPcSku.KPC2005JA}
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
