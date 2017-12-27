using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HAM.Models;

namespace HAMApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAssetPage : ContentPage
    {
        public Asset Asset { get; set; }

        public NewAssetPage()
        {
            InitializeComponent();

            Asset = new Asset
            {
                Name = "Item name",
                Notes = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Asset);
            await Navigation.PopModalAsync();
        }
    }
}