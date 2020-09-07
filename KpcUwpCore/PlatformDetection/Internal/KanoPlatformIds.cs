/**
 * KanoPlatformIds.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using System.Collections.Generic;


namespace KanoComputing.PlatformDetection.Internal {

    public static class KanoPlatformIds {

        public static readonly Dictionary<string, KanoDevice> KanoDeviceIds =
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

        public static readonly Dictionary<string, KanoPcSku> KanoPcSkuIds =
            new Dictionary<string, KanoPcSku> {
                // The first revision of the hardware & firmware didn't set the
                // SKU identifier and had a default value. This is the device
                // that used the Atom chip and made by one OEM.
                // Windows 10 Home S mode v1903.
                {"Default string", KanoPcSku.Retail},

                // The second version of the Kano PC was made using a Celeron
                // chip by another OEM and planned for use in education markets.
                // Windows 10 Home S mode v1903.
                {"EDU", KanoPcSku.Education},

                // The third version of the PC is planned to be used in all
                // markets and uses a generic versioning scheme:
                // KPC-<last two digits of the year><month in two digits>
                // Windows 10 Home v1909.
                {"KPC2002", KanoPcSku.KPC2002},

                // The forth version of the PC was the first multilingual image
                // with both English and Japanese language packs preinstalled.
                // The edition of Windows was also upgraded for this batch.
                // Windows 10 Pro v2004.
                {"KPC2005", KanoPcSku.KPC2005},

                // The fifth version of the PC coincided with KPC2007JA and the
                // image contains both English and Japanese language packs. With
                // the only difference being in the BIOS SKU identifier.
                // Windows 10 Pro v2004.
                {"KPC2007", KanoPcSku.KPC2007},

                // The sixth version of the PC coincided with KPC2007 and the
                // image contains both English and Japanese language packs. With
                // the only difference being in the BIOS SKU identifier.
                // Windows 10 Pro v2004.
                {"KPC2007JA", KanoPcSku.KPC2007JA},

                // The seventh version of the PC switched back to Home in S mode
                // for Retail markets specifically with a revised naming scheme.
                // Windows 10 Home S mode v2004.
                {"KPC2010HS", KanoPcSku.KPC2010HS}
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
