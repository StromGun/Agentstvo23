using Agentstvo23.DAL.Context;
using Agentstvo23.DAL.Entities;
using Agentstvo23.Infrastructure.Commands;
using Agentstvo23.Services.Interfaces;
using Agentstvo23.ViewModels.Base;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace Agentstvo23.ViewModels
{
    internal class RealEstatesViewModel : ViewModel
    {
        private string _title = "Недвижимости";
        private Building selectedBuilding;
        private readonly RealEstateDB DataBase;
        private readonly IGetBuildingData BuildingData;


        public string Title { get => _title; set => Set(ref _title, value); }
        public MainWindowViewModel MainModel { get; internal set; }

        #region Buildings : ObservableCollection<Building> - коллекция зданий

        private ObservableCollection<Building> buildings;

        /// <summary> Коллекция книг </summary>
        public ObservableCollection<Building> BuildingsList
        {
            get => buildings;
            set
            {
                if (Set(ref buildings, value))
                {
                    buildingsViewSource = new CollectionViewSource
                    {
                        Source = value,
                        SortDescriptions =
                        {
                            new SortDescription(nameof(Building.Id), ListSortDirection.Ascending )
                        }
                    };

                    buildingsViewSource.Filter += OnBuildingFilter;
                    buildingsViewSource.View.Refresh();

                    OnPropertyChanged(nameof(BuildingsView));
                }
            }
        }


        #endregion

        #region BuildingFilter : string - Искомый кадастровый номер
        private string buildingFilter;
        public string BuildingFilter
        {
            get => buildingFilter;
            set
            {
                if (Set(ref buildingFilter, value))
                    buildingsViewSource.View.Refresh();
            }
        }

        #endregion

        private CollectionViewSource buildingsViewSource;

        public ICollectionView BuildingsView => buildingsViewSource?.View;



        public Building SelectedBuilding { get => selectedBuilding; set => Set(ref selectedBuilding, value); }


        #region Commands

        #region LoadAsync - загрузка окна
        private LambdaCommand? _LoadedAsync;
        public ICommand LoadedAsyncCmd => _LoadedAsync
            ??= new(LoadedAsyncExecuted);
        private void LoadedAsyncExecuted()
        {
            LoadAsync();
        }
        #endregion

        private LambdaCommand? _RefreshAsync;
        public ICommand RefreshAsyncCmd => _RefreshAsync
            ??= new(RefreshAsyncExecuted);
        private void RefreshAsyncExecuted()
        {

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


        private void OnBuildingFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is not Building building || string.IsNullOrEmpty(buildingFilter)) return;

            if (!building.CadastralNumber.Contains(BuildingFilter))
                e.Accepted = false;
        }

    }
}
