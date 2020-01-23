using System;
using System.Threading.Tasks;


namespace PackageManagement
{
    public interface IPackageScanner
    {
        Task<bool> IsAppInstalledAsync(Uri protocolName, string packageFamilyName);
    }
}
