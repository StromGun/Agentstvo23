using Agentstvo23.DAL.Context;
using Agentstvo23.DAL.Entities;
using Agentstvo23.Infrastructure.Commands;
using Agentstvo23.Infrastructure.Events;
using Agentstvo23.ViewModels.Base;
using Agentstvo23.ViewModels.Test;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Agentstvo23.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title = "Agentstvo23";
        private ViewModel? currentView;
        private User? user = null;

        public string Title { get => _title; set => Set(ref _title, value); }
        public ViewModel? CurrentView { get => currentView; set => Set(ref currentView, value); }
        public User? User { get => user; set => Set(ref user, value); }

        public readonly NavigationViewModel NavigationVm;
        public readonly RealEstatesViewModel BuildingsVm;
        public readonly ApartmentsViewModel ApartmentsVm;
        public readonly AuthorizationViewModel AuthorizationVm;
        public readonly DataTableViewModel dataTableView;


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
            AuthorizationViewModel authorizationView,

            DataTableViewModel dataTableView
            )
        {
            NavigationVm = Navigation;
            Navigation.MainModel = this;

            BuildingsVm = buildingsVm;
            buildingsVm.MainModel = this;

            ApartmentsVm = apartmentsView;

            AuthorizationVm = authorizationView;
            this.dataTableView = dataTableView;

            authorizationView.mainModel = this;

        }

        public async Task LoadAsync()
        {
            Load();
            CurrentView = AuthorizationVm;
        }


        public void Load()
        {
            if (User != null)
            {
                AdminVisibility = Visibility.Visible;
            }
            else
            {
                AdminVisibility = Visibility.Collapsed;
            }
        }

        private Visibility visibility;
        public Visibility AdminVisibility { get => visibility; set => Set(ref visibility, value); }

    }
}
