using HAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(HAMApp.Services.MockDataStore))]
namespace HAMApp.Services
{
    public class MockDataStore : IDataStore<Asset>
    {
        List<Asset> assets;

        public MockDataStore()
        {
            assets = new List<Asset>();
            var mockItems = new List<Asset>
            {
                new Asset { Id = 0, Name = "First item", Notes="This is an item description." },
                new Asset { Id = 1, Name = "Second item", Notes="This is an item description." },
                new Asset { Id = 2, Name = "Third item", Notes="This is an item description." },
                new Asset { Id = 3, Name = "Fourth item", Notes="This is an item description." },
                new Asset { Id = 4, Name = "Fifth item", Notes="This is an item description." },
                new Asset { Id = 5, Name = "Sixth item", Notes="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                assets.Add(item);
            }
        }

        public async Task<bool> AddAsync(Asset item)
        {
            assets.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(Asset item)
        {
            var _item = assets.Where((Asset arg) => arg.Id == item.Id).FirstOrDefault();
            assets.Remove(_item);
            assets.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(Asset item)
        {
            var _item = assets.Where((Asset arg) => arg.Id == item.Id).FirstOrDefault();
            assets.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Asset> GetAsync(int id)
        {
            return await Task.FromResult(assets.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Asset>> GetAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(assets);
        }
    }
}