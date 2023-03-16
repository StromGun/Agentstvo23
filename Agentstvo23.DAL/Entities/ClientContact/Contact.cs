namespace Agentstvo23.DAL.Entities.ClientContact
{
    public class Contact
    {
        public int Id { get; set; } 
        public Client Client { get; set; }
        public int? Employee_id { get; set; }
        public int? Estate_id { get; set; }
        public DateTime Contact_Time { get; set; }
        public string? Details { get; set; }

    }
}
