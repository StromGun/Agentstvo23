using Agentstvo23.DAL.Context;
using Agentstvo23.Infrastructure.Commands;
using Agentstvo23.Infrastructure.Events;
using Agentstvo23.Services.Interfaces;
using Agentstvo23.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        private int countApartmentAll;
        private int countPremise;
        private int countRoom;
        private int countApartment;
        #endregion

        public string Title { get => _title; set => Set(ref _title, value); }
        private MainWindowViewModel? mainModel;
        public MainWindowViewModel? MainModel { get => mainModel; set => Set(ref mainModel, value); }

        private readonly RealEstateDB? DataBase;
        private readonly IBuildingCount BuildingCountService;

        #region Counts
        public int CountEstate { get => countEstate; set => Set(ref countEstate, value); }
        public int CountNonResidentialBuilding { get => countNonResidentialBuilding; set => Set(ref countNonResidentialBuilding, value); }
        public int CountResidentialBuilding { get => countResidentialBuilding; set => Set(ref countResidentialBuilding, value); }
        public int CountApartmentBuilding { get => countApartmentBuilding; set => Set(ref countApartmentBuilding, value); }

        public int CountApartment { get => countApartment; set => Set(ref countApartment, value); }
        public int CountPremise { get => countPremise; set => Set(ref countPremise, value); }
        public int CountRoom { get => countRoom; set => Set(ref countRoom, value); }
        public int CountApartmentAll { get => countApartmentAll; set => Set(ref countApartmentAll, value); }
        #endregion

        #region Commands

        #region ShowRealEstatesView : Command
        private LambdaCommand? _ShowRealEstatesView;
        public ICommand ShowRealEstatesView => _ShowRealEstatesView
            ??= new(ShowRealEstatesViewExecuted);

        private void ShowRealEstatesViewExecuted()
        {
            MainModel.CurrentView = MainModel.BuildingsVm;           
        }
        #endregion

        #region ShowApartmentsView : Command
        private LambdaCommand? _ShowApartmentsView;
        public ICommand ShowApartmentsView => _ShowApartmentsView
            ??= new(ShowApartmentExecuted);

        private void ShowApartmentExecuted()
        {
            MainModel.CurrentView = MainModel.ApartmentsVm;
        }
        #endregion

        #region LoadAsync : Command
        private LambdaCommand? loadAsync;
        public ICommand LoadAsyncCmd => loadAsync
            ??= new(OnLoadAsyncExecuted);
        private async void OnLoadAsyncExecuted()
        {
            await LoadAsync();
        } 
        #endregion

        #endregion

        public NavigationViewModel(RealEstateDB? db, IBuildingCount buildingCountService)
        {
            DataBase = db;
            BuildingCountService = buildingCountService;
        }


        public async Task LoadAsync()
        {
            if (DataBase == null) return;
            CountEstate = await BuildingCountService.GetCountAsync();
            CountNonResidentialBuilding = await BuildingCountService.GetNonResidentalCountAsync();
            CountResidentialBuilding = await BuildingCountService.GetResidentalCountAsync();
            CountApartmentBuilding = await BuildingCountService.GetApartmentCountAsync();

            CountApartmentAll = await DataBase.Apartments.CountAsync();
            CountApartment = await DataBase.Apartments.Where(p => p.ApartmentType == "кв").CountAsync();
            CountPremise = await DataBase.Apartments.Where(p => p.ApartmentType == "пом").CountAsync();
            CountRoom = await DataBase.Apartments.Where(p => p.ApartmentType == "к").CountAsync();
        }
    }
}
