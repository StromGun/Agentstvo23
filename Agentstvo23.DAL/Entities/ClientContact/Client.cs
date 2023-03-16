using System.ComponentModel.DataAnnotations;

namespace Agentstvo23.DAL.Entities.ClientContact
{
    public class Client
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }
        [MaxLength(255)]
        public string? Patronymic { get; set; }
        [MaxLength(14)]
        public string? Phone { get; set; }
        [MaxLength(255)]
        public string? EMail { get; set; }
        public string? Details { get; set; }

        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
