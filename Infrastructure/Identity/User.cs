using System;

namespace Infrastructure.Identity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        //claims
        public string Department { get; set; }
    }
}
