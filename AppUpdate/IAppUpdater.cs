using System.Threading.Tasks;


namespace AppUpdate {

    public interface IAppUpdater {
        Task<bool> IsUpdateAvailableAsync();
        Task<bool> IsMandatoryUpdateAvailableAsync(bool setFlag = true);
        bool IsMandatoryUpdateAvailableFlagSet();
    }
}
