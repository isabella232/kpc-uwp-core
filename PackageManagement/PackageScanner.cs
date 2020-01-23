/**
 * KanoPlatforms.cs
 * 
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.System;


namespace PackageManagement
{
    public class PackageScanner : IPackageScanner
    {
        public async Task<bool> IsAppInstalledAsync(Uri protocolName, string packageFamilyName)
        {
            try
            {
                LaunchQuerySupportStatus status = 
                    await Launcher.QueryUriSupportAsync(
                        protocolName, LaunchQuerySupportType.Uri, packageFamilyName);

                bool appInstalled = status == LaunchQuerySupportStatus.Available;
                
                Debug.WriteLine(
                    "PackageScanner: IsAppInstalledAsync: " + 
                    protocolName + " " + packageFamilyName + " " + appInstalled);

                return appInstalled;

            } catch (Exception e)
            {
                Debug.WriteLine("PackageScanner: IsAppInstalledAsync: Error: " + e);
                return false;
            }
        }
    }
}
