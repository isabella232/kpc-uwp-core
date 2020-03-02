/**
 * KanoPlatforms.cs
 * 
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using System;
using System.Threading.Tasks;


namespace KanoComputing.PackageManagement
{
    public interface IPackageScanner
    {
        Task<bool> IsAppInstalledAsync(Uri protocolName, string packageFamilyName);
    }
}
