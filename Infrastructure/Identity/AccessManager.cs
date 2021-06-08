using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AccessManager : IAccessManager
    {
        private readonly IUserRepository _userRepository;

        public AccessManager(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<string> ForgeTokenAsync(string username, string password)
        {
            var user = await _userRepository.GetAsync(username, password);

            if (user == null)
                return null;

            return TokenService.CreateToken(user);
        }

    }
}
