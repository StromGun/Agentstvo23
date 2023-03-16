using System.ComponentModel.DataAnnotations.Schema;

namespace Agentstvo23.DAL.Entities.Contract
{
    public class Contract
    {
        public int Id { get; set; }
        public int Client_id { get; set; }
        public int Employee_id { get; set; }
        public int ContractType_id { get; set; }
        public string? Contract_details { get; set; }
        public int? PaymentFrequency_id { get; set; }
        [Column(TypeName ="Money")]
        public decimal PaymentAmount { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? DateSigned { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? EndDate { get; set; }
    }
}
