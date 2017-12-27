using HAM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(HAMApp.Services.AzureDataStore))]
namespace HAMApp.Services
{
    class AzureDataStore : IDataStore<Asset>
    {
        List<Asset> assets;
        HttpClient httpClient = new HttpClient();

        public Task<bool> AddAsync(Asset item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Asset item)
        {
            throw new NotImplementedException();
        }

        public Task<Asset> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Asset>> GetAsync(bool forceRefresh = false)
        {
            try
            {
                var webResult = await httpClient.GetStringAsync($"{App.AzureServiceUrl}/api/Assets");
                assets = JsonConvert.DeserializeObject<List<Asset>>(webResult);
                return assets;
            }
            catch (Exception ex)
            {
                // do stuff
            }
            return null;
        }

        public Task<bool> UpdateAsync(Asset item)
        {
            throw new NotImplementedException();
        }
    }
}
