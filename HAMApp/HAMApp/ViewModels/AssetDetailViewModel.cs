using HAM.Models;

namespace HAMApp.ViewModels
{
    public class AssetDetailViewModel : BaseViewModel
    {
        public Asset Asset { get; set; }
        public AssetDetailViewModel(Asset asset = null)
        {
            Title = asset?.Name;
            Asset = asset;
        }
    }
}
