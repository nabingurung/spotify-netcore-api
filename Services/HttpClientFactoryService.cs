using System.Text.Json;
using netcore_spotify_api.Dto;

namespace netcore_spotify_api.Services
{
    public class HttpClientFactoryService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly JsonSerializerOptions _options;

        public HttpClientFactoryService( IHttpClientFactory httpClientFactory , IConfiguration configuration )
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        }
        public async Task ExecuteAsync()
        {
            await GetTop10Artists();
        }

        private async Task GetTop10Artists()
        {
            var httpClient = _httpClientFactory.CreateClient();

            using var response = await httpClient.GetAsync(new Uri($"{_configuration["SpotifyBaseUrl"]}/api/Spotify"));
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStreamAsync();

            var artists = await JsonSerializer.DeserializeAsync<List<ArtistDto>>(result, _options);

        }
    }
}
