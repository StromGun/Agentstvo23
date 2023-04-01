using System.ComponentModel.DataAnnotations;

namespace Agentstvo23.DAL.Entities.Estates
{
    public class Building
    { 
        public int Id { get; set; }
        [Required]
        public string CadastralNumber { get; set; }
        public string Adress { get; set; }
        public double Area { get; set; }
        [Range(0, 100000000.00)]
        public decimal CadastralCostValue { get; set; }
        public decimal CostPerMeter { get; set; }
        public string AssignationBuilding { get; set; }
        public string CadastralBlock { get; set; }
        [Range(0, 2023)]
        public int YearBuilt { get; set; }
        [Range(0, 25)]
        public int Floors { get; set; }
        [Range(0, 25)]
        public int? UndergroundFloors { get; set; }

        public List<BuildingExtended> BuildingExtendeds { get; set; } = new();
    }
}
