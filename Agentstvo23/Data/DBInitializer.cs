using Agentstvo23.DAL.Context;
using Agentstvo23.DAL.Entities.Estates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Agentstvo23.Data
{
    internal class DBInitializer
    {
        RealEstateDB _db;

        public DBInitializer(RealEstateDB db)
        {
            _db = db;
            //GetBuildingsData();
            //GetApartmentsData();
        }

        private IEnumerable<string> GetLines()
        {
            //using (var reader = new StreamReader(@"D:\Downloads\kads.csv"))
            using (var reader = new StreamReader(@"D:\Downloads\kadsApart.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    yield return line;
                }
            }
        }

        private void GetBuildingsData()
        {
            var lines = GetLines()
                .Skip(1)
                .Select(line => line.Split(";"));

            foreach (var line in lines)
            {
                var building = new Building
                {
                    //Id = Convert.ToInt32(line[0].Trim()),
                    CadastralNumber = line[1].Trim(),
                    Adress = line[2].Trim(),
                    Area = Convert.ToDouble(line[3].Trim()),
                    CadastralCostValue = Convert.ToDecimal(line[4].Trim()),
                    CostPerMeter = Convert.ToDecimal(line[5].Trim()),
                    AssignationBuilding = line[6].Trim(),
                    CadastralBlock = line[7].Trim(),
                    YearBuilt = Convert.ToInt32(line[8].Trim()),
                    Floors = Convert.ToInt32(line[10].Trim()),
                    UndergroundFloors = Convert.ToInt32(line[11].Trim())
                    
                };
                _db.Buildings.Add(building);
            }
                _db.SaveChanges();
        }

        private void GetApartmentsData()
        {
            var lines = GetLines()
                .Skip(1)
                .Select(line => line.Split(";"));

            foreach (var line in lines)
            {
                var apartment = new Apartment
                {
                    //Id = Convert.ToInt32(line[0].Trim()),
                    CadastralNumber = line[1].Trim(),
                    Adress = line[2].Trim(),
                    ApartmentType = line[3].Trim(),
                    ApartmentValue = line[4].Trim(),
                    Area = Convert.ToDouble(line[5].Trim()),
                    CadastralCostValue = Convert.ToDecimal(line[6].Trim()),
                    CostPerMeter = Convert.ToDecimal(line[7].Trim()),
                    AssignationCode = line[8].Trim(),
                    AssignationType = line[9].Trim(),
                    BuildingCadastralNumber = line[10].Trim()

                };
                _db.Apartments.Add(apartment);
            }
            _db.SaveChanges();
        }
    }
}
