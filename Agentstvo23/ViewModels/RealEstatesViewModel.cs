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
        private ViewModel MainModel;
        private RealEstateDB DataBase;
        private ObservableCollection<Building> buildings;

        public string Title { get => _title; set => Set(ref _title, value); }
        public ObservableCollection<Building> Buildings { get => buildings; set => Set(ref buildings,value); }

        public RealEstatesViewModel(MainWindowViewModel mainModel, RealEstateDB db)
        {
            MainModel = mainModel;
            DataBase = db;


            //DataBase.Buildings.Load();
            GetData().ConfigureAwait(false);
        }

        private async Task GetData()
        {
            await DataBase.Buildings.LoadAsync();
            Buildings = DataBase.Buildings.Local.ToObservableCollection();
        }

    }
}
