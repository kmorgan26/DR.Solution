using DRApplication.Shared.Filters;
using DRApplication.Shared.Interfaces;
using DRApplication.Shared.Requests;
using DRApplication.Shared.Responses;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace DRApplication.Client.Services
{
    public class AdHocRepository<TEntity> : IAdHocRepository<TEntity> where TEntity : class
    {
        private readonly HttpClient _http;

        public AdHocRepository(HttpClient http)
        {
            _http = http;
        }
        public async Task<IEnumerable<TEntity>> Get(AdhocRequest adhocRequest)
        {
            try
            {
                string url = adhocRequest.Url;
                var result = await _http.PostAsJsonAsync(url, adhocRequest);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<APIListOfEntityResponse<TEntity>>(responseBody);

                if (response is not null && response.Success)
                    return response.Data;
                else
                    return new List<TEntity>();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Task<PagedResponse<TEntity>> GetAsync(QueryFilter<TEntity> Filter)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(object Id)
        {
            throw new NotImplementedException();
        }
    }
}
