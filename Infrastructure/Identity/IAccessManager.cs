using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public interface IAccessManager
    {
        public Task<string> ForgeTokenAsync(string username, string password);
    }
}
