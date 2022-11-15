using MyCoffeeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace MyCoffeeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyStoredCoffeePage : ContentPage
    {
        public MyStoredCoffeePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = (MyCoffeeViewModel)BindingContext;
            if (vm.Coffee.Count == 0)
                await vm.RefreshCommand.ExecuteAsync();
        }
    }
}