using DRApplication.Shared.Filters;
using DRApplication.Shared.Interfaces;
using DRApplication.Shared.Responses;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace DRApplication.Client.Services
{
    public class ApiRepository<TEntity> : IRepository<TEntity> where TEntity : class
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
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var result = await _http.GetAsync(_controllerName);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<APIListOfEntityResponse<TEntity>>(responseBody);

                if (response is not null && response.Success)
                    return response.Data;
                else
                    return new List<TEntity>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<PagedResponse<TEntity>> GetAsync(QueryFilter<TEntity> Expression)
        {
            try
            {
                string url = $"{_controllerName}/getwithfilter";
                var result = await _http.PostAsJsonAsync(url, Expression);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                
                var response = JsonConvert.DeserializeObject<PagedResponse<TEntity>>(responseBody);

                if (response is not null && response.Success)
                    return response;
                else
                    return new PagedResponse<TEntity>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
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
                var response = JsonConvert.DeserializeObject<APIEntityResponse<TEntity>>(responseBody);

                if (response is not null && response.Success)
                    return response.Data;
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            try
            {
                var result = await _http.PostAsJsonAsync(_controllerName, entity);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<APIEntityResponse<TEntity>>(responseBody);

                if (response is not null && response.Success)
                    return response.Data;
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                var response = JsonConvert.DeserializeObject<APIEntityResponse<TEntity>>(responseBody);

                if (response is not null && response.Success)
                    return response.Data;
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> DeleteByIdAsync(object id)
        {
            try
            {
                var url = _controllerName + "/" + WebUtility.HtmlEncode(id.ToString());
                var result = await _http.DeleteAsync(url);
                result.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }
        
    }
}