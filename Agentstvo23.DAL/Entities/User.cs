namespace Agentstvo23.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<Employee>? Employees { get; set; }
    }
}
