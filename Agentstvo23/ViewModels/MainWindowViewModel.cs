using Agentstvo23.DAL.Context;
using Agentstvo23.ViewModels.Base;

namespace Agentstvo23.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title = "Agentstvo23";
        private ViewModel currentView;

        public string Title { get => _title; set => Set(ref _title, value); }
        public ViewModel CurrentView { get => currentView; set => Set(ref currentView, value); }
        private readonly RealEstateDB DataBase;


        public NavigationViewModel NavigationVm { get; }
        public RealEstatesViewModel BuildingsVm { get; }


        public MainWindowViewModel(
            RealEstateDB db,
            RealEstatesViewModel buildingsVm,
            NavigationViewModel Navigation
            )
        {
            DataBase = db;
            NavigationVm = Navigation;
            NavigationVm.MainModel = this;

            BuildingsVm = buildingsVm;
            BuildingsVm.MainModel = this;


            CurrentView = NavigationVm;
        }
    }
}
