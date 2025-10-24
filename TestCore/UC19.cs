using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TestCore
{
    // ----- Simpele ViewModel voor test -----
    public partial class ProductViewModel : ObservableObject
    {
        public bool NavigationCalled { get; private set; } = false;

        [RelayCommand]
        public async Task NavigateToNewProductAsync()
        {
            NavigationCalled = true;
            await Task.CompletedTask;
        }
    }
    
    public class ProductViewModelTests
    {
        // Happy
        [Test]
        public async Task NavigateToNewProductCommand_HappyFlow()
        {
            var vm = new ProductViewModel();
            await vm.NavigateToNewProductAsync();
            Assert.True(vm.NavigationCalled);
        }

        // Unhappy flow
        [Test]
        public void NavigateToNewProductCommand_UnhappyFlow()
        {
            var vm = new ProductViewModel();
            Assert.False(vm.NavigationCalled);
        }
    }
}