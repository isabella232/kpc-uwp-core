/**
 * KanoPlatformIdsFixtures.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using KanoComputing.PlatformDetection;
using KanoComputing.PlatformDetection.Internal;
using System.Collections.Generic;
using System.Linq;


namespace KanoComputing.Tests.Fixtures.PlatformDetection {

    public class KanoPlatformIdsFixtures {

        public static IEnumerable<object[]> KanoDeviceIds() {
            foreach (KeyValuePair<string, KanoDevice> entry in KanoPlatformIds.KanoDeviceIds) {
                yield return new object[] { entry.Key, entry.Value };
            }
        }

        public static IEnumerable<object[]> KanoDeviceIdsWithUnkown() {
            return KanoDeviceIds().Concat(new List<object[]> {
                new object[] { "BEST-PC", KanoDevice.Unknown },
                new object[] { "WOW-PC", KanoDevice.Unknown }});
        }

        public static IEnumerable<object[]> KanoPcSkuIds() {
            foreach (KeyValuePair<string, KanoPcSku> entry in KanoPlatformIds.KanoPcSkuIds) {
                yield return new object[] { entry.Key, entry.Value };
            }
        }

        public static IEnumerable<object[]> KanoPcSkuIdsWithUnknown() {
            return KanoPcSkuIds().Concat(new List<object[]> {
                new object[] { "SO-SKU", KanoPcSku.Unknown },
                new object[] { "MUCH-INFO", KanoPcSku.Unknown }});
        }
    }
}
