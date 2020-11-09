/**
 * ResourcesHelper.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using System;
using System.Diagnostics;
using Windows.ApplicationModel.Resources;
using Windows.UI.Core;


namespace KanoComputing.Resources {

    public class ResourcesHelper : IResourcesHelper {

        /// <summary>
        /// Wraps around ResourceLoader functions GetForCurrentView
        /// and GetForViewIndependentUse to provide a usable object.
        /// </summary>
        public ResourceLoader GetResourceLoader(string name) {
            ResourceLoader resources = null;
            try {
                resources = CoreWindow.GetForCurrentThread() != null ?
                    ResourceLoader.GetForCurrentView(name) :
                    ResourceLoader.GetForViewIndependentUse(name);
            } catch (Exception e) {
                Debug.WriteLine($"{this.GetType()}: GetResourceLoader: Caught {e}");
            }
            return resources;
        }
    }
}
