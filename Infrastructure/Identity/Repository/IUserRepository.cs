using Infrastructure.Identity.Models;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Repository
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string username, string password);
    }
}
