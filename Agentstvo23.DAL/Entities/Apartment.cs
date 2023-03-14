namespace Agentstvo23.DAL.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public string CadastralNumber { get; set; }
        public string Adress { get; set; }
        public string? ApartmentType { get; set; }
        public string? ApartmentValue { get; set; }
        public double Area { get; set; }
        public decimal CadastralCostValue { get; set; }
        public decimal CostPerMeter { get; set; }
        public string AssignationCode { get; set; }
        public string AssignationType { get; set; }
        public string BuildingCadastralNumber { get; set; }
    }
}
