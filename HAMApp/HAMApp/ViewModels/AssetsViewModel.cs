using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using HAMApp.Views;
using HAM.Models;

namespace HAMApp.ViewModels
{
    public class AssetsViewModel : BaseViewModel
    {
        public ObservableCollection<Asset> Assets { get; set; }
        public Command LoadItemsCommand { get; set; }

        public AssetsViewModel()
        {
            Title = "Browse";
            Assets = new ObservableCollection<Asset>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewAssetPage, Asset>(this, "AddAsset", async (obj, item) =>
            {
                var _item = item as Asset;
                Assets.Add(_item);
                await DataStore.AddAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Assets.Clear();
                var assets = await DataStore.GetAsync(true);
                foreach (var asset in assets)
                {
                    Assets.Add(asset);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}