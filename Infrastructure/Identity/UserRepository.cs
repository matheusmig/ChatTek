using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetAsync(string username, string password)
        {
            var users = new List<User>
            {
                new User { Id = new Guid("B4A527A9-8598-4D7A-954B-F834F0E065E1"), Username = "goku", Password = "goku", Role = "Manager", Department = "Sales" },
                new User { Id = new Guid("6F054B91-32A8-4829-A2C0-854CB5C2DBB2"), Username = "vegeta", Password = "vegeta", Role = "Employee", Department = "Marketing" },
                new User { Id = new Guid("3BA94E4A-ADC3-4CBB-AD3A-B739892C9A5C"), Username = "kuririn", Password = "kuririn", Role = "Trainee", Department = "Marketing" },
                new User { Id = new Guid("B52DA484-E7E4-4723-9CD1-C248E3C9FC9B"), Username = "piccolo", Password = "piccolo", Role = "Manager", Department = "Marketing" },
            };

            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
