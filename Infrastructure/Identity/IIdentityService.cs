using System;

namespace Infrastructure.Identity
{
    public interface IIdentityService
    {
        public Guid GetCurrentUserId();
    }
}
