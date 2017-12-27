using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HAMApp.ViewModels;
using HAM.Models;

namespace HAMApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AssetsPage : ContentPage
	{
        AssetsViewModel viewModel;

        public AssetsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new AssetsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var asset = args.SelectedItem as Asset;
            if (asset == null)
                return;

            await Navigation.PushAsync(new AssetDetailPage(new AssetDetailViewModel(asset)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewAssetPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Assets.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}