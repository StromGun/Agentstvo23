using Agentstvo23.DAL.Entities;
using Agentstvo23.DAL.Entities.ClientContact;
using Agentstvo23.DAL.Entities.Contract;
using Agentstvo23.DAL.Entities.Estates;
using Microsoft.EntityFrameworkCore;

namespace Agentstvo23.DAL.Context
{
    public class RealEstateDB : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<BuildingExtended> BuildingsExtended { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Contract> Contracts { get; set; }


        public RealEstateDB(DbContextOptions<RealEstateDB> options) : base(options)
        {
                
        }

    }
}
