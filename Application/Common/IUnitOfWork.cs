using System.Threading.Tasks;

namespace Application.Common
{
    public interface IUnitOfWork
    {
        public Task<int> SaveAsync();
    }
}
