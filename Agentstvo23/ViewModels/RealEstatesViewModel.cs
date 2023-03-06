using Agentstvo23.DAL.Context;
using Agentstvo23.DAL.Entities;
using Agentstvo23.Infrastructure.Commands;
using Agentstvo23.Services.Interfaces;
using Agentstvo23.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agentstvo23.ViewModels
{
    internal class RealEstatesViewModel : ViewModel
    {
        private string _title = "Недвижимости";
        private ObservableCollection<Building> buildings;

        public MainWindowViewModel MainModel { get; internal set; }
        public string Title { get => _title; set => Set(ref _title, value); }
        public ObservableCollection<Building> BuildingsList { get => buildings; set => Set(ref buildings,value); }

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
