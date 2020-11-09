/**
 * ResourcesFixtures.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using KanoComputing.Assets;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.ApplicationModel.Resources.Core;


namespace Tests.Fixtures.Resources {

    public class ResourcesFixtures {

        /// <summary>
        /// Provides all string key identifiers listed in the main Resources.resw
        /// file for the library.
        /// </summary>
        public static IEnumerable<object[]> AllStringKeys() {
            IReadOnlyDictionary<string, ResourceMap> resourceMaps =
                ResourceManager.Current.AllResourceMaps;

            foreach (KeyValuePair<string, ResourceMap> entry in resourceMaps) {
                foreach (string key in entry.Value.Keys) {
                    Debug.WriteLine($"ResourceMap {entry.Key} contains string key {key}");
                    if (key.StartsWith(ResourceMapIds.Strings)) {
                        yield return new object[] { key.Remove(0, ResourceMapIds.Strings.Length + 1) };
                    }
                }
            }
        }
    }
}
