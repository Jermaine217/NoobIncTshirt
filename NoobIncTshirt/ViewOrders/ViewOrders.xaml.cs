using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace NoobIncTshirt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewOrders : ContentPage
    {
        public List<TShirttable> TShirtOrders { get; set; }

        private TShirttable selectedOrders;
        public ViewOrders()
        {
            InitializeComponent();
        
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var tshirtDatabase = App.Database;
            TShirtOrders = await tshirtDatabase.GetItemsAsync();
            BindingContext = this;
        }
        private async void OnConfirmOrderClicked(object sender, EventArgs e)
        {
            var client = new HttpClient(new HttpClientHandler());
            var url = "https://10.0.2.2:5001/TshirtOrder";
            var TShirttable = new TShirttable();
            var json = JsonConvert.SerializeObject(TShirttable);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync(url, content);
                await DisplayAlert("Response Message", response.ReasonPhrase, "ok");
            }
            catch (Exception)
            {
                await DisplayAlert("Exceptions", "Try Again", "ok");
            }


        }

            public async Task ShowMap()
            {

                var placemark = new Placemark
                {
                    
                    Thoroughfare = selectedOrders.ShippingAddress
                    
                };
                var options = new MapLaunchOptions { Name = "Mitchell's Plain" };

                await Xamarin.Essentials.Map.OpenAsync(placemark, options);

                
            }

        private async void OnConfirmAddressClicked(object sender, EventArgs e)
        {
            await ShowMap();
        }

        private async void OnTRACKPackageClicked(object sender, EventArgs e)
        {
            if (selectedOrders != null)
            {
                var placemark = new Placemark
                {
                    Thoroughfare = selectedOrders.ShippingAddress
                };
                var options = new MapLaunchOptions { Name = selectedOrders.Name };
                await Map.OpenAsync(placemark, options);
            }
        }
        private void SelectedTShirtOrder(object sender, SelectedItemChangedEventArgs e)
        {
            selectedOrders = e.SelectedItem as TShirttable;
        }

    }

}


