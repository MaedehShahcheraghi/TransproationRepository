namespace TransportationSystem.UI.Sevices.Base
{
    public partial class Client : IClient
    {
        public HttpClient httpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
