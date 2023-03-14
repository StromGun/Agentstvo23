using Agentstvo23.DAL.Context;
using Agentstvo23.Infrastructure.Commands;
using Agentstvo23.Services.Interfaces;
using Agentstvo23.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agentstvo23.ViewModels
{
    internal class NavigationViewModel : ViewModel, INavigationViewModel
    {
        #region Fields
        private string _title = "Навигация";
        private int countEstate;
        private int countNonResidentialBuilding;
        private int countResidentialBuilding;
        private int countApartmentBuilding; 
        #endregion

        public string Title { get => _title; set => Set(ref _title, value); }
        public MainWindowViewModel MainModel { get; internal set; }

        private readonly RealEstateDB DataBase;
        private readonly IBuildingCount BuildingCountService;


        #region Counts
        public int CountEstate { get => countEstate; set => Set(ref countEstate, value); }
        public int CountNonResidentialBuilding { get => countNonResidentialBuilding; set => Set(ref countNonResidentialBuilding, value); }
        public int CountResidentialBuilding { get => countResidentialBuilding; set => Set(ref countResidentialBuilding, value); }
        public int CountApartmentBuilding { get => countApartmentBuilding; set => Set(ref countApartmentBuilding, value); }
        #endregion



        #region Commands
        private LambdaCommand? _ShowRealEstatesView;
        public ICommand ShowRealEstatesView => _ShowRealEstatesView
            ??= new(ShowRealEstatesViewExecuted);

        private void ShowRealEstatesViewExecuted()
        {
            MainModel.CurrentView = MainModel.BuildingsVm;
        }

        private LambdaCommand? _ShowApartmentsView;
        public ICommand ShowApartmentsView => _ShowApartmentsView
            ??= new(ShowApartmentExecuted);

        private void ShowApartmentExecuted()
        {
            MainModel.CurrentView = MainModel.ApartmentsVm;
        }

        #endregion

        public NavigationViewModel(RealEstateDB db, IBuildingCount buildingCountService)
        {
            DataBase = db;
            BuildingCountService = buildingCountService;
        }


        public async Task LoadAsync()
        {
            CountEstate = await BuildingCountService.GetCountAsync().ConfigureAwait(false);
            countNonResidentialBuilding = await BuildingCountService.GetNonResidentalCountAsync().ConfigureAwait(false);
            countResidentialBuilding = await BuildingCountService.GetResidentalCountAsync();
            countApartmentBuilding = await BuildingCountService.GetApartmentCountAsync().ConfigureAwait(false);
        }
    }
}
