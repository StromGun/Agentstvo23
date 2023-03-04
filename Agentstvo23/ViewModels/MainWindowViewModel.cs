using Agentstvo23.DAL.Context;
using Agentstvo23.Infrastructure.Commands;
using Agentstvo23.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agentstvo23.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title = "Agentstvo23";
        private object currentView;

        public string Title { get => _title; set => Set(ref _title, value); }
        public object CurrentView { get => currentView; set => Set(ref currentView, value); }
        private readonly RealEstateDB DataBase;


        public INavigationViewModel NavigationVm { get; }
        public RealEstatesViewModel BuildingsVm { get; }


        #region Commands
        private LambdaCommand? _LoadAsync;
        public ICommand LoadAsyncCmd => _LoadAsync
            ??= new(LoadAsyncExecuted);

        private void LoadAsyncExecuted()
        {
            LoadAsync();
        } 
        #endregion



        public MainWindowViewModel(
            RealEstateDB db,
            RealEstatesViewModel buildingsVm,
            INavigationViewModel Navigation
            )
        {
            DataBase = db;
            NavigationVm = Navigation;
        }

        public async Task LoadAsync()
        {
            CurrentView = NavigationVm;
            await NavigationVm.LoadAsync();
        }
    }
}
