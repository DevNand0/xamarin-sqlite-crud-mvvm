using MvvmHelpers.Commands;
using SqliteMAUI_MVVM.Models;
using SqliteMAUI_MVVM.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SqliteMAUI_MVVM.ViewModels.MyCoffee
{
    [QueryProperty(nameof(Name), nameof(Name))]
    public class AddMyCoffeeViewModel:ViewModelBase
    {
        string name, roaster;
        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Roaster { get => roaster; set => SetProperty(ref roaster, value); }

        public AsyncCommand SaveCommand { get; }
        //ICoffeeService coffeeService;
        CoffeeService coffeeService { get; set; }
        public AddMyCoffeeViewModel()
        {
            Title = "Agregar Cafe";
            SaveCommand = new AsyncCommand(Save);
            //coffeeService = DependencyService.Get<ICoffeeService>();
            coffeeService = new CoffeeService();
        }

        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(roaster))
            {
                return;
            }
            
            await coffeeService.add(new Coffee { Name = name, Roaster = roaster, Image = "coffeebag.png" });

            await Shell.Current.GoToAsync("..");
        }

    }
}
