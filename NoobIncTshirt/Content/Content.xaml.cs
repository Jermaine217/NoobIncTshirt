﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoobIncTshirt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Content : ContentPage
    {
        public Content()
        {
            InitializeComponent();
       
    
        }
    
         private void OnButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());
        }

    
    }


}