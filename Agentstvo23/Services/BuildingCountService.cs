using Agentstvo23.DAL.Context;
using Agentstvo23.Services.Interfaces;
using System.Linq;

namespace Agentstvo23.Services
{
    internal class BuildingCountService : IBuildingCount
    {
        private readonly RealEstateDB db;

        public int BuildingCount { get; set; }

        public BuildingCountService(RealEstateDB context)
        {
            db = context;
        }


        public int GetCount()
        {
            return BuildingCount = db.Buildings.Count();
        }

        public int GetResidentalCount()
        {
            return BuildingCount = db.Buildings.Where(p => p.AssignationBuilding == "Жилой дом").Count();
        }

        public int GetNonResidentalCount()
        {
            return BuildingCount = db.Buildings.Where(p => p.AssignationBuilding == "Нежилое здание").Count();
        }

        public int GetApartmentCOunt()
        {
            return BuildingCount = db.Buildings.Where(p => p.AssignationBuilding == "Многоквартирный дом").Count();
        }
    }
}
