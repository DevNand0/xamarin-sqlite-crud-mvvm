using SqliteMAUI_MVVM.Models;
using SqliteMAUI_MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteMAUI_MVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeEquipmentPage : ContentPage
    {
        public CoffeeEquipmentPage()
        {
            InitializeComponent();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var coffee = ((ListView)sender).SelectedItem as Coffee;
            if (coffee == null) return;

            await DisplayAlert("Cafe Seleccionado", coffee.Name,"OK");
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private async void MenuItem_clicked(object sender, EventArgs e) 
        {
            var coffee = ((MenuItem)sender).BindingContext as Coffee;
            await DisplayAlert("Cafe Favorito", coffee.Name, "OK");
        }
    }
}