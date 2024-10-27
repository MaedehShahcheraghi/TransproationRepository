namespace TransportationSystem.UI.Contracts.LocalStorage
{
    public interface ILocalStorageService
    {
        void ClearStorage(List<string> keys);
        void SeTStorgeValue<T>(string key, T value);
        T GetStorageValue<T>(string key);
        bool Exsits(string key);
    }
}
