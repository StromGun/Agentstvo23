using Agentstvo23.DAL.Context;
using Agentstvo23.DAL.Entities;
using Agentstvo23.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agentstvo23.ViewModels
{
    internal class RealEstatesViewModel : ViewModel
    {
        private string _title = "Недвижимости";
        private readonly RealEstateDB DataBase;
        private ObservableCollection<Building> buildings;

        public string Title { get => _title; set => Set(ref _title, value); }
        public ObservableCollection<Building> BuildingsList { get => buildings; set => Set(ref buildings,value); }
        public MainWindowViewModel MainModel { get; internal set; }

        public RealEstatesViewModel(RealEstateDB db)
        {
            DataBase = db;


            //DataBase.Buildings.Load();
            GetData().ConfigureAwait(false);
        }

        private async Task GetData()
        {
            await DataBase.Buildings.LoadAsync();
            BuildingsList = DataBase.Buildings.Local.ToObservableCollection();
        }

    }
}
