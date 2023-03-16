﻿namespace Agentstvo23.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public int? UserId { get; set; }

        public User? User { get; set; }
    }
}
