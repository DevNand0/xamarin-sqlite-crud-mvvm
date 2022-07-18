using MvvmHelpers;
using MvvmHelpers.Commands;
using SqliteMAUI_MVVM.Models;
using SqliteMAUI_MVVM.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace SqliteMAUI_MVVM.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; set; }


        private Coffee selectedCoffee;
        private Coffee previouslySelected;
        public Coffee SelectedCoffee
        {
            get => selectedCoffee;
            set => SetProperty(ref selectedCoffee, value);
        }

        bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }


        //COMANDOS ASYNC
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Coffee> FavoriteCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }
        //COMANDOS
        public Command LoadMoreCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command ClearCommand { get; }

        public CoffeeEquipmentViewModel() 
        {
            Title = "Coffee Equipment";
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            
            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Coffee>(Favorite);
            SelectedCommand = new AsyncCommand<object>(Selected);

            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);

            RefreshCommand.ExecuteAsync();
        }

        public ICommand CallServerCommand { get; }


        //SECCION DE ASYNC TASK 
        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            Coffee.Clear();
            LoadMore();
            IsBusy = false;
        }

        async Task Remove(Coffee coffee)
        {

            await Refresh();
        }


        async Task Favorite(Coffee coffee) 
        {
            if (coffee == null)
                return;
            await Application.Current.MainPage.DisplayAlert("Favorito Seleccionado", coffee.Name, "OK");
        }

        async Task Selected(object args) 
        {
            var coffee = args as Coffee;//el parametro debe ser de tipo Coffee
            if (coffee == null)
                return;
            SelectedCoffee = null;

            //await AppShell.Current.GoToAsync(nameof(AddMyCoffeePage));
            await Application.Current.MainPage.DisplayAlert("Selected", coffee.Name, "OK");
        }


        void DelayLoadMore()
        {
            if (Coffee.Count <= 10)
                return;

            LoadMore();
        }

        private void LoadMore()
        {
            if (Coffee.Count >= 20)
                return;
            var image = "coffeebag.png";
            Coffee.Add(new Models.Coffee { Roaster = "Yes Plz", Name = "Sip Sunshine", Image = image });
            Coffee.Add(new Models.Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            Coffee.Add(new Models.Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu", Image = image });

            CoffeeGroups.Clear();

            CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle", Coffee.Where(c => c.Roaster == "Blue Bottle")));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Yes Plz", Coffee.Where(c => c.Roaster == "Yes Plz")));

        }

        void Clear()
        {
            Coffee.Clear();
            CoffeeGroups.Clear();
        }



    }
}
