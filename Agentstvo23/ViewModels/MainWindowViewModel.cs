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


        public NavigationViewModel NavigationVm { get; }
        public RealEstatesViewModel BuildingsVm { get; }


        #region Commands

        #region LoadAsync -Command
        private LambdaCommand? _LoadAsync;
        public ICommand LoadAsyncCmd => _LoadAsync
            ??= new(LoadAsyncExecuted);

        private void LoadAsyncExecuted()
        {
            LoadAsync();
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
            NavigationViewModel Navigation
            )
        {
            NavigationVm = Navigation;
            Navigation.MainModel = this;

            BuildingsVm = buildingsVm;
            buildingsVm.MainModel = this;


        }

        public async Task LoadAsync()
        {
            CurrentView = NavigationVm;
            await NavigationVm.LoadAsync();
        }
    }
}
