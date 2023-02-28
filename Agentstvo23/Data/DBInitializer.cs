using Agentstvo23.DAL.Context;
using Agentstvo23.DAL.Entities;
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
            GetBuildingsData();
        }

        private IEnumerable<string> GetLines()
        {
            using (var reader = new StreamReader(@"C:\Users\StormGun\Desktop\Кадастровая стоимость зданий - Тверской район.csv"))
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
                    Id = Convert.ToInt32(line[0].Trim()),
                    CadastralNumber = line[1].Trim(),
                    Adress = line[2].Trim(),
                    Area = Convert.ToDouble(line[3].Trim()),
                    CadastralCostValue = Convert.ToDecimal(line[4].Trim()),
                    CostPerMeter = Convert.ToDecimal(line[5].Trim()),
                    AssignationBuilding = line[6].Trim(),
                    CadastralBlock = line[7].Trim(),
                    YearBuilt = Convert.ToInt32(line[8].Trim()),
                    Floors = Convert.ToInt32(line[9].Trim())

                };
                _db.Buildings.Add(building);
                _db.SaveChanges();
            }
        }
    }
}
