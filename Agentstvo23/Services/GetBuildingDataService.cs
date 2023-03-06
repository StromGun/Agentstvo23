using Agentstvo23.DAL.Context;
using Agentstvo23.DAL.Entities;
using Agentstvo23.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Agentstvo23.Services
{
    internal class GetBuildingDataService : IGetBuildingData
    {
        private readonly RealEstateDB db;

        public GetBuildingDataService(RealEstateDB context)
        {
            db = context;
        }

        public ObservableCollection<Building> GetBuilding()
        {
            db.Buildings.Load();
            return db.Buildings.Local.ToObservableCollection();
        }
    }
}
