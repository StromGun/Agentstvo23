using Agentstvo23.DAL.Context;
using Agentstvo23.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agentstvo23.ViewModels
{
    internal class NavigationViewModel : ViewModel
    {
        private string _title = "Навигация";
        private int countEstate;
        private int countNonResidentialBuilding;
        private int countResidentialBuilding;
        private int countApartmentBuilding;

        public ViewModel MainModel { get; set; }
        public string Title { get => _title; set => Set(ref _title, value); }
        public RealEstateDB DataBase { get; set; }


        public int CountEstate { get => countEstate; set => Set(ref countEstate, value); }
        public int CountNonResidentialBuilding { get => countNonResidentialBuilding; set => Set(ref countNonResidentialBuilding, value); }
        public int CountResidentialBuilding { get => countResidentialBuilding; set => Set(ref countResidentialBuilding, value); }
        public int CountApartmentBuilding { get => countApartmentBuilding; set => Set(ref countApartmentBuilding, value); }

        public NavigationViewModel(MainWindowViewModel mainModel, RealEstateDB db)
        {
            DataBase = db;
            MainModel = mainModel;

            GetCounts().ConfigureAwait(false);
        }

        private async Task GetCounts()
        {
            countEstate = await DataBase.Buildings.CountAsync();
            CountNonResidentialBuilding = await DataBase.Buildings.Where(p => p.AssignationBuilding == "Нежилое здание").CountAsync();
            CountResidentialBuilding = await DataBase.Buildings.Where(p => p.AssignationBuilding == "Жилой дом").CountAsync();
            CountApartmentBuilding = await DataBase.Buildings.Where(p => p.AssignationBuilding == "Многоквартирный дом").CountAsync();
        }
    }
}
