namespace Agentstvo23.DAL.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public string CadastralNumber { get; set; }
        public string Adress { get; set; }
        public double Area { get; set; }
        public decimal CadastralCostValue { get; set; }
        public decimal CostPerMeter { get; set; }
        public string AssignationBuilding { get; set; }
        public string CadastralBlock { get; set; }
        public int YearBuilt { get; set; }
        public int Floors { get; set; }
        public int? UndergroundFloors { get; set; }

        public List<BuildingExtended> BuildingExtendeds { get; set; } = new();
    }
}
