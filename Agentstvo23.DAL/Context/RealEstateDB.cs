using Agentstvo23.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agentstvo23.DAL.Context
{
    public class RealEstateDB : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingExtended> BuildingsExtended { get; set; }


        public RealEstateDB(DbContextOptions<RealEstateDB> options) : base(options)
        {
                
        }

    }
}
