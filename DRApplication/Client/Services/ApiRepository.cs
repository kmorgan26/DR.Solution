using DRApplication.Shared.Filters;
using DRApplication.Shared.Interfaces;
using DRApplication.Shared.Responses;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace DRApplication.Client.Services
{
    public class ApiRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : class
    {
        private readonly HttpClient _http;
        private readonly string _controllerName;
        private readonly string _primaryKeyName;

        public ApiRepository(HttpClient http, string controllerName, string primaryKeyName)
        {
            _http = http;
            _controllerName = controllerName;
            _primaryKeyName = primaryKeyName;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(PaginationFilter? paginationFilter = null)
        {
            try
            {
                var result = await _http.GetAsync(_controllerName);
                result.EnsureSuccessStatusCode();
                
                string responseBody = await result.Content.ReadAsStringAsync();

                if (paginationFilter == null)
                {
                    var response = JsonConvert.DeserializeObject<PagedResponse<TEntity>>(responseBody);
                    
                    if (paginationFilter == null)
                    {
                        if (response is not null && response.Data is not null && response.Success)
                            return response.Data.ToList();
                        else
                            return new List<TEntity>();
                    }
                }
                
                var skip = (paginationFilter.PageNumber -1 ) * paginationFilter.PageSize;

                var filtered = responseBody
                    .Take(paginationFilter.PageSize)
                    .Skip(skip)
                    .ToList();

                var pagedResponse = JsonConvert.DeserializeObject<PagedResponse<TEntity>>(responseBody);

                if (pagedResponse is not null && pagedResponse.Data is not null)
                    return pagedResponse.Data.ToList();
                else
                    return new List<TEntity>();

            }
            catch
            {
                return new List<TEntity>();
            }
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            try
            {
                var arg = WebUtility.HtmlEncode(id.ToString());
                var url = _controllerName + "/" + arg;
                var result = await _http.GetAsync(url);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<Response<TEntity>>(responseBody);
                
                if (response is not null && response.Data is not null && response.Success)
                    return response.Data;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                var result = await _http.PostAsJsonAsync(_controllerName, entity);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<Response<TEntity>>(responseBody);

                if ( response is not null && response.Data is not null && response.Success)
                    return response.Data;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            try
            {
                var result = await _http.PutAsJsonAsync(_controllerName, entityToUpdate);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<Response<TEntity>>(responseBody);
                if ( response is not null && response.Data is not null && response.Success)
                    return response.Data;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(TEntity entityToDelete)
        {
            try
            {
                    var value = entityToDelete.GetType()
                    .GetProperty(_primaryKeyName)
                    .GetValue(entityToDelete, null)
                    .ToString();
                    var arg = WebUtility.HtmlEncode(value);
                    var url = _controllerName + "/" + arg;
                    var result = await _http.DeleteAsync(url);
                    result.EnsureSuccessStatusCode();
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(object id)
        {
            try
            {
                var url = _controllerName + "/" + WebUtility.HtmlEncode(id.ToString());
                var result = await _http.DeleteAsync(url);
                result.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public Task<IReadOnlyList<TEntity>> GetPagedReponseAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TEntity>> ListAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}