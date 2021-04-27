using System;

namespace ChatTek.Infrastructure.Identity
{
    public interface IIdentityService
    {
        public Guid GetCurrentUserId();
    }
}
