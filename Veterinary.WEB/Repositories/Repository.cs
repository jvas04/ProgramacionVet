using System.Text.Json;
using System.Text;

namespace Veterinary.WEB.Repositories
{
    public class Repository : IRepository
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions _jsonDefaultOptions => new JsonSerializerOptions
        {

            PropertyNameCaseInsensitive = true

        };

        public Repository (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseWrapper<T>> GetAsync<T>(string url)
        {
            var responseHttp = await _httpClient.GetAsync(url);

            if (responseHttp.IsSuccessStatusCode){
                var response= await UnserializeAnswer<T>(responseHttp, _jsonDefaultOptions);

                return new HttpResponseWrapper<T> (response, false, responseHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(default, true, responseHttp);
            }
        }

        private async Task<T> UnserializeAnswer<T>
            (HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
        {
            var respuestaString = await
                httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(respuestaString, 
                jsonSerializerOptions)!;
        }


        public Task<HttpResponseWrapper<object>> Post<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T model)
        {
            throw new NotImplementedException();
        }
    }
}