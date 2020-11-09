/**
 * IResourcesHelper.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using Windows.ApplicationModel.Resources;


namespace KanoComputing.Resources {

    public interface IResourcesHelper {

        ResourceLoader GetResourceLoader(string name);
    }
}
