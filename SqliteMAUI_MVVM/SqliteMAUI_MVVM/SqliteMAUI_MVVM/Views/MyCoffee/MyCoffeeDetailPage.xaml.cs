using SqliteMAUI_MVVM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteMAUI_MVVM.Views.MyCoffee
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(CoffeeId), nameof(CoffeeId))]
    public partial class MyCoffeeDetailPage : ContentPage
    {
        public string CoffeeId { get; set; }
        CoffeeService coffeeService { get; set; }
        
        public MyCoffeeDetailPage()
        {
            InitializeComponent();
            coffeeService = new CoffeeService();
        }

        protected override async void OnAppearing() 
        {
            base.OnAppearing();
            int.TryParse(CoffeeId, out var result);
            BindingContext = await coffeeService.get(result);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}