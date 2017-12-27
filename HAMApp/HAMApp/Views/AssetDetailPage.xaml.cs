using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HAMApp.ViewModels;
using HAM.Models;

namespace HAMApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AssetDetailPage : ContentPage
	{
        AssetDetailViewModel viewModel;

        public AssetDetailPage(AssetDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public AssetDetailPage()
        {
            InitializeComponent();

            var asset = new Asset
            {
                Name = "Item 1",
                Notes = "This is an item description."
            };

            viewModel = new AssetDetailViewModel(asset);
            BindingContext = viewModel;
        }
    }
}