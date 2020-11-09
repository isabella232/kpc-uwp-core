/**
 * IAppUpdater.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using System.Threading.Tasks;


namespace KanoComputing.AppUpdate {

    public interface IAppUpdater {

        Task<bool> IsUpdateAvailableAsync();
        Task CheckAndRequestMandatoryUpdateAsync();
        Task<bool> IsMandatoryUpdateAvailableAsync(bool setFlag = true);
        bool IsMandatoryUpdateAvailableViaFlag();
        bool IsMandatoryUpdateFlagComputed();
    }
}
