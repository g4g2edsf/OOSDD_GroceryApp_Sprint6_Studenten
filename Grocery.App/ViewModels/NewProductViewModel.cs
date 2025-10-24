using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.App.ViewModels
{
    public partial class NewProductViewModel : ObservableObject
    {
        private readonly IProductService _productService;

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private int _stock;

        [ObservableProperty]
        private DateOnly _shelfLife = DateOnly.FromDateTime(DateTime.Today.AddMonths(6));

        [ObservableProperty]
        private decimal _price;

        public NewProductViewModel(IProductService productService)
        {
            _productService = productService;
        }

        [RelayCommand]
        private async Task AddProductAsync()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                await Shell.Current.DisplayAlert("Fout", "Product naam is verplicht", "OK");
                return;
            }

            var product = new Product(0, Name, Stock, ShelfLife, Price);
            _productService.Add(product);
            await Shell.Current.GoToAsync("..", true);
        }
    }
}