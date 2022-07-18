using MvvmHelpers;
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
    public class MyCoffeeViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Coffee> RemoveCommand { get; }
        public AsyncCommand<Coffee> SelectedCommand { get; }

        //ICoffeeService coffeeService;
        CoffeeService coffeeService { get; set; }

        public MyCoffeeViewModel() 
        {
            Title = "My Coffee";
            Coffee = new ObservableRangeCollection<Coffee>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand     = new AsyncCommand(Add);
            RemoveCommand  = new AsyncCommand<Coffee>(Remove);
            SelectedCommand  = new AsyncCommand<Coffee>(Selected);

            //coffeeService = DependencyService.Get<ICoffeeService>();
            coffeeService = new CoffeeService();
        }


        public async Task Add() 
        {
            /*
            var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Nombre del Cafe");
            var roaster = await App.Current.MainPage.DisplayPromptAsync("Roaster", "Roaster del Cafe");
            var image = "coffeebag.png";
            await CoffeeService.add(new Models.Coffee { Name = name, Roaster = roaster, Image = image });
            await Refresh();*/
            await Shell.Current.GoToAsync("AddMyCoffeePage");
        }

        public async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(500);
            Coffee.Clear();
            var coffees = await coffeeService.all();
            Coffee.AddRange(coffees);
            IsBusy = false;
            DependencyService.Get<IToast>()?.MakeToast("Datos Recargados!");
        }

        public async Task Remove(Coffee coffee)
        {
            await coffeeService.remove(coffee.Id);
            await Refresh();
        }

        public async Task Selected(Coffee coffee)
        {
            if (coffee == null) return;
            await Shell.Current.GoToAsync("MyCoffeeDetailPage?CoffeeId="+coffee.Id);
        }

    }
}
