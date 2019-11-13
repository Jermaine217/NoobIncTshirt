using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NoobIncTshirt
{
    public class items: ContentPage
    {
        public items()
        {
            Title = "Item";

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var SizeEntry = new Entry();
            SizeEntry.SetBinding(Entry.TextProperty, "Size");

            var ShippingAddressEntry = new Entry();
            ShippingAddressEntry.SetBinding(Entry.TextProperty, "ShippingAddress");

            var doneSwitch = new Switch();
            doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var TShirttable = (TShirttable)BindingContext;
                await App.Database.SaveItemAsync(TShirttable);
                await Navigation.PopAsync();
            };


            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Size" },
                    SizeEntry,
                    new Label { Text = "ShippingAddress" },
                    ShippingAddressEntry,
                    new Label { Text = "Done" },
                    doneSwitch,
                    saveButton,


                }
            };
        }


    }
}

