using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string username, string password);
    }
}
