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
        public RealEstateDB DataBase { get; set; }


        public MainWindowViewModel(RealEstateDB db)
        {
            DataBase = db;
            CurrentView = new NavigationViewModel(this, DataBase);
        }
    }
}
