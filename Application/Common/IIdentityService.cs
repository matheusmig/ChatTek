using System;

namespace Application.Common
{
    public interface IIdentityService
    {
        public Guid GetCurrentUserId();
    }
}
