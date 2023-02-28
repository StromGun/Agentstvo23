using Agentstvo23.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agentstvo23.DAL.Context
{
    public class RealEstateDB : DbContext
    {
        public DbSet<Building> Buildings { get; set; }


        public RealEstateDB(DbContextOptions<RealEstateDB> options) : base(options)
        {
                
        }
    }
}
