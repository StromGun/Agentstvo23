using Agentstvo23.DAL.Context;
using Agentstvo23.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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


        public async Task<int> GetCountAsync()
        {
            return BuildingCount = await db.Buildings.CountAsync().ConfigureAwait(false);
        }

        public async Task<int> GetResidentalCountAsync()
        {
            return BuildingCount = await db.Buildings.Where(p => p.AssignationBuilding == "Жилой дом").CountAsync().ConfigureAwait(false);
        }

        public async Task<int> GetNonResidentalCountAsync()
        {
            return BuildingCount = await db.Buildings.Where(p => p.AssignationBuilding == "Нежилое здание").CountAsync().ConfigureAwait(false);
        }      

        public async Task<int> GetApartmentCountAsync()
        {
            return BuildingCount = await db.Buildings.Where(p => p.AssignationBuilding == "Многоквартирный дом").CountAsync().ConfigureAwait(false);
        }
    }
}
