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
        private ViewModel currentView;

        public string Title { get => _title; set => Set(ref _title, value); }
        public ViewModel CurrentView { get => currentView; set => Set(ref currentView, value); }


        public readonly NavigationViewModel NavigationVm;
        public readonly RealEstatesViewModel BuildingsVm;
        public readonly ApartmentsViewModel ApartmentsVm;
        public readonly AuthorizationViewModel AuthorizationVm;


        #region Commands

        #region LoadAsync -Command
        private LambdaCommand? _LoadAsync;
        public ICommand LoadAsyncCmd => _LoadAsync
            ??= new(LoadAsyncExecuted);

        private async void LoadAsyncExecuted()
        {
            await LoadAsync();
        }
        #endregion

        #region GoMain - command
        private LambdaCommand? _GoMain;
        public ICommand GoMainCmd => _GoMain
            ??= new(GoMainExecuted);
        private void GoMainExecuted()
        {
            CurrentView = NavigationVm;
        } 
        #endregion

        #endregion



        public MainWindowViewModel(
            RealEstatesViewModel buildingsVm,
            NavigationViewModel Navigation,
            ApartmentsViewModel apartmentsView,
            AuthorizationViewModel authorizationView
            )
        {
            NavigationVm = Navigation;
            Navigation.MainModel = this;

            BuildingsVm = buildingsVm;
            buildingsVm.MainModel = this;

            ApartmentsVm = apartmentsView;

            AuthorizationVm = authorizationView;

        }

        public async Task LoadAsync()
        {
            CurrentView = AuthorizationVm;
            await NavigationVm.LoadAsync();
        }
    }
}
