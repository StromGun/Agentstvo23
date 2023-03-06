using Agentstvo23.DAL.Context;
using Agentstvo23.DAL.Entities;
using Agentstvo23.Infrastructure.Commands;
using Agentstvo23.Services.Interfaces;
using Agentstvo23.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Agentstvo23.ViewModels
{
    internal class RealEstatesViewModel : ViewModel
    {
        private string _title = "Недвижимости";
        private ObservableCollection<Building> buildings;
        private Building selectedBuilding;

        public string Title { get => _title; set => Set(ref _title, value); }
        public MainWindowViewModel MainModel { get; internal set; }

        public ObservableCollection<Building> BuildingsList { get => buildings; set => Set(ref buildings,value); }
        public Building SelectedBuilding { get => selectedBuilding; set => Set(ref selectedBuilding, value); }

        private readonly RealEstateDB DataBase;
        private readonly IGetBuildingData BuildingData;

        #region Commands
        private LambdaCommand? _LoadedAsync;
        public ICommand LoadedAsyncCmd => _LoadedAsync
            ??= new(LoadedAsyncExecuted);
        private void LoadedAsyncExecuted()
        {
            LoadAsync();
        } 
        #endregion



        public RealEstatesViewModel(RealEstateDB db, IGetBuildingData getBuilding)
        {
            DataBase = db;
            BuildingData = getBuilding;
        }

        private void LoadAsync()
        {
            BuildingsList = BuildingData.GetBuilding();
        }


    }
}
