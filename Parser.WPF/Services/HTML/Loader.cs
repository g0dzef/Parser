using System.Net.Http;

namespace Parser.WPF.Services.HTML
{
    public class Loader
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public Loader(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
        }

        public async Task<string> GetContentByUrl(string siteUrl)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var request = await _httpClient.GetAsync(siteUrl);
            cancellationTokenSource.Token.ThrowIfCancellationRequested();

            var responce = "";

            if (request != null && request.StatusCode == System.Net.HttpStatusCode.OK)
            {
                responce = await request.Content.ReadAsStringAsync();
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
            }

            _httpClient.Dispose();

            return responce;
        }
    }
}
