using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoobIncTshirt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
      
        
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var tShirttable = new TShirttable();

            BindingContext = tShirttable;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var tShirttable = (TShirttable)BindingContext;

            await App.Database.SaveItemAsync(tShirttable);
            await Navigation.PopAsync();

        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {

        }

        private void OnCancelClicked(object sender, EventArgs e)
        {

        }
    }
}
 