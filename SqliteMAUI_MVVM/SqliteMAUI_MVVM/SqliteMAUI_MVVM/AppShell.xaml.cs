using SqliteMAUI_MVVM.Views.MyCoffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteMAUI_MVVM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddMyCoffeePage),
                typeof(AddMyCoffeePage));

            Routing.RegisterRoute(nameof(MyCoffeeDetailPage),
                typeof(MyCoffeeDetailPage));
        }
    }
}